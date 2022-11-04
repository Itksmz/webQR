using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NguyenVanPhuocHoa.Models
{
    public class Hocphan
    {
        MyDBDataContext data = new MyDBDataContext();
        public string mahp { get; set; }

        [Display(Name = "Tên học phần")]
        public string tenhp { get; set; }

        [Display(Name = "Số tín chỉ")]
        public int istc { get; set; }

        public Hocphan(string id)
        {
            mahp = id;
            HocPhan hp = data.HocPhans.Single(n => n.MaHP == mahp);
            tenhp = hp.TenHP;
            istc = 1;
        }
    }
}