﻿using System;
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

        public IList<Media> Media { get; set; }
    }
}