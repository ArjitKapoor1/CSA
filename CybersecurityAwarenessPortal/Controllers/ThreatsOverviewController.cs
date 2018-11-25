using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dropbox.Api;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class ThreatsOverviewController : Controller
    {
        public ActionResult ThreatsOverviewView()
        {
            Session["moduleid"] = 1; 
            //Models.ThreatsOverviewModel tom = new Models.ThreatsOverviewModel();
            //List<SelectListItem> imgName = tom.ImageName;
            //string accesstkn = ConfigurationManager.AppSettings["DropboxAccessToken"];
            //tom.dbxuser = new DropboxClient(accesstkn);
            //tom.dbxuser.Files.GetThumbnailAsync("RootCauses.png");
          //  tom.dbxuser.Files.;

            //Task task  = ListRootFolder(dbxuser);
            return View();
        }


        //async Task ListRootFolder(DropboxClient dbx)
        //{
        //    var list = await dbx.Files.ListFolderAsync(string.Empty);

        //    // show folders then files
        //    foreach (var item in list.Entries.Where(i => i.IsFolder))
        //    {
        //        Models.ThreatsOverviewModel tom = new Models.ThreatsOverviewModel();
        //        tom.ImageName.Add(Convert.ToSitem.Name);
        //    }
        //}
    //    [HttpPost]
    //    public ActionResult ThreatsOverviewView(GameController gm)
    //    {
    //        Session["moduleid"] = 1;
    //        return RedirectToAction("GamePage2","Game");
    //    }
    }
}