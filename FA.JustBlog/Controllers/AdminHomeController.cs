using Fa.JustBlog.Daos;
using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class AdminHomeController : Controller
    {
        UserDao userDao = new UserDao();
        PostDao postDao = new PostDao();
        // GET: AdminHome
        public ActionResult Index(string mess)
        {
            var user = Session["USER"];
            if (user == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            else
            {
                ViewBag.Msg = mess;
                ViewBag.list = postDao.getAll();
                ViewBag.count = postDao.getAll().Count;
                return View();
            }
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var username = form["username"];
            var password = form["password"];
            bool checkLogin = userDao.checkLogin(username, password);
            if (checkLogin)
            {
                var userInformation = userDao.getInformationByUserName(username);
                Session.Add("USER", userInformation);
                return RedirectToAction("Index","AdminHome");
            }
            else
            {
                ViewBag.mess = "Thông tin tài khoản hoặc mật khẩu không chính xác";
                return View("Login");
            }

        }
        public ActionResult Logout()
        {
            Session.Remove("USER");
            return Redirect("/");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(FormCollection form)
        {
            var user = (User)Session["USER"];
            var title = form["tieude"];
            var motangan = form["motangan"];
            var nguoidung = user.id_user;
            var noidung = form["noidung"];
            DateTime now = DateTime.Now;
            Post post = new Post();
            post.title = title;
            post.desShort = motangan;
            post.content = noidung;
            post.id_user = nguoidung;
            post.createdAt = now;
            postDao.addPost(post);
            var message = "1";
            return RedirectToAction("Index", new { mess = message });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            postDao.delete(id);
            var message = "1";
            return RedirectToAction("Index", new { mess = message });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            var title = form["tieude"];
            var motangan = form["motangan"];
            var noidung = form["noidung"];
            Post post = new Post();
            post.title = title;
            post.desShort = motangan;
            post.content = noidung;
            post.id_post = id;
            postDao.update(post);
            var message = "1";
            return RedirectToAction("Index", new { mess = message });
        }
    }
}