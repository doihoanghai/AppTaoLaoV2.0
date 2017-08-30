using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataSync.BioNetSync;

namespace DataSync
{
    public partial class FrmStartupSync : DevExpress.XtraEditors.XtraForm
    {
        public FrmStartupSync()
        {
            InitializeComponent();
        }
        private void mnStart_Click(object sender, EventArgs e)
        {
           
        }
        public void DongBoDuLieu()
        {

            this.PostThongTinTrungTam();
            this.GetThongTinTrungTam();
            this.GetDanhMucChiCuc();
            this.PostDanhMucChiCuc();
            this.GetDanhMucDonViCoSo();
            this.GetDanhMucDichVu();
            this.PostDanhMucDonViCoSo(); 
            this.GetDanhSachChuongTrinh();
            this.GetDMGoiDichVuTheoDVCS();
            this.PostDMGoiDichVuTheoDVCS();
            this.GetDanhMucThongSo();
            this.GetMapThongSo_KyThuat();
            this.GetMapDichVu_KyThuat();

            this.GetPhieuSangLoc();
            this.GetPatient();
            this.PostDotChuanDoan();
            this.PostPhieuSangLoc();
            this.PostChiDinh();
            this.PostBenhNhanNguyCoCao();
            this.PostKetQua();
            this.PostTraKetQua();
            this.PostTiepNhan();
            this.GetTiepNhan();

        }
        public  void GetDuLieuBanDau()
        {

            //this.GetThongTinTrungTam();
            //this.GetDanhMucChiCuc();          
            //this.GetDanhMucDonViCoSo();
            //this.GetDanhMucDichVu();            
            //this.GetDanhSachChuongTrinh();
            //this.GetDMGoiDichVuTheoDVCS();           
            //this.GetDanhMucThongSo();
            //this.GetMapThongSo_KyThuat();
            //this.GetMapDichVu_KyThuat();
            //this.GetPhieuSangLoc();
            //this.GetPatient();
          
            this.GetDanhSachChuongTrinh();


        }

