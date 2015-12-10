using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DC.Models;

namespace DC.Controllers
{
    public class TitlesController : ApiController
    {
        private Entities _context = new Entities();

        // GET api/titles
        public IEnumerable<Title> Get(string q = null)
        {
           // _context.Configuration.ProxyCreationEnabled = false;

            var titlesList = _context.Titles.ToList();

            if (!string.IsNullOrEmpty(q) && q != "undefined")
                titlesList = 
                    titlesList.Where(t => t.TitleName.ToLower().StartsWith(q.ToLower())
                                     
                    ).ToList();

            return titlesList;
        }

    }
}
