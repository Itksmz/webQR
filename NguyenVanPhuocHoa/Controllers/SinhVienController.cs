using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenVanPhuocHoa.Models;
namespace NguyenVanPhuocHoa.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        
            MyDBDataContext data = new MyDBDataContext();
            public ActionResult ListSV()
            {
                var all_sv = from ss in data.SinhViens select ss;
                return View(all_sv);
            }
            public ActionResult Detail(string id)
            {
                var D_sach = data.SinhViens.Where(m => m.MaSV == id).First();
                return View(D_sach);
            }
            public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Create(FormCollection collection, SinhVien s)
            {
                var E_tensinhvien = collection["HoTen"];
                var E_gioitinh = collection["gioitinh"];
                var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
                var E_hinh = collection["hinh"];
                var E_manganh = collection["manganh"];
                if (string.IsNullOrEmpty(E_tensinhvien))
                {
                    ViewData["Error"] = "Don't empty!";
                }
                else
                {
                    s.HoTen = E_tensinhvien.ToString();
                    s.Hinh = E_hinh.ToString();
                    s.GioiTinh = E_gioitinh;
                    s.NgaySinh = E_ngaysinh;
                    s.MaNganh = E_manganh;
                    data.SinhViens.InsertOnSubmit(s);
                    data.SubmitChanges();
                    return RedirectToAction("ListSV");
                }
                return this.Create();
            }
            public ActionResult Edit(string id)
            {
                var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
                return View(E_sinhvien);
            }
            [HttpPost]
            public ActionResult Edit(string id, FormCollection collection)
            {
                var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
                var E_tensinhvien = collection["HoTen"];
                var E_gioitinh = collection["gioitinh"];
                var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
                var E_hinh = collection["hinh"];
                var E_manganh = collection["manganh"];
                E_sinhvien.MaSV = id;
                if (string.IsNullOrEmpty(E_tensinhvien))
                {
                    ViewData["Error"] = "Don't empty!";
                }
                else
                {
                    E_sinhvien.HoTen = E_tensinhvien;
                    E_sinhvien.GioiTinh = E_gioitinh;
                    E_sinhvien.NgaySinh = E_ngaysinh;
                    E_sinhvien.Hinh = E_hinh;
                    E_sinhvien.MaNganh = E_manganh;
                    UpdateModel(E_sinhvien);
                    data.SubmitChanges();
                    return RedirectToAction("ListSV");
                }
                return this.Edit(id);
            }
            //-----------------------------------------
            public ActionResult Delete(String id)
            {
                var D_sv = data.SinhViens.First(m => m.MaSV == id);
                return View(D_sv);
            }
            [HttpPost]
            public ActionResult Delete(string id, FormCollection collection)
            {
                var D_sv = data.SinhViens.Where(m => m.MaSV == id).First();
                data.SinhViens.DeleteOnSubmit(D_sv);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            public string ProcessUpload(HttpPostedFileBase file)
            {
                if (file == null)
                {
                    return "";
                }
                file.SaveAs(Server.MapPath("~/Content/Images/" + file.FileName));
                return "/Content/Images/" + file.FileName;
            }
        
    }
}