using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Sunny.Services.Domain.Enums;

namespace Sunny.Services.Domain
{
    public class Media
    {
        [Key]
        public int Id { get; set; }
        public string ThumbnailUri { get; set; }
        public string ImageUri { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Tags { get; set; }

        public int? MissionId { get; set; }

        public EMediaType MediaType { get; set; }
        [ForeignKey("MissionId")]
        public Mission Mission { get; set; }
    }
}