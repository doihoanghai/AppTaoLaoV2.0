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
using BioNetModel;
using BioNetModel.Data;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmInfoPerson : DevExpress.XtraEditors.XtraForm
    {
        private string maBenhNhan = string.Empty;
        public FrmInfoPerson()
        {
            InitializeComponent();
        }
        private List<PSPatient> patientlst = new List<PSPatient>();
        private List<PSPatient> patientSearchlst = new List<PSPatient>();
        private void LoadDanhSachBenhNhan()
        {
            patientlst = BioBLL.GetDanhSachBenhNhan();
            this.gridControl_Info.DataSource = patientlst;
        }
        private void FrmInfoPerson_Load(object sender, EventArgs e)
        {
            this.LoadDanhSachBenhNhan();
            this.lookUpDanToc.Properties.DataSource = BioNet_Bus.GetDanhSachDanToc(-1);

            btnEdit.Enabled = btnCancel.Enabled = btnSave.Enabled = false;
            ReadOnlyText(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.gridControl_Info.DataSource = null;
            this.gridControl_Info.DataSource = BioBLL.GetListPatient(this.txtSearch.Text.Trim()); 
        }

        private void gridView_Info_DoubleClick(object sender, EventArgs e)
        {
            this.maBenhNhan = gridView_Info.GetRowCellValue(gridView_Info.FocusedRowHandle, "MaBenhNhan").ToString();
            PSPatient infoPerson = BioBLL.GetInfoPersonByMa(maBenhNhan);
            txtTenMe.Text = infoPerson.MotherName;
            txtTenCha.Text = infoPerson.FatherName;
            txtNamSinhMe.EditValue = !string.IsNullOrEmpty(infoPerson.MotherBirthday.ToString())? Convert.ToDateTime(infoPerson.MotherBirthday).ToString("dd/MM/yyyy") : string.Empty;
            txtNamSinhCha.EditValue = !string.IsNullOrEmpty(infoPerson.FatherBirthday.ToString())? Convert.ToDateTime(infoPerson.FatherBirthday).ToString("dd/MM/yyyy") : string.Empty;
            txtSDTMe.Text = infoPerson.MotherPhoneNumber;
            txtSDTCha.Text = infoPerson.FatherPhoneNumber;
            txtAddress.Text = infoPerson.DiaChi;

            txtTenBenhNhan.Text = infoPerson.TenBenhNhan;
            txtGioiTinh.EditValue = infoPerson.GioiTinh;
            txtGioSinhBenhNhan.EditValue = !string.IsNullOrEmpty(infoPerson.NgayGioSinh.ToString()) ? Convert.ToDateTime(infoPerson.NgayGioSinh).ToString("H:mm:ss") : string.Empty;
            txtNamSinhBenhNhan.EditValue = !string.IsNullOrEmpty(infoPerson.NgayGioSinh.ToString()) ? Convert.ToDateTime(infoPerson.NgayGioSinh).ToString("dd/MM/yyyy") : string.Empty;
            txtNoiSinh.Text = infoPerson.NoiSinh;
            lookUpDanToc.EditValue = infoPerson.DanTocID;
            txtTuan.Value = Convert.ToDecimal(infoPerson.TuanTuoiKhiSinh);
            txtNang.Text = infoPerson.CanNang.ToString();
            cboPhuongPhapSinh.EditValue = infoPerson.PhuongPhapSinh;
            btnEdit.Enabled = true;
            ReadOnlyText(true);
        }

        private void CLearText()
        {
            txtTenMe.Text = string.Empty;
            txtTenCha.Text = string.Empty;
            txtNamSinhMe.Text = string.Empty;
            txtNamSinhCha.Text = string.Empty;
            txtSDTMe.Text = string.Empty;
            txtSDTCha.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtTenBenhNhan.Text = string.Empty;
            txtGioiTinh.Text = string.Empty;
            txtGioSinhBenhNhan.Text = string.Empty;
            txtNamSinhBenhNhan.Text = string.Empty;
            txtNoiSinh.Text = string.Empty;
            lookUpDanToc.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtTuan.Text = string.Empty;
            txtNang.Text = string.Empty;
            cboPhuongPhapSinh.Text = string.Empty;
        }

        private void ReadOnlyText(bool en)
        {
            txtTenMe.ReadOnly = en;
            txtTenCha.ReadOnly = en;
            txtNamSinhMe.ReadOnly = en;
            txtNamSinhCha.ReadOnly = en;
            txtSDTMe.ReadOnly = en;
            txtSDTCha.ReadOnly = en;
            txtAddress.ReadOnly = en;
            txtTenBenhNhan.ReadOnly = en;
            txtGioiTinh.ReadOnly = en;
            txtGioSinhBenhNhan.ReadOnly = en;
            txtNamSinhBenhNhan.ReadOnly = en;
            txtNoiSinh.ReadOnly = en;
            lookUpDanToc.ReadOnly = en;
            txtSDT.ReadOnly = en;
            txtTuan.ReadOnly = en;
            txtNang.ReadOnly = en;
            cboPhuongPhapSinh.ReadOnly = en;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            ReadOnlyText(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
             PSPatient   Patients = new BioNetModel.Data.PSPatient();
                
                if (string.IsNullOrEmpty(this.maBenhNhan))
                {
                    XtraMessageBox.Show("Không tìm thấy mã thông tin", "PowerSoft - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(ValidationForm())
                {
                    Patients.MaBenhNhan = this.maBenhNhan;
                    Patients.MotherName = txtTenMe.Text;
                   Patients.FatherName = txtTenCha.Text;
                    if (!string.IsNullOrEmpty(txtNamSinhMe.EditValue.ToString()))
                       Patients.MotherBirthday = Convert.ToDateTime(txtNamSinhMe.EditValue);
                    if (!string.IsNullOrEmpty(txtNamSinhCha.EditValue.ToString()))
                        Patients.FatherBirthday = Convert.ToDateTime(txtNamSinhCha.EditValue);
                    Patients.MotherPhoneNumber = txtSDTMe.Text;
                    Patients.FatherPhoneNumber = txtSDTCha.Text;
                    Patients.DiaChi = txtAddress.Text;

                    Patients.TenBenhNhan = txtTenBenhNhan.Text;
                    if (!string.IsNullOrEmpty(txtGioiTinh.EditValue.ToString()))
                        Patients.GioiTinh = int.Parse(txtGioiTinh.EditValue.ToString()??"2");
                    string strNgayGio = Convert.ToDateTime(txtNamSinhBenhNhan.EditValue).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(txtGioSinhBenhNhan.EditValue).ToString("H:mm:ss");
                    Patients.NgayGioSinh = Convert.ToDateTime(strNgayGio);
                    Patients.NoiSinh = txtNoiSinh.Text;
                    if (!string.IsNullOrEmpty(lookUpDanToc.EditValue.ToString()))
                        Patients.DanTocID = Convert.ToInt32(lookUpDanToc.EditValue);
                    
                    if (!string.IsNullOrEmpty(txtTuan.Value.ToString()))
                        Patients.TuanTuoiKhiSinh = Convert.ToByte(txtTuan.Value);
                    if (!string.IsNullOrEmpty(txtNang.Text))
                        Patients.CanNang = Convert.ToInt16(txtNang.Text);
                    if (!string.IsNullOrEmpty(cboPhuongPhapSinh.EditValue.ToString()))
                        Patients.PhuongPhapSinh =Convert.ToByte( cboPhuongPhapSinh.EditValue);
                 
                    if (BioBLL.UpdInfoPerson(Patients))
                    {
                        XtraMessageBox.Show("Cập nhật thông tin bệnh nhân thành công", "PowerSoft - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadDanhSachBenhNhan();
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi ! Không thể chỉnh sửa thông tin", "PowerSoft - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    ReadOnlyText(true);
                }
                
            }
            catch(Exception ex) { XtraMessageBox.Show("Lỗi! Chỉnh sửa thông tin thất bại", "PowerSoft - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool ValidationForm()
        {
            string error = string.Empty;
            if (string.IsNullOrEmpty(txtTenMe.Text))
                error += "Tên mẹ không được để trống \n";
            if(string.IsNullOrEmpty(txtTenCha.Text))
                error += "Tên cha không được để trống \n";
            if (string.IsNullOrEmpty(txtNamSinhMe.Text))
                error += "Năm sinh mẹ không được để trống \n";
            if (string.IsNullOrEmpty(txtNamSinhCha.Text))
                error += "Năm sinh cha không được để trống \n";
            if (string.IsNullOrEmpty(txtTenBenhNhan.Text))
                error += "Tên trẻ không được để trống \n";
            if (string.IsNullOrEmpty(txtGioiTinh.Text))
                error += "Giới tính trẻ không được để trống \n";
            if (string.IsNullOrEmpty(txtGioSinhBenhNhan.Text))
                error += "Giờ sinh trẻ không được để trống \n";
            if (string.IsNullOrEmpty(txtNamSinhBenhNhan.Text))
                error += "Năm sinh trẻ không được để trống \n";
            if (!string.IsNullOrEmpty(error))
            {
                XtraMessageBox.Show("Lỗi ! \n" + error, "PowerSoft - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            ReadOnlyText(true);
        }
    }
}