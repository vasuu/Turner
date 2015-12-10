using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DC.Models
{
    public class TitleDetail
    {
        public Title Title { get; set; }
        public List<Genre> Genres { get; set; }
        public dynamic Participants { get; set; }
        public List<OtherName> OtherNames { get; set; }
        public List<Award> Awards { get; set; }
        public List<StoryLine> Storylines { get; set; }
    }
}