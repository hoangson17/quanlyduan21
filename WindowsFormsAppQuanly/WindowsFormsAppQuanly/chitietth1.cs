using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class chitietth1
    {
        private string mamh;
        private int soluongtra;
        private int gianhap;
        private int tongtientra;
        private string sopt;

        public chitietth1()
        {
        }

        public chitietth1(string mamh, int soluongtra, int gianhap, int tongtientra, string sopt)
        {
            this.mamh = mamh;
            this.soluongtra = soluongtra;
            this.gianhap = gianhap;
            this.tongtientra = tongtientra;
            this.sopt = sopt;
        }

        public string Mamh { get => mamh; set => mamh = value; }
        public int Soluongtra { get => soluongtra; set => soluongtra = value; }
        public int Gianhap { get => gianhap; set => gianhap = value; }
        public int Tongtientra { get => tongtientra; set => tongtientra = value; }
        public string Sopt { get => sopt; set => sopt = value; }
    }
}
