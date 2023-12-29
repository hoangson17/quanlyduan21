using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class nhaphang1
    {
        private string sopn;
        private DateTime ngaynhap;
        private string httt;
        private string manv;
        private string mancc;

        public nhaphang1()
        {
        }

        public nhaphang1(string sopn, DateTime ngaynhap, string httt, string manv, string mancc)
        {
            this.sopn = sopn;
            this.ngaynhap = ngaynhap;
            this.httt = httt;
            this.manv = manv;
            this.mancc = mancc;
        }

        public string Sopn { get => sopn; set => sopn = value; }
        public DateTime Ngaynhap { get => ngaynhap; set => ngaynhap = value; }
        public string Httt { get => httt; set => httt = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Mancc { get => mancc; set => mancc = value; }
    }
}
