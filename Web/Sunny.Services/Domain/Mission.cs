using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sunny.Services.Domain
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
        public string Tags { get; set; }
        public string ThumbnailUri { get; set; }
        public string ImageUri { get; set; }

        public IList<Media> Media { get; set; }

        [NotMapped]
        public int[] MediaIds { get; set; }
    }
}