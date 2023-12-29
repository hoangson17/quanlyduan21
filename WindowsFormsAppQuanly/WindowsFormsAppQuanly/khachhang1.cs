using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class khachhang1
    {
        private string makh;
        private string tenkh;
        private string diachi;
        private string sodt;
        private string ghichu;

        public khachhang1()
        {
        }

        public khachhang1(string makh, string tenkh, string diachi, string sodt, string ghichu)
        {
            this.makh = makh;
            this.tenkh = tenkh;
            this.diachi = diachi;
            this.sodt = sodt;
            this.ghichu = ghichu;
        }

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sodt { get => sodt; set => sodt = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
    }
}
