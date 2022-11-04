using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenVanPhuocHoa.Models;
namespace NguyenVanPhuocHoa.Controllers
{
    public class DangNhapController : Controller
    {
        MyDBDataContext data = new MyDBDataContext();
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            var all_sv = from ss in data.SinhViens select ss;
            return View(all_sv);
        }
    }
}