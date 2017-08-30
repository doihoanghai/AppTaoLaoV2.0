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

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmDMNhomNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMNhomNhanVien()
        {
            InitializeComponent();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("StatusCode", typeof(Int32)));
            //dt.Columns.Add(new DataColumn("StatusName", typeof(string)));
            //dt.Rows.Add(new object[] { "0", "Nữ" });
            //dt.Rows.Add(new object[] { "1", "Nam" });
            //ref_status_sex.DataSource = dt;
            //ref_status_sex.DisplayMember = "StatusName";
            //ref_status_sex.ValueMember = "StatusCode";

            //ref_status_position.DataSource = BioBLL.ListEmployeePosition(0);
            //ref_status_position.DisplayMember = "PositionName";
            //ref_status_position.ValueMember = "PositionCode";

            //this.ref_EmployeeGroup.DataSource = BioBLL.ListEmployeeGroup(0);
            //this.ref_EmployeeGroup.DisplayMember = "EmployeeGroupName";
            //this.ref_EmployeeGroup.ValueMember = "EmployeeGroupID";

            this.gridControl_Employee.DataSource = BioBLL.DTEmployeePosition();
        }

        private void gridView_Employee_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "BioNet Sàng lọc sơ sinh";
            e.ErrorText = "Bạn nhập thiếu thông tin khi thêm chức danh!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Employee_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_EmployeePosition))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeePosition, "Không được để trống chức danh!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Level))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Level, "Không được để trống cấp bậc");
                }
                
                if (e.Valid)
                {
                    PSEmployeePosition emp = new PSEmployeePosition();
                    emp.PositionName = gridView_Employee.GetRowCellValue(e.RowHandle, "PositionName").ToString();
                    try
                    {
                        emp.PositionCode = Convert.ToInt32((gridView_Employee.GetRowCellValue(e.RowHandle, "PositionCode") ?? "0").ToString());
                    }
                   catch
                    { emp.PositionCode = 0; }
                    emp.Level = Convert.ToInt32(gridView_Employee.GetRowCellValue(e.RowHandle, "Level") ?? "0");
                    if (e.RowHandle < 0)
                    {
                        if (!BioBLL.CheckExistPosition(emp.PositionName,emp.PositionCode))
                        {
                            XtraMessageBox.Show("Tên chức danh đã tồn tại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.gridControl_Employee.DataSource = BioBLL.DTEmployeePosition();
                            return;
                        }
                        if (BioBLL.InsEmployeePosition(emp))
                        {
                            XtraMessageBox.Show("Thêm mới chức danh thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm chức danh thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        PSEmployeePosition empOld = BioBLL.GetPositionByCode(emp.PositionCode);
                        if(empOld.PositionName != emp.PositionName)
                        {
                            if (!BioBLL.CheckExistPosition (emp.PositionName,emp.PositionCode))
                            {
                                XtraMessageBox.Show("Tên chức danh đã tồn tại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.gridControl_Employee.DataSource = BioBLL.DTEmployeePosition();
                                return;
                            }
                        }
                        if (BioBLL.updEmployeePosition(emp))
                        {
                            XtraMessageBox.Show("Cập nhật chức danh thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật chức danh thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_Employee.DataSource = BioBLL.DTEmployeePosition();
                }
            }
            catch
            {
                XtraMessageBox.Show("Thao tác thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl_Employee_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Employee.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa chức danh này hay không?", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (BioBLL.DelEmployeePosition(Convert.ToInt32( gridView_Employee.GetRowCellValue(gridView_Employee.FocusedRowHandle, "PositionCode").ToString())))
                            gridControl_Employee.DataSource = BioBLL.DTEmployeePosition();
                        else { XtraMessageBox.Show("Không thể xóa chức danh này!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Information); }
                    }
                    catch {
                        XtraMessageBox.Show("Lỗi khi xóa chức danh này!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        return; }
                }
            }
        }

       
        
    }
}