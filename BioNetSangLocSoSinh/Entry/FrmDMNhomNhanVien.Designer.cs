namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMNhomNhanVien
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl_Employee = new DevExpress.XtraGrid.GridControl();
            this.gridView_Employee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_PositionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_status_position = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Level = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_status_sex = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ref_OffWork = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ref_Department = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ref_EmployeeGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemButtonEdit_Pass = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.col_EmployeePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_sex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_OffWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Department)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_EmployeeGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Pass)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Employee
            // 
            this.gridControl_Employee.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Employee.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Employee.MainView = this.gridView_Employee;
            this.gridControl_Employee.Name = "gridControl_Employee";
            this.gridControl_Employee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_status_sex,
            this.ref_status_position,
            this.ref_OffWork,
            this.ref_Department,
            this.ref_EmployeeGroup,
            this.repositoryItemButtonEdit_Pass});
            this.gridControl_Employee.Size = new System.Drawing.Size(1087, 419);
            this.gridControl_Employee.TabIndex = 2;
            this.gridControl_Employee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Employee});
            this.gridControl_Employee.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Employee_ProcessGridKey);
            // 
            // gridView_Employee
            // 
            this.gridView_Employee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_PositionCode,
            this.col_Level,
            this.col_EmployeePosition});
            this.gridView_Employee.GridControl = this.gridControl_Employee;
            this.gridView_Employee.Name = "gridView_Employee";
            this.gridView_Employee.NewItemRowText = "Thêm mới chức danh nhân viên sử dụng phần mềm";
            this.gridView_Employee.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Employee.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Employee.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Employee.OptionsView.ShowGroupPanel = false;
            this.gridView_Employee.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Employee_InvalidRowException);
            this.gridView_Employee.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Employee_ValidateRow);
            // 
            // col_PositionCode
            // 
            this.col_PositionCode.Caption = "Mã chức danh";
            this.col_PositionCode.FieldName = "PositionCode";
            this.col_PositionCode.Name = "col_PositionCode";
            this.col_PositionCode.OptionsColumn.AllowEdit = false;
            this.col_PositionCode.OptionsColumn.AllowFocus = false;
            this.col_PositionCode.OptionsColumn.ReadOnly = true;
            // 
            // ref_status_position
            // 
            this.ref_status_position.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ref_status_position.Name = "ref_status_position";
            this.ref_status_position.NullText = "...";
            // 
            // col_Level
            // 
            this.col_Level.Caption = "Cấp bậc";
            this.col_Level.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Level.FieldName = "Level";
            this.col_Level.Name = "col_Level";
            this.col_Level.Visible = true;
            this.col_Level.VisibleIndex = 1;
            this.col_Level.Width = 147;
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
            // repositoryItemButtonEdit_Pass
            // 
            this.repositoryItemButtonEdit_Pass.AutoHeight = false;
            this.repositoryItemButtonEdit_Pass.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo, "Cài mặc định", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItemButtonEdit_Pass.Name = "repositoryItemButtonEdit_Pass";
            this.repositoryItemButtonEdit_Pass.NullText = "Cài mặc định";
            this.repositoryItemButtonEdit_Pass.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // col_EmployeePosition
            // 
            this.col_EmployeePosition.Caption = "Chức danh";
            this.col_EmployeePosition.FieldName = "PositionName";
            this.col_EmployeePosition.Name = "col_EmployeePosition";
            this.col_EmployeePosition.Visible = true;
            this.col_EmployeePosition.VisibleIndex = 0;
            this.col_EmployeePosition.Width = 922;
            // 
            // FrmDMNhomNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 419);
            this.Controls.Add(this.gridControl_Employee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMNhomNhanVien";
            this.Text = "FrmEmployee";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_sex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_OffWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Department)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_EmployeeGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Pass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Employee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn col_PositionCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_status_sex;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_status_position;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ref_OffWork;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_Department;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_EmployeeGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_Pass;
        private DevExpress.XtraGrid.Columns.GridColumn col_Level;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeePosition;
    }
}