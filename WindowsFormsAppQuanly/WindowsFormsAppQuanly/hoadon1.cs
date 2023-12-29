using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class hoadon1
    {
        private string sohd;
        private DateTime ngayban;
        private string httt;
        private string manv;
        private string makh;

        public hoadon1()
        {
        }

        public hoadon1(string sohd, DateTime ngayban, string httt, string manv, string makh)
        {
            this.sohd = sohd;
            this.ngayban = ngayban;
            this.httt = httt;
            this.manv = manv;
            this.makh = makh;
        }

        public string Sohd { get => sohd; set => sohd = value; }
        public DateTime Ngayban { get => ngayban; set => ngayban = value; }
        public string Httt { get => httt; set => httt = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Makh { get => makh; set => makh = value; }
    }
}
