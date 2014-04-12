using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sunny.Services.Domain
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string IntroText { get; set; }
        public string Text { get; set; }
        public string ThumbnailUri { get; set; }
        public string ImageUri { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int? MissionId { get; set; }

        [ForeignKey("MissionId")]
        public Mission Mission { get; set; }
    }
}