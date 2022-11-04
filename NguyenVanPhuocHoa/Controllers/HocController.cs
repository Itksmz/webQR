using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenVanPhuocHoa.Models;
namespace NguyenVanPhuocHoa.Controllers
{
    public class HocController : Controller
    {
        MyDBDataContext data = new MyDBDataContext();
        public ActionResult ListHP()
        {
            var all_hp = from ss in data.HocPhans select ss;
            return View(all_hp);
        }

    }
}