        private void PostTiepNhan()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu danh sách tiếp nhận\r\n " }));
            var res = TiepNhanSync.PostTiepNhan();
            if (string.IsNullOrEmpty(res.StringError))
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu danh sách tiếp nhận\r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + ":Thông tin chi tiết khi đồng bộ dữ liệu danh sách tiếp nhận\r\n" + res.StringError + "\r\n" }));
            }

            this.rtbStatus.ScrollToCaret();
        }

        private void GetTiepNhan()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Tiếp nhận \r\n " }));
            var res = TiepNhanSync.GetTiepNhan();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Tiếp nhận thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Tiếp nhận KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
        }
        private void PostTraKetQua()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu danh sách trả kết quả\r\n " }));
            var res = TraKetQuaSync.PostKetQua();
            if (string.IsNullOrEmpty(res.StringError))
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu danh sách trả kết quả\r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + ":Thông tin chi tiết khi đồng bộ dữ liệu danh sách trả kết quả\r\n" + res.StringError + "\r\n" }));
            }

            this.rtbStatus.ScrollToCaret();
        }
        private void PostDotChuanDoan()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu danh sách đợt chuẩn đoán\r\n " }));
            var res = DotChuanDoanSync.PostDotChuanDoan();
            if (string.IsNullOrEmpty(res.StringError))
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu danh sách đợt chuẩn đoán thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + ":Thông tin chi tiết khi đồng bộ dữ liệu danh sách đợt chuẩn đoán\r\n" + res.StringError + "\r\n" }));
            }

            this.rtbStatus.ScrollToCaret();
        }
        private void PostKetQua()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu danh sách bệnh nhân nguy cơ cao\r\n " }));
            var res = KetQuaSync.PostKetQua();
            if (string.IsNullOrEmpty(res.StringError))
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu danh sách bệnh nhân nguy cơ cao thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + ":Thông tin chi tiết khi đồng bộ dữ liệu danh sách bệnh nhân nguy cơ cao \r\n" + res.StringError + "\r\n" }));
            }

            this.rtbStatus.ScrollToCaret();
        }

        private void PostBenhNhanNguyCoCao()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu danh sách bệnh nhân nguy cơ cao\r\n " }));
            var res = BenhNhanNguyCoCaoSync.PostBenhNhanNguyCoCao();
            if (string.IsNullOrEmpty(res.StringError))
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu danh sách bệnh nhân nguy cơ cao thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + ":Thông tin chi tiết khi đồng bộ dữ liệu danh sách bệnh nhân nguy cơ cao \r\n" + res.StringError + "\r\n" }));
            }

            this.rtbStatus.ScrollToCaret();
        }


        private void PostChiDinh()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu danh sách chỉ định\r\n " }));
            var res = ChiDinhSync.PostChiDinh();
            if (string.IsNullOrEmpty(res.StringError))
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu danh sách chỉ định thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + ":Thông tin chi tiết khi đồng bộ dữ liệu danh sách chỉ định \r\n" + res.StringError + "\r\n" }));
            }

            this.rtbStatus.ScrollToCaret();
        }


        private void GetPatient()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Patient \r\n " }));
            var res = PatientSync.GetPatient();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Patient thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Patient KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
        }


        private void GetDanhMucDanhGiaChatLuongMau()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Gói dịch vụ chung \r\n " }));
            var res = DanhMucDanhGiaChatLuongMau.GetDMDanhGiaChatLuongMau();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Gói dịch vụ chung thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Gói dịch vụ chung KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void GetDanhMucThongSoXN()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang lấy dữ liệu thông số xét nghiệm \r\n " }));
            var res = DanhMucThongSoSync.GetDMThongSo();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu thông số xét nghiệm thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu thông số xét nghiệm KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void GetDanhMucGoiDichVuChung()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Gói dịch vụ chung \r\n " }));
            var res = DanhMucGoiDichVuChungSync.GetDMGoiDichVuChung();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Gói dịch vụ chung thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Gói dịch vụ chung KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void GetDanhMucGoiDichVuChung_ChiTiet()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Gói dịch vụ chung chi tiết \r\n " }));
            var res = DanhMucGoiDichVuChungSync.GetDMGoiDichVuChung_ChiTiet();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Gói dịch vụ chung chi tiế thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Gói dịch vụ chung chi tiế KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void GetDanhMucChiCuc()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Chi Cục \r\n " }));
            var res = DanhMucChiCucSync.GetDanhMucChiCuc();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Chi Cục thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Chi Cục KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void GetThongTinTrungTam()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Trung tâm \r\n " }));
            var res = ThongTinTrungTamSync.GetThongTinTrungTam();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Trung tâm thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Trung tâm KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void PostThongTinTrungTam()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Trung tâm \r\n " }));
            var res = ThongTinTrungTamSync.PostThongtinTrungTam();
            if (string.IsNullOrEmpty(res.StringError))
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Trung tâm thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + ":Thông tin chi tiết khi đồng bộ dữ liệu Thông tin Trung tâm \r\n" + res.StringError + "\r\n" }));
            }
            
            this.rtbStatus.ScrollToCaret();
        }
        private void PostDanhMucDonViCoSo()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Đơn vị cơ sở \r\n " }));
            var res = DanhMucDonViCoSoSync.PostDanhMucDonViCoSo();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Đơn vị cơ sở thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Đơn vị cơ sở KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void GetDanhMucDonViCoSo()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Đơn vị cơ sở+ \r\n " }));
            var res = DanhMucDonViCoSoSync.GetDanhMucDonViCoSo();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Đơn vị cơ sở thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Cơ sở KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void PostDanhMucChiCuc()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu Đơn vị cơ sở \r\n " }));
            var res = DanhMucChiCucSync.PostDanhMucChiCuc();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Đơn vị cơ sở thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu Đơn vị cơ sở KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }
        private void GetDanhSachChuongTrinh()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang lấy dữ liệu Danh sách chương trình sàng lọc \r\n " }));
            var res = DanhMucChuongTrinhSync.GetDanhSachChuongTrinh();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Danh sách chương trình sàng lọc thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Danh sách chương trình sàng lọc KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();

        }
        private void GetDanhMucDichVu()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang lấy dữ liệu Danh mục dịch vụ \r\n " }));
            var res = DanhMucDichVuSync.GetDMDichVu();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Danh mục dịch vụ thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Danh mục dịch vụ KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError }));
            }
            this.rtbStatus.ScrollToCaret();

        }

        private void GetDMGoiDichVuTheoDVCS()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang lấy dữ liệu Danh mục gói dịch vụ theo đơn vị cơ sở \r\n " }));
            var res = DanhMucGoiDichVuTheoDonViSync.GetDMGoiDichVuTheoDonVi();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Danh mục gói dịch vụ thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Danh mục gói dịch vụ KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError }));
            }
            this.rtbStatus.ScrollToCaret();

        }

        private void PostDMGoiDichVuTheoDVCS()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu gói dịch vụ đơn vị cơ sở \r\n " }));
            var res = DanhMucGoiDichVuTheoDonViSync.PostDanhMucGoiDichVuDonViCoSo();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu gói dịch vụ đơn vị cơ sở thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu gói dịch vụ đơn vị cơ sở KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }

        private void GetDanhMucThongSo()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang lấy dữ liệu Danh mục thông số \r\n " }));
            var res = DanhMucThongSoSync.GetDMThongSo();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Danh mục thông số thành công\r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Danh mục thông số KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError }));
            }
            this.rtbStatus.ScrollToCaret();

        }

        private void GetMapThongSo_KyThuat()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang lấy dữ liệu Maps thông số - kỹ thuật \r\n " }));
            var res = MappingKyThuat_DichVuSync.GetDMMap_ThongSo_KyThuat();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Maps thông số - kỹ thuật thành công\r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Maps thông số - kỹ thuật KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError }));
            }
            this.rtbStatus.ScrollToCaret();

        }
        private void GetMapDichVu_KyThuat()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang lấy dữ liệu Maps dịch vụ - kỹ thuật \r\n " }));
            var res = MappingThongso_KyThuatSync.GetDMMap_KyThuat_DichVu();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Maps dịch vụ - kỹ thuật thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu Maps dịch vụ - kỹ thuật KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError }));
            }
            this.rtbStatus.ScrollToCaret();

        }

        private void GetPhieuSangLoc()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang lấy dữ liệu phiếu sàng lọc \r\n " }));
            var res = PhieuSangLocSync.GetPhieuSangLoc();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu phiếu sàng lọc thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Lấy dữ liệu phiếu sàng lọc KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError }));
            }
            this.rtbStatus.ScrollToCaret();

        }

        private void PostPhieuSangLoc()
        {
            this.rtbStatus.SelectionColor = Color.LightYellow;
            this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :Đang đồng bộ dữ liệu phiếu sàng lọc \r\n " }));
            var res = PhieuSangLocSync.PostPhieuSangLoc();
            if (res.Result)
            {
                this.rtbStatus.SelectionColor = Color.LightYellow;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu phiếu sàng lọc thành công \r\n " }));
            }
            else
            {
                this.rtbStatus.SelectionColor = Color.Red;
                this.rtbStatus.AppendText(string.Concat(new object[] { DateTime.Now + " :đồng bộ dữ liệu phiếu sàng lọc KHÔNG thành công\r\n Lỗi chi tiết : \r\n" + res.StringError + "\r\n" }));
            }
            this.rtbStatus.ScrollToCaret();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GetDuLieuBanDau();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmStartupSync_Load(object sender, EventArgs e)
        {

        }

        private void rtbStatus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}