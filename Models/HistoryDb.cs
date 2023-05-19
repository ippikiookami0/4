using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace LataPrzestepne.Models
{
    public class HistoryDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1899, 2022, ErrorMessage = "Oczekiwany rok {0} z zakresu {1} i {2}.")]
        public int? YearOfBirth { get; set; }

        public string Result { get; set; }

        public string Name { get; set; }

        [AllowNull]
        public string UserId { get; set; }

        public DateTime Time { get; set; }
    }
}
