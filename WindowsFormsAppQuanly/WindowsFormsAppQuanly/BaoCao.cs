using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsAppQuanly
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                // Window/c/
                reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsAppQuanly.Report1.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = modify.getAllChitiethd();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
