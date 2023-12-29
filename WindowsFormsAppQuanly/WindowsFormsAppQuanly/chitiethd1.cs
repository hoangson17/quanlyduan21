using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class chitiethd1
    {
        private string mamh;
        private int soluongban;
        private int dongia;
        private int tongtien;
        private string sohd;

        public chitiethd1()
        {
        }

        public chitiethd1(string mamh, int soluongban, int dongia, int tongtien, string sohd)
        {
            this.mamh = mamh;
            this.soluongban = soluongban;
            this.dongia = dongia;
            this.tongtien = tongtien;
            this.sohd = sohd;
        }

        public string Mamh { get => mamh; set => mamh = value; }
        public int Soluongban { get => soluongban; set => soluongban = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public string Sohd { get => sohd; set => sohd = value; }
    }
}
