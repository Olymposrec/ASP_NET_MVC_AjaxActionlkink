using ASP_NET_MVC_AjaxActionlink_BeginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ASP_NET_MVC_AjaxActionlink_BeginForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> veriler = new List<string>() { "melih", "akkose", "Olymposrec", "ASP.NET", "Çalışma", "Denemeleri" };
            Session["Veriler"] = veriler;
            return View();
        }
        public ActionResult Index2()
        {
            List<ToDoItem> list = null;
            if (Session["todolist"] != null)
            {
                list = Session["todolist"] as List<ToDoItem>;
            }
            else
            {
                list = new List<ToDoItem>();
            }
            ViewBag.List = list;
            return View(new ToDoItem());
        }
        [HttpPost]
        public PartialViewResult Index2(ToDoItem model)
        {
            List<ToDoItem> list = null;
            if(Session["todolist"]!=null)
            {
                list = Session["todolist"] as List<ToDoItem>;
            }
            else
            {
                list = new List<ToDoItem>();
            }
            model.Id = Guid.NewGuid();
            list.Add(model);
            Session["todolist"] = list;
            System.Threading.Thread.Sleep(3000);
            return PartialView("_ToDoItemPartialView",model);
        }
        public PartialViewResult LoadData()
        {
            List<string> veriler = Session["Veriler"] as List<string>;
            System.Threading.Thread.Sleep(3000);
            return PartialView("_VeriListesiPartialView", veriler);
        }
        public MvcHtmlString RemoveData(int id)
        {
            List<string> veriler=Session["Veriler"] as List<string>;
            veriler.RemoveAt(id);
            Session["Veriler"] = veriler;
            System.Threading.Thread.Sleep(3000);
            return MvcHtmlString.Empty;
        }
    }
}