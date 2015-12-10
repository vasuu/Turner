using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DC.Models;

namespace DC.Controllers
{
    public class TitleDetailsController : ApiController
    {
        private Entities _context = new Entities();

        // GET api/titledetails/5
        public TitleDetail Get(int id)
        {
           // _context.Configuration.ProxyCreationEnabled = false;

            var titleDetail = new TitleDetail()
            {
                Title = _context.Titles.First(t=>t.TitleId == id),
                Storylines = _context.StoryLines.Where(s => s.TitleId == id).ToList(),
                Genres = (from g in _context.Genres join tg in _context.TitleGenres on g.Id equals tg.GenreId where tg.TitleId == id select g).ToList(),
                OtherNames = _context.OtherNames.Where(on => on.TitleId == id).ToList(),
                Participants = (from p in _context.Participants
                                join tp in _context.TitleParticipants on p.Id equals tp.ParticipantId
                                where tp.TitleId == id
                                select new 
                                {
                                    Name = p.Name,
                                    Role = tp.RoleType,
                                    OnScreen = tp.IsOnScreen
                                }),
                Awards = _context.Awards.Where(a => a.TitleId == id).ToList()

            };

            return titleDetail;

        }

    }
}
