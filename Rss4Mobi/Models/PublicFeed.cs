using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rss4Mobi.Models
{
    public class PublicFeed
    {
        public int ID { get; set; }
        [MaxLength(50),MinLength(1)]
        public string Name { get; set; }
        [MaxLength(500), MinLength(3)]
        public string Link { get; set; }
        public PublicFeedCategory Category { get; set; }
        public PublicFeedBundle Bundle { get; set; }

        public bool IsFullContent { get; set; }
    }
}