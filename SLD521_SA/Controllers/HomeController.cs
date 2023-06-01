using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SLD521_SA.Models;

namespace SLD521_SA.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        SACLAEntities _context = new SACLAEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Papers()
        {
            var listofData = _context.Papers.ToList();

            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Paper model)
        {

                _context.Papers.Add(model);
                _context.SaveChanges();
                ViewBag.Message = "Data successfully inserted";

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var data = _context.Papers.Where(x => x.PapersID == ID).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Paper model)
        {
            var data = _context.Papers.Where(x => x.PapersID == model.PapersID).FirstOrDefault();
            if(data != null)
            {
                data.PapersID = model.PapersID;
                data.Title = model.Title;
                data.Abstract = model.Abstract;
                data.Date_Submitted = model.Date_Submitted;
                data.Topic = model.Topic;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult Detail(int ID)
        {
            var data = _context.Papers.Where(x => x.PapersID == ID).FirstOrDefault();

            return View(data);
        }
        public ActionResult Delete(int ID)
        {
            var data = _context.Papers.Where(x => x.PapersID == ID).FirstOrDefault();
            _context.Papers.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record was Deleted successfully!";
            
            return RedirectToAction("index");
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
    }
}