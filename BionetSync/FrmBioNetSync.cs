using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataSync;
using BioNetModel;
using BioNetModel.Data;
namespace BionetSync
{
    public partial class FrmBioNetSync : DevExpress.XtraEditors.XtraForm
    {
        public FrmBioNetSync()
        {
            InitializeComponent();
        }
        private void downloadDanhMuc()
        {
            //List<BioNetModel.PsReponse> listerror = new List<PsReponse>();
            //PsReponse dichvu = DataSync.ProcessDataSync.GetDMDichVu();
            //PsReponse chuongtrinh = DataSync.ProcessDataSync.GetDanhChuongTrinh();
            //PsReponse v = DataSync.ProcessDataSync.GetDMDanhGiaChatLuongMau();
            //PsReponse b = DataSync.ProcessDataSync.GetDMGoiDichVuChung();
            //if (!dichvu.Result)
            //    listerror.Add(dichvu);
            //if (!chuongtrinh.Result)
            //    listerror.Add(chuongtrinh);
            //if (!chuongtrinh.Result)
            //    listerror.Add(chuongtrinh);
                
        }
        private void DownLoadDanhMucGoiDichVuChung()
        {
            
        }

        private void FrmBioNetSync_Load(object sender, EventArgs e)
        {
            this.downloadDanhMuc();
        }
    }
}