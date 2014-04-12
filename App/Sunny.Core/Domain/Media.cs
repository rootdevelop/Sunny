using System;
using Sunny.Core.Domain.Enums;

namespace Sunny.Core.Domain
{
    public class Media
    {
        public int Id { get; set; }
        public string ThumbnailUri { get; set; }
        public string ImageUri { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Tags { get; set; }


        public EMediaType MediaType { get; set; }
        public Mission Mission { get; set; }
    }
}