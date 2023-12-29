using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class nhacc1
    {
        private string maNCC;
        private string tenNCC;
        private string diachiNCC;
        private string sdt;
        private string ghichu;

        public nhacc1()
        {
        }

        public nhacc1(string maNCC, string tenNCC, string diachiNCC, string sdt, string ghichu)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.diachiNCC = diachiNCC;
            this.sdt = sdt;
            this.ghichu = ghichu;
        }

        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiachiNCC { get => diachiNCC; set => diachiNCC = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
    }
}
