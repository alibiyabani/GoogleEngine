using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleEngine.Models
{
    public class Result
    {
        [Key]
        public int SearchId { get; set; }
        public string ObjectResult { get; set; }
        public string Terms { get; set; }
        public DateTime SearchDate { get; set; }
        public IList<Search> SearchResult { get; set; }
    }
}
