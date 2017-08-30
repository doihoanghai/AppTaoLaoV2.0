namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl_Employee = new DevExpress.XtraGrid.GridControl();
            this.gridView_Employee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Employee_Sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_status_sex = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_EmployeeMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeIDCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeBirthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_status_position = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_EmployeeUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeePass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_OffWork = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_EmployeeGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_EmployeeGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ref_Department = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemButtonEdit_Pass = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_sex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_OffWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_EmployeeGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Department)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Pass)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Employee
            // 
            this.gridControl_Employee.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Employee.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Employee.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Employee.MainView = this.gridView_Employee;
            this.gridControl_Employee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Employee.Name = "gridControl_Employee";
            this.gridControl_Employee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_status_sex,
            this.ref_status_position,
            this.ref_OffWork,
            this.ref_Department,
            this.ref_EmployeeGroup,
            this.repositoryItemButtonEdit_Pass});
            this.gridControl_Employee.Size = new System.Drawing.Size(1268, 516);
            this.gridControl_Employee.TabIndex = 2;
            this.gridControl_Employee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Employee});
            this.gridControl_Employee.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Employee_ProcessGridKey);
            // 
            // gridView_Employee
            // 
            this.gridView_Employee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_EmployeeCode,
            this.col_EmployeeName,
            this.col_Employee_Sex,
            this.col_EmployeeMobile,
            this.col_EmployeeIDCard,
            this.col_EmployeeAddress,
            this.col_EmployeeBirthday,
            this.col_EmployeePosition,
            this.col_EmployeeUsername,
            this.col_EmployeePass,
            this.col_EmployeeGroup});
            this.gridView_Employee.GridControl = this.gridControl_Employee;
            this.gridView_Employee.Name = "gridView_Employee";
            this.gridView_Employee.NewItemRowText = "Thêm mới nhân viên sử dụng phần mềm";
            this.gridView_Employee.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Employee.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Employee.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Employee.OptionsView.ShowGroupPanel = false;
            this.gridView_Employee.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_Employee_RowCellClick);
            this.gridView_Employee.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Employee_InvalidRowException);
            this.gridView_Employee.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Employee_ValidateRow);
            // 
            // col_EmployeeCode
            // 
            this.col_EmployeeCode.Caption = "Mã nv";
            this.col_EmployeeCode.FieldName = "EmployeeCode";
            this.col_EmployeeCode.Name = "col_EmployeeCode";
            this.col_EmployeeCode.OptionsColumn.AllowEdit = false;
            this.col_EmployeeCode.OptionsColumn.AllowFocus = false;
            this.col_EmployeeCode.OptionsColumn.ReadOnly = true;
            // 
            // col_EmployeeName
            // 
            this.col_EmployeeName.Caption = "Họ tên";
            this.col_EmployeeName.FieldName = "EmployeeName";
            this.col_EmployeeName.Name = "col_EmployeeName";
            this.col_EmployeeName.Visible = true;
            this.col_EmployeeName.VisibleIndex = 0;
            this.col_EmployeeName.Width = 150;
            // 
            // col_Employee_Sex
            // 
            this.col_Employee_Sex.AppearanceCell.Options.UseTextOptions = true;
            this.col_Employee_Sex.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Employee_Sex.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Employee_Sex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Employee_Sex.Caption = "Giới tính";
            this.col_Employee_Sex.ColumnEdit = this.ref_status_sex;
            this.col_Employee_Sex.FieldName = "Sex";
            this.col_Employee_Sex.Name = "col_Employee_Sex";
            this.col_Employee_Sex.Visible = true;
            this.col_Employee_Sex.VisibleIndex = 1;
            this.col_Employee_Sex.Width = 47;
            // 
            // ref_status_sex
            // 
            this.ref_status_sex.AutoHeight = false;
            this.ref_status_sex.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_status_sex.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusCode", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusName", "Nội dung")});
            this.ref_status_sex.Name = "ref_status_sex";
            this.ref_status_sex.NullText = "...";
            // 
            // col_EmployeeMobile
            // 
            this.col_EmployeeMobile.Caption = "Điện thoại";
            this.col_EmployeeMobile.FieldName = "Mobile";
            this.col_EmployeeMobile.Name = "col_EmployeeMobile";
            this.col_EmployeeMobile.Visible = true;
            this.col_EmployeeMobile.VisibleIndex = 2;
            this.col_EmployeeMobile.Width = 67;
            // 
            // col_EmployeeIDCard
            // 
            this.col_EmployeeIDCard.Caption = "TAX/CMND";
            this.col_EmployeeIDCard.FieldName = "IDCard";
            this.col_EmployeeIDCard.Name = "col_EmployeeIDCard";
            this.col_EmployeeIDCard.Visible = true;
            this.col_EmployeeIDCard.VisibleIndex = 3;
            this.col_EmployeeIDCard.Width = 67;
            // 
            // col_EmployeeAddress
            // 
            this.col_EmployeeAddress.Caption = "Địa chỉ";
            this.col_EmployeeAddress.FieldName = "Address";
            this.col_EmployeeAddress.Name = "col_EmployeeAddress";
            this.col_EmployeeAddress.Visible = true;
            this.col_EmployeeAddress.VisibleIndex = 4;
            this.col_EmployeeAddress.Width = 67;
            // 
            // col_EmployeeBirthday
            // 
            this.col_EmployeeBirthday.AppearanceCell.Options.UseTextOptions = true;
            this.col_EmployeeBirthday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeeBirthday.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmployeeBirthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeeBirthday.Caption = "Ngày sinh";
            this.col_EmployeeBirthday.FieldName = "Birthday";
            this.col_EmployeeBirthday.Name = "col_EmployeeBirthday";
            this.col_EmployeeBirthday.Visible = true;
            this.col_EmployeeBirthday.VisibleIndex = 5;
            this.col_EmployeeBirthday.Width = 67;
            // 
            // col_EmployeePosition
            // 
            this.col_EmployeePosition.AppearanceCell.Options.UseTextOptions = true;
            this.col_EmployeePosition.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeePosition.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmployeePosition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeePosition.Caption = "Chức danh";
            this.col_EmployeePosition.ColumnEdit = this.ref_status_position;
            this.col_EmployeePosition.FieldName = "PositionCode";
            this.col_EmployeePosition.Name = "col_EmployeePosition";
            this.col_EmployeePosition.Visible = true;
            this.col_EmployeePosition.VisibleIndex = 6;
            this.col_EmployeePosition.Width = 67;
            // 
            // ref_status_position
            // 
            this.ref_status_position.AutoHeight = false;
            this.ref_status_position.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_status_position.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionCode", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionName", "Vị trí")});
            this.ref_status_position.Name = "ref_status_position";
            this.ref_status_position.NullText = "...";
            // 
            // col_EmployeeUsername
            // 
            this.col_EmployeeUsername.AppearanceCell.Options.UseTextOptions = true;
            this.col_EmployeeUsername.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_EmployeeUsername.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmployeeUsername.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeeUsername.Caption = "Tên đăng nhập";
            this.col_EmployeeUsername.FieldName = "Username";
            this.col_EmployeeUsername.Name = "col_EmployeeUsername";
            this.col_EmployeeUsername.Visible = true;
            this.col_EmployeeUsername.VisibleIndex = 7;
            this.col_EmployeeUsername.Width = 67;
            // 
            // col_EmployeePass
            // 
            this.col_EmployeePass.AppearanceCell.BackColor = System.Drawing.Color.Cyan;
            this.col_EmployeePass.AppearanceCell.BorderColor = System.Drawing.Color.Transparent;
            this.col_EmployeePass.AppearanceCell.Options.UseBackColor = true;
            this.col_EmployeePass.AppearanceCell.Options.UseBorderColor = true;
            this.col_EmployeePass.AppearanceCell.Options.UseTextOptions = true;
            this.col_EmployeePass.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeePass.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmployeePass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeePass.Caption = "Mật khẩu";
            this.col_EmployeePass.FieldName = "Password";
            this.col_EmployeePass.Name = "col_EmployeePass";
            this.col_EmployeePass.OptionsColumn.AllowEdit = false;
            this.col_EmployeePass.OptionsColumn.AllowFocus = false;
            this.col_EmployeePass.OptionsColumn.ReadOnly = true;
            this.col_EmployeePass.Visible = true;
            this.col_EmployeePass.VisibleIndex = 8;
            this.col_EmployeePass.Width = 79;
            // 
            // ref_OffWork
            // 
            this.ref_OffWork.AutoHeight = false;
            this.ref_OffWork.DisplayValueChecked = "1";
            this.ref_OffWork.DisplayValueGrayed = "0";
            this.ref_OffWork.DisplayValueUnchecked = "0";
            this.ref_OffWork.Name = "ref_OffWork";
            this.ref_OffWork.ValueChecked = 1;
            this.ref_OffWork.ValueGrayed = 0;
            this.ref_OffWork.ValueUnchecked = 0;
            // 
            // col_EmployeeGroup
            // 
            this.col_EmployeeGroup.Caption = "Nhóm";
            this.col_EmployeeGroup.ColumnEdit = this.ref_EmployeeGroup;
            this.col_EmployeeGroup.FieldName = "EmployeeGroupID";
            this.col_EmployeeGroup.Name = "col_EmployeeGroup";
            this.col_EmployeeGroup.Visible = true;
            this.col_EmployeeGroup.VisibleIndex = 9;
            // 
            // ref_EmployeeGroup
            // 
            this.ref_EmployeeGroup.AutoHeight = false;
            this.ref_EmployeeGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_EmployeeGroup.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeGroupID", "ID Nhóm", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeGroupName", "Nhóm")});
            this.ref_EmployeeGroup.Name = "ref_EmployeeGroup";
            this.ref_EmployeeGroup.NullText = "";
            // 
            // ref_Department
            // 
            this.ref_Department.AutoHeight = false;
            this.ref_Department.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Department.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentCode", "Mã phòng", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Tên phòng")});
            this.ref_Department.Name = "ref_Department";
            this.ref_Department.NullText = "...";
            // 
            // repositoryItemButtonEdit_Pass
            // 
            this.repositoryItemButtonEdit_Pass.AutoHeight = false;
            this.repositoryItemButtonEdit_Pass.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo, "Cài mặc định", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit_Pass.Name = "repositoryItemButtonEdit_Pass";
            this.repositoryItemButtonEdit_Pass.NullText = "Cài mặc định";
            this.repositoryItemButtonEdit_Pass.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // FrmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 516);
            this.Controls.Add(this.gridControl_Employee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEmployee";
            this.Text = "FrmEmployee";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_sex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_OffWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_EmployeeGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Department)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Pass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Employee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Employee_Sex;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_status_sex;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeMobile;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeIDCard;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeBirthday;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeePosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_status_position;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeUsername;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeePass;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ref_OffWork;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_Department;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_EmployeeGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_Pass;
    }
}