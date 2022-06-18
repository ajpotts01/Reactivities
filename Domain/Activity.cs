using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }

        public Activity()
        {
            this.Title       = String.Empty;
            this.Description = String.Empty;
            this.Category    = String.Empty;
            this.City        = String.Empty;
            this.Venue       = String.Empty;
        }
    }
}