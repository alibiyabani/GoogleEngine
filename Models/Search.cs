using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GoogleEngine.Models
{
    public class Search
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Term { get; set; }
        public DateTime SearchDate { get; set; }

    }
}
