using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetBLL;
using DevExpress.XtraSplashScreen;
using BioNetModel;
using DevExpress.XtraGrid.Views.Grid;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmSuaPhieuLoi : DevExpress.XtraEditors.XtraForm
    {
        public FrmSuaPhieuLoi()
        {
            InitializeComponent();
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            this.GC_DSPhieu.DataSource = BioNet_Bus.GetTTPhieuCanSuaLoi(this.dateNgayBD.DateTime, this.dateNgayKetThuc.DateTime, this.txtDonVi.EditValue.ToString(), this.txtMaPhieu.Text.Trim());
            if (this.GV_DSPhieu.DataRowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu phiếu kết quả cần tìm", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                this.btnChon.Enabled = false;
            }
            else
            {
                this.btnChon.Enabled = true;
            }
        }

        private void FrmSuaPhieuLoi_Load(object sender, EventArgs e)
        {
            this.FormLoad();
        }
        private void FormLoad()
        {
            this.txtChiCuc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChiCuc();
            this.txtDonVi.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi("all");
            this.txtDonVi.EditValue = "all";
            this.dateNgayBD.EditValue = DateTime.Now;
            this.dateNgayKetThuc.EditValue = DateTime.Now;
            this.btnTimKiem.Enabled = true;
            this.btnChon.Enabled = false;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            SuaPhieu();
        }
        private void SuaPhieu()
        {

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn là sữa các phiếu đã chọn", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    List<PsTinhTrangPhieu> dt = (List<PsTinhTrangPhieu>)GC_DSPhieu.DataSource;
                    
                    DataTable dtselect = new DataTable();
                    PsReponse res = new PsReponse();
                    List<string> maphieu=new List<string>();
                    string maPhieu;
                    int chon = 0;
                    for (int i = 0; i < dt.Count; i++)
                    {
                        int kt = 0;
                        if (dt[i].Chon == 1)
                        {
                            chon = chon + 1;
                            maPhieu = dt[i].IDPhieu.ToString();
                            maphieu.Add(maPhieu);
                        }

                    }

                    if(chon==0)
                    {
                          MessageBox.Show("Vui lòng tick vào phiếu cần sữa lỗi", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK); 
                    }
                    else
                    {
                        res=BioNet_Bus.UpdatePhieuSuaLoi(maphieu);
                        if(res.Result)
                        {
                            MessageBox.Show("Phiếu đã chuyển về tình trạng chưa duyệt kết quả", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                            this.FormLoad();
                        }
                        else
                        {
                            MessageBox.Show("Sữa phiếu bị lỗi", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                        }
                    }

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sữa phiếu bị lỗi", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                }

            }
            else if (dialogResult == DialogResult.No) { return; }
        }

        private void GV_DSPhieu_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView Viewer = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string category = Viewer.GetRowCellValue(e.RowHandle, Viewer.Columns["TinhTrangMau"]).ToString();
                    int trangthai = 0;
                    try
                    {
                        trangthai = int.Parse(category);
                    }
                    catch { }


                    switch (trangthai)
                    {
                        case 1:

                            e.Appearance.BackColor = Color.DeepSkyBlue;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 2:
                            e.Appearance.BackColor = Color.Wheat;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 3:
                            e.Appearance.BackColor = Color.LightCoral;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            break;
                        case 4:
                            e.Appearance.BackColor = Color.Violet;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 5:
                            e.Appearance.BackColor = Color.LightYellow;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 6:
                            e.Appearance.BackColor = Color.OrangeRed;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 7:
                            e.Appearance.BackColor = Color.LightCoral;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                    }

                }


            }
            catch
            {

            }
            
        }
    }
}