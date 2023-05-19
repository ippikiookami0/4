using LataPrzestepne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using LataPrzestepne.Data;
using System.Security.Claims;
using System.Collections;
using System.Drawing.Printing;

namespace LataPrzestepne.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public HistoryDB HistoryDB { get; set; }

        private readonly ILogger<IndexModel> _logger;
        public IList<HistoryDB> historyDataList { get; set; }

        private readonly DataContext _context;
        public IndexModel(ILogger<IndexModel> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            var historyDataList = _context.HistoryDB.ToList();
        }
        public IActionResult OnPost() {
            if(HistoryDB.YearOfBirth < 1899 || HistoryDB.YearOfBirth > 2024) { return base.Page(); }
            historyDataList = _context.HistoryDB.ToList();
            HistoryDB.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            HistoryDB.Time = DateTime.Now;
            if(HistoryDB.Name == null)
            {
                if(HistoryDB.UserId != null)
                {
                    HistoryDB.Name = User.FindFirstValue(ClaimTypes.NameIdentifier);
                }
                else
                {
                    HistoryDB.Name = "random user";
                    HistoryDB.UserId = "null";
                }
            }
            else if(HistoryDB.UserId == null)
            {
                HistoryDB.UserId = "null";
            }
            if(HistoryDB.YearOfBirth % 4 == 0)
            {
                HistoryDB.Result = "To byl rok przestepny";
            }
            else
            {
                HistoryDB.Result = "To nie byl rok przestepny";
            }
            _context.HistoryDB.Add(HistoryDB);
            _context.SaveChanges();
            return Page();
        
        }
    }
}