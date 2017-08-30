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
    public partial class FrmEmployee : DevExpress.XtraEditors.XtraForm
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("StatusCode", typeof(Int32)));
            dt.Columns.Add(new DataColumn("StatusName", typeof(string)));
            dt.Rows.Add(new object[] { "0", "Nữ" });
            dt.Rows.Add(new object[] { "1", "Nam" });
            ref_status_sex.DataSource = dt;
            ref_status_sex.DisplayMember = "StatusName";
            ref_status_sex.ValueMember = "StatusCode";

            ref_status_position.DataSource = BioBLL.ListEmployeePosition(0);
            ref_status_position.DisplayMember = "PositionName";
            ref_status_position.ValueMember = "PositionCode";

            this.ref_EmployeeGroup.DataSource = BioBLL.ListEmployeeGroup(0);
            this.ref_EmployeeGroup.DisplayMember = "EmployeeGroupName";
            this.ref_EmployeeGroup.ValueMember = "EmployeeGroupID";

            this.gridControl_Employee.DataSource = BioBLL.DTEmployee(string.Empty);
        }

        private void gridView_Employee_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "PowerMED";
            e.ErrorText = "Bạn nhập thiếu thông tin khi thêm nhân viên!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Employee_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_EmployeeName))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeeName, "Họ tên nhân viên không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_EmployeeUsername))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeeUsername, "Tên đăng nhập được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Employee_Sex))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Employee_Sex, "Chưa chọn giới tính!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_EmployeePosition))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeePosition, "Chưa chức danh cho nhân viên!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_EmployeeGroup))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeeGroup, "Chưa nhóm cho nhân viên!");
                }
                if (e.Valid)
                {
                    PSEmployee emp = new PSEmployee();
                    emp.EmployeeCode = gridView_Employee.GetRowCellValue(e.RowHandle, "EmployeeCode").ToString();
                    emp.EmployeeName = gridView_Employee.GetRowCellValue(e.RowHandle, "EmployeeName").ToString();
                    if (gridView_Employee.GetRowCellValue(e.RowHandle, "Sex").ToString() != "")
                        emp.Sex = int.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "Sex").ToString());
                    emp.Mobile = gridView_Employee.GetRowCellValue(e.RowHandle, "Mobile").ToString();
                    emp.IDCard = gridView_Employee.GetRowCellValue(e.RowHandle, "IDCard").ToString();
                    emp.Address = gridView_Employee.GetRowCellValue(e.RowHandle, "Address").ToString();
                    if(!string.IsNullOrEmpty(gridView_Employee.GetRowCellValue(e.RowHandle, "Birthday").ToString()))
                        emp.Birthday = DateTime.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "Birthday").ToString());
                    emp.PositionCode = int.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "PositionCode").ToString());
                    emp.CreateDate = DateTime.Now;
                    emp.Username = gridView_Employee.GetRowCellValue(e.RowHandle, "Username").ToString();
                    emp.EmployeeGroupID = int.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "EmployeeGroupID").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (!BioBLL.CheckExistUser(emp.Username))
                        {
                            XtraMessageBox.Show("Tên đăng nhập đã tồn tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.gridControl_Employee.DataSource = BioBLL.DTEmployee(string.Empty);
                            return;
                        }
                        if (BioBLL.InsEmployee(emp))
                        {
                            XtraMessageBox.Show("Thêm mới nhân viên thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm nhân viên thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        PSEmployee empOld = BioBLL.GetEmployeeByCode(emp.EmployeeCode);
                        if(empOld.Username != emp.Username)
                        {
                            if (!BioBLL.CheckExistUser(emp.Username))
                            {
                                XtraMessageBox.Show("Tên đăng nhập đã tồn tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.gridControl_Employee.DataSource = BioBLL.DTEmployee(string.Empty);
                                return;
                            }
                        }
                        if (BioBLL.UpdEmployee(emp))
                        {
                            XtraMessageBox.Show("Cập nhật nhân viên thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật nhân viên thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_Employee.DataSource = BioBLL.DTEmployee(string.Empty);
                }
            }
            catch
            {
                XtraMessageBox.Show("Thao tác thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl_Employee_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Employee.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa nhân viên này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (BioBLL.DelEmployee(gridView_Employee.GetRowCellValue(gridView_Employee.FocusedRowHandle, "EmployeeCode").ToString()))
                            gridControl_Employee.DataSource = BioBLL.DTEmployee(string.Empty);
                    }
                    catch { return; }
                }
            }
        }

        private void gridView_Employee_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column.FieldName == "Password")
            {
                if (XtraMessageBox.Show("Bạn có muốn thay đổi mật khẩu về mặc định không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        string empCode = gridView_Employee.GetRowCellValue(gridView_Employee.FocusedRowHandle, "EmployeeCode").ToString();
                        if(BioBLL.UpdPassEmployee(empCode,string.Empty))
                            XtraMessageBox.Show("Cập nhật mật khẩu nhân viên thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Cập nhật mật khẩu nhân viên thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch { return; }
                }
            }
        }
    }
}