using Fa.JustBlog.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class HomeController : Controller
    {
        PostDao postDao = new PostDao();
        public ActionResult Index()
        {
            ViewBag.list = postDao.getPost();
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.post = postDao.getPostById(id);
            return View();
        }


        public ActionResult ListPost()
        {
            ViewBag.list = postDao.getAll();
            return View();
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