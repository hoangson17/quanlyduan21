using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class hang1
    {
        private string mamh;
        private string tenmh;
        private string mau;
        private string size;
        private string hsx;
        private int soluong;
        private int dongia;

        public hang1()
        {
        }

        public hang1(string mamh, string tenmh, string mau, string size, string hsx, int soluong, int dongia)
        {
            this.mamh = mamh;
            this.tenmh = tenmh;
            this.mau = mau;
            this.size = size;
            this.hsx = hsx;
            this.soluong = soluong;
            this.dongia = dongia;
        }

        public string Mamh { get => mamh; set => mamh = value; }
        public string Tenmh { get => tenmh; set => tenmh = value; }
        public string Mau { get => mau; set => mau = value; }
        public string Size { get => size; set => size = value; }
        public string Hsx { get => hsx; set => hsx = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Dongia { get => dongia; set => dongia = value; }
    }

}
