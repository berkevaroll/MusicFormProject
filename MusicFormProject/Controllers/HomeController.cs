using MusicFormProject.Models;
using MusicFormProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicFormProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Music model = new Music();

            return View(model);
        }
        [HttpPost]
        public JsonResult Create(Music resModel)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                DB_TraCaseEntities1 db = new DB_TraCaseEntities1();
                Music model = new Music();
                model.SongName = resModel.SongName;
                model.AlbumName = resModel.AlbumName;
                model.Artist = resModel.Artist;
                model.Duration = resModel.Duration;
                model.PublishYear = Convert.ToInt32(resModel.PublishYear);
                db.Music.Add(model);
                db.SaveChanges();

                jsonResultModel.IsSuccess = true;
                jsonResultModel.ResMessage = "The Song has been added successfully";
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSuccess = false;
                jsonResultModel.ResMessage = "Something went wrong! Please try again.";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}