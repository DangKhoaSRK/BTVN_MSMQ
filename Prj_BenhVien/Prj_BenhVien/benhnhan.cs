using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_BenhVien
{
    [Serializable]
    public class benhnhan
    {
        public benhnhan(string maso, string cmnd, string hoten, string diachi)
        {
            this.maso = maso;
            this.cmnd = cmnd;
            this.hoten = hoten;
            this.diachi = diachi;
        }
        public benhnhan() { }
        public string maso { get; set; }
        public string cmnd { get; set; }
        public string hoten { get; set; }
        public string diachi { get; set; }
    }
}

