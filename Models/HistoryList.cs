using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LataPrzestepne.Models
{
    public class HistoryList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Items { get; private set; }

        public HistoryList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static HistoryList<T> Create(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();
            return new HistoryList<T>(items, count, pageIndex, pageSize);
        }
    }
}
