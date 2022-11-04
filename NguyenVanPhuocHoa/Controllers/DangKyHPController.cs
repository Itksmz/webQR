using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenVanPhuocHoa.Models;
namespace NguyenVanPhuocHoa.Controllers
{
    public class DangKyHPController : Controller
    {
        // GET: DangKyHP
        MyDBDataContext data = new MyDBDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public List<Hocphan> LayHP()
        {
            List<Hocphan> lstHocphan = Session["Hocphan"] as List<Hocphan>;
            if (lstHocphan == null)
            {
                lstHocphan = new List<Hocphan>();
                Session["Hocphan"] = lstHocphan;
            }
            return lstHocphan;
        }
        public ActionResult XoaHocPhan(string id)
        {
            List<Hocphan> lstHocphan = LayHP();
            Hocphan hp = lstHocphan.SingleOrDefault(n => n.mahp == id);
            if (hp != null)
            {
                lstHocphan.RemoveAll(n => n.mahp == id);
                return RedirectToAction("Hocphan");
            }
            return RedirectToAction("Hocphan");
        }
        public ActionResult XoaTatCaHocPhan()
        {
            List<Hocphan> lstHocphan = LayHP();
            lstHocphan.Clear();
            return RedirectToAction("HocPhan");
        }

    }
}