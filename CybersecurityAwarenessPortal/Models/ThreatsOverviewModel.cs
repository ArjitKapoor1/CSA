using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dropbox.Api;

namespace CybersecurityAwarenessPortal.Models
{
    public class ThreatsOverviewModel
    {
        public List<SelectListItem> ImageName { get; set; }

        public string img { get; set; }

        public DropboxClient dbxuser { get; set; }
    }
}