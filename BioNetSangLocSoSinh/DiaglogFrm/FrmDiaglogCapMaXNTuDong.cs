using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetModel;
using BioNetModel.Data;
using BioNetBLL;
using DevExpress.XtraGrid.Views.Grid;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmDiaglogCapMaXNTuDong : DevExpress.XtraEditors.XtraForm
    {

        public FrmDiaglogCapMaXNTuDong()
        {
            InitializeComponent();
        }
        public List<PsDanhSachCapMa> lstCapMaTheoDonVi = new List<PsDanhSachCapMa>();
        public List<PsDanhSachCapMa> lstDataGC = new List<PsDanhSachCapMa>();
        public List<string> lstDonViCanCapMa = new List<string>();
        private List<PSDanhMucDonViCoSo> lstDonVi = new List<PSDanhMucDonViCoSo>();
        private string maDonViHandle = string.Empty;

        private void LoadDanhSachDonVi()
        {
            var lst = BioNet_Bus.GetDanhSachDonViCoSo();
            if (lst != null) this.lstDonVi = lst;
        }
        private void LoadDuLieuRepositoryLookupDonVi()
        {
            this.LoadDanhSachDonVi();
            if (this.lstDonViCanCapMa.Count > 0 && this.lstCapMaTheoDonVi.Count > 0)
            {
                List<PSDanhMucDonViCoSo> lst = new List<PSDanhMucDonViCoSo>();
                foreach (var item in this.lstDonViCanCapMa)
                {
                    var it = this.lstDonVi.FirstOrDefault(p => p.MaDVCS == item.ToString());
                    if (it != null)
                        lst.Add(it);
                }
                lstDonVi = lst;
            }
        }
        private void LoadDuLieuLstDataGC()
        {
            this.lstDataGC.Clear();
            foreach(var item in this.lstCapMaTheoDonVi)
            {
                PsDanhSachCapMa cm = new PsDanhSachCapMa();
                cm.maDonVi = item.maDonVi;
                cm.soBatDau = item.soBatDau;
                cm.soKetThuc = item.soKetThuc;
                cm.soLuong = item.soLuong;
                this.lstDataGC.Add(cm);
            }
        }
        private void FrmDiaglogCapMaXNTuDong_Load(object sender, EventArgs e)
        {
            this.LoadDuLieuRepositoryLookupDonVi();
            this.lookupDonVi.DataSource = this.lstDonVi.Select(p => new { p.MaDVCS, p.TenDVCS }).ToList();
            this.LoadDuLieuLstDataGC();
            this.GCCapMa.DataSource = this.lstDataGC;
        }

        private void GVCapMa_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //GridView view = sender as GridView;
            //var rowHandle = e.RowHandle;
            //if (rowHandle >= 0)
            //{
            //    try
            //    {
            //        var maDonvi = view.GetRowCellValue(rowHandle, this.col_MaDonVi);
            //        int sLuong = view.GetRowCellValue(rowHandle, this.col_SoLuong) == null ? 1 : int.Parse(view.GetRowCellValue(rowHandle, this.col_SoLuong).ToString());
            //        var GtriBatDau = view.GetRowCellValue(rowHandle, this.col_MaBatDau) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_MaBatDau).ToString();
            //        var GtriKetThuc = view.GetRowCellValue(rowHandle, this.col_MaKetThuc) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_MaKetThuc).ToString();
            //        if (string.IsNullOrEmpty(GtriKetThuc))
            //        {
            //            if (rowHandle == 0)
            //            {
            //                int GtriKT = int.Parse(GtriBatDau) + sLuong - 1;
            //                view.SetRowCellValue(rowHandle, this.col_MaKetThuc, GtriKT);
            //            }
            //            else
            //            {
            //                int GTKTTruoc = view.GetRowCellValue(rowHandle - 1, this.col_MaKetThuc) == null ? 1 : int.Parse(view.GetRowCellValue(rowHandle - 1, this.col_MaKetThuc).ToString());
            //               // view.SetRowCellValue(rowHandle, this.col_MaBatDau, GTKTTruoc + 1);
            //            }
            //        }
            //    }
            //    catch { }
            //}
        }
        void OnLocateByValueCompleted(object arguments)
        {
            this.GVCapMa.FocusedRowHandle = Convert.ToInt32(arguments);
        }
        private void GVCapMa_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                var columnHandle = e.Column.ColumnHandle;
                var rowHandle = e.RowHandle;
                var maDonvi = view.GetRowCellValue(rowHandle, this.col_MaDonVi);
                int sLuong = view.GetRowCellValue(rowHandle, this.col_SoLuong) == null ? 1 : int.Parse(view.GetRowCellValue(rowHandle, this.col_SoLuong).ToString());
                var GtriBatDau = view.GetRowCellValue(rowHandle, this.col_MaBatDau) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_MaBatDau).ToString();
                var GtriKetThuc = view.GetRowCellValue(rowHandle, this.col_MaKetThuc) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_MaKetThuc).ToString();
                if (rowHandle < view.RowCount)
                {
                    if (columnHandle == this.col_MaDonVi.ColumnHandle)
                    {
                        var rs = this.lstCapMaTheoDonVi.FirstOrDefault(p => p.maDonVi == maDonvi.ToString());
                        var valueOld = view.ActiveEditor.OldEditValue;
                        if (rs != null)
                        {
                            if (!string.IsNullOrEmpty(valueOld.ToString()))
                            {
                                for (int i = 0; i < view.RowCount; i++)
                                {
                                    if (view.GetRowCellValue(i, this.col_MaDonVi).Equals(maDonvi) && !i.Equals(rowHandle))
                                    {
                                        view.SetRowCellValue(i, this.col_MaDonVi, valueOld.ToString());
                                        break;
                                    }
                                }
                            }
                            if (!sLuong.Equals(rs.soLuong)) view.SetRowCellValue(rowHandle, this.col_SoLuong, rs.soLuong);
                        }
                    }
                    if (columnHandle == this.col_SoLuong.ColumnHandle)
                    {
                        int gtkt = int.Parse(GtriBatDau) + sLuong;
                        if (!gtkt.Equals(GtriKetThuc))
                        {
                            view.SetRowCellValue(rowHandle, this.col_MaKetThuc, gtkt - 1);
                        }
                    }
                    if (columnHandle == this.col_MaKetThuc.ColumnHandle)
                    {
                        try
                        {
                            int gtBDSau = view.GetRowCellValue(rowHandle + 1, this.col_MaBatDau) == null ? 0 : int.Parse(view.GetRowCellValue(rowHandle + 1, this.col_MaBatDau).ToString());
                            if (!gtBDSau.Equals(int.Parse(GtriKetThuc) + 1))
                            {
                                view.SetRowCellValue(rowHandle + 1, this.col_MaBatDau, int.Parse(GtriKetThuc) + 1);
                            }
                        }
                        catch { }
                    }
                    if (columnHandle == this.col_MaBatDau.ColumnHandle)
                    {
                        int sl = (int.Parse(GtriKetThuc.ToString()) - int.Parse(GtriBatDau.ToString())) + 1;
                        if (!sLuong.Equals(sl))
                            view.SetRowCellValue(rowHandle, this.col_MaKetThuc, int.Parse(GtriBatDau) + sLuong - 1);
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Vui lòng thao tác chậm lại để tránh sung đột \r\n"+ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            PsReponse res = new PsReponse();
            res.Result = true;
            for (int i = 0; i < this.GVCapMa.RowCount; i++)
            {
                var maDonvi = this.GVCapMa.GetRowCellValue(i, this.col_MaDonVi);
                var GtriBatDau = this.GVCapMa.GetRowCellValue(i, this.col_MaBatDau) == null ? string.Empty : this.GVCapMa.GetRowCellValue(i, this.col_MaBatDau).ToString();
                var GtriKetThuc = this.GVCapMa.GetRowCellValue(i, this.col_MaKetThuc) == null ? string.Empty : this.GVCapMa.GetRowCellValue(i, this.col_MaKetThuc).ToString();
                res=KiemTraMaXN(GtriBatDau, GtriKetThuc);
                if(res.Result==false)
                {
                    XtraMessageBox.Show(res.StringError??"Lỗi nhập mã phiếu không chính xác", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else
                {
                    var dv = this.lstCapMaTheoDonVi.FirstOrDefault(p => p.maDonVi == maDonvi.ToString());
                    if (dv != null)
                    {
                        dv.soBatDau = int.Parse(GtriBatDau);
                        dv.soKetThuc = int.Parse(GtriKetThuc);
                    }
                }
               

            }
            if(res.Result==true)
            {
                
                this.DialogResult = DialogResult.OK;
               
                this.Close();
            }

         

        }
        private PsReponse KiemTraMaXN(string GTriBatDau,string GTriKetThuc)
        {
            PsReponse res = new PsReponse();
            try
            {
                for (int i = int.Parse(GTriBatDau); i <=int.Parse(GTriKetThuc); i++)
                {
                    res = BioNet_Bus.KiemTraMaXN(i.ToString());
                    if (res.Result == false)
                    {
                        break;
                    }
                }
            }
            catch
            {
                res.Result = false;

            }
            return res;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}