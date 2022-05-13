using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Records
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public List<Records> RecordsList { get; set; }
    }
}
