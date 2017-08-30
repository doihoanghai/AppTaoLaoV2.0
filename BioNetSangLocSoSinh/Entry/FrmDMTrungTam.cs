using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetBLL;
using DevExpress.XtraGrid.Views.Grid;
using BioNetModel.Data;
using System.IO;
using System.Data.Linq;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmDMTrungTam : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMTrungTam()
        {
            InitializeComponent();
        }

        private void FrmDMTrungTam_Load(object sender, EventArgs e)
        {
            gridControl_Trungtam.DataSource = BioBLL.GetListTrungTam();

        }

        private void gridView_Trungtam_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_TenTrungTam))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_TenTrungTam, "Tên trung tâm không được để trống!");
                }
                if (e.Valid)
                {
                    byte[] byteNull = ASCIIEncoding.ASCII.GetBytes("");
                    PSThongTinTrungTam trungTam = new PSThongTinTrungTam();
                    trungTam.MaTrungTam = gridView_Trungtam.GetRowCellValue(e.RowHandle, "MaTrungTam").ToString();
                    trungTam.TenTrungTam = gridView_Trungtam.GetRowCellValue(e.RowHandle, "TenTrungTam").ToString();
                    trungTam.Diachi = gridView_Trungtam.GetRowCellValue(e.RowHandle, "Diachi").ToString();
                    trungTam.DienThoai = gridView_Trungtam.GetRowCellValue(e.RowHandle, "DienThoai").ToString();
                    if (string.IsNullOrEmpty(gridView_Trungtam.GetRowCellValue(e.RowHandle, "Logo").ToString()))
                        trungTam.Logo = new Binary(byteNull);
                    else
                        trungTam.Logo = (Binary)gridView_Trungtam.GetRowCellValue(e.RowHandle, "Logo");
                    trungTam.MaVietTat = gridView_Trungtam.GetRowCellValue(e.RowHandle, "MaVietTat").ToString();
                    if (e.RowHandle >= 0)
                    {
                        if (BioBLL.UpdTrungTam(trungTam))
                        {
                            XtraMessageBox.Show("Cập nhật trung tâm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật trung tâm thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_Trungtam.DataSource = BioBLL.GetListTrungTam();
                }
            }
            catch { XtraMessageBox.Show("Thao tác thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void fileLogo_FileOk(object sender, CancelEventArgs e)
        {
            try
            {

                var fileBytes = File.ReadAllBytes(fileLogo.FileName);
                var image = new Binary(fileBytes);
                gridView_Trungtam.SetFocusedRowCellValue(col_th_Logo, image);
            }
            catch { }
        }

        private void repositoryItemPictureEdit_logo_Click(object sender, EventArgs e)
        {
            fileLogo.ShowHelp = true;
            fileLogo.FileName = string.Empty;
            fileLogo.Filter = "Images (*.jpg)|*.jpg|All Files(*.*)|*.*";
            fileLogo.ShowDialog();
        }
    }
}