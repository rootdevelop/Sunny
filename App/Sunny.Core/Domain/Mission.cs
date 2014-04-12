using System;
using System.Collections.Generic;

namespace Sunny.Core.Domain
{
    public class Mission
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public string Location { get; set; }

        public string Tags { get; set; }

        public string ThumbnailUri { get; set; }

        public string ImageUri { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public bool MainPage { get; set; }

        public List<Media> Media { get; set; }
    }
}