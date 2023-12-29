using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class chitietnh1
    {
        private string mamh;
        private int soluongnhap;
        private int gianhap;
        private int tongtien;
        private string sopn;

        public chitietnh1()
        {
        }

        public chitietnh1(string mamh, int soluongnhap, int gianhap, int tongtien, string sopn)
        {
            this.mamh = mamh;
            this.soluongnhap = soluongnhap;
            this.gianhap = gianhap;
            this.tongtien = tongtien;
            this.sopn = sopn;
        }

        public string Mamh { get => mamh; set => mamh = value; }
        public int Soluongnhap { get => soluongnhap; set => soluongnhap = value; }
        public int Gianhap { get => gianhap; set => gianhap = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public string Sopn { get => sopn; set => sopn = value; }
    }
}
