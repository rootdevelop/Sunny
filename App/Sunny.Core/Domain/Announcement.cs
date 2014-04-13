using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sunny.Core.Domain
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IntroText { get; set; }
        public string Text { get; set; }
        public string ThumbnailUri { get; set; }
        public string ImageUri { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
