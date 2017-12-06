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
using System.Data.OleDb;
using BioNetModel.Data;
using BioNetBLL;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmImportData : DevExpress.XtraEditors.XtraForm
    {
        public FrmImportData()
        {
            InitializeComponent();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel File|*.xls;*.xlsx";
            if (of.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = ReadFromExcel(of.FileName);
                ImportUpdateData(dt);
            }
        }
        private DataTable ReadFromExcel(string filename)
        {
            string OledbConnectionStr = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filename + "';Extended Properties=Excel 12.0;";
            using (OleDbConnection oledbConn = new OleDbConnection(OledbConnectionStr))
            {
                DataTable dt = new DataTable();
                try
                {

                    oledbConn.Open();
                    string Read = "select * from [Sheet1$] ";
                    OleDbDataAdapter oleda = new OleDbDataAdapter(Read, oledbConn);
                    oleda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GCPhieuSangLoc.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không có thông tin !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    oledbConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi, không thể đọc file\n" + ex.ToString() + "", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    oledbConn.Close();
                }
                return dt;
            }
                
          
        }
        private void ImportUpdateData(DataTable dt)
        {
            if (dt.Rows.Count == 0 || dt == null)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PSPhieuSangLoc psl = new PSPhieuSangLoc();
                    psl.IDPhieu = dt.Rows[i]["IDPhieu"].ToString().TrimEnd();
                    psl.MaBenhNhan ="";
                    psl.NgayTaoPhieu = DateTime.Parse(dt.Rows[i]["NgayTaoPhieu"].ToString());
                    psl.IDNhanVienTaoPhieu = "NV0001";
                    var dv = dmdvcs.FirstOrDefault(x => x.TenDVCS == dt.Rows[i]["IDCoSo"].ToString().TrimEnd());
                    if(dv==null)
                    {
                        dv= dmdvcs.FirstOrDefault(x => x.TenDVCS == dt.Rows[i]["NoiLayMau"].ToString().TrimEnd());
                    }

                    psl.IDCoSo =dv.MaDVCS ;
                    psl.NgayGioLayMau = DateTime.Parse(dt.Rows[i]["NgayGioLayMau"].ToString());

                        switch (dt.Rows[i]["IDViTriLayMau"].ToString().TrimEnd())
                    {
                        case "Tĩnh mạch":
                            {
                                psl.IDViTriLayMau =0;
                                break;
                            }
                        case "Gót chân":
                            {
                                psl.IDViTriLayMau = 1;
                                break;
                            }
                        default:
                            {
                                psl.IDViTriLayMau = 2;
                                break;
                            }
                    }
                    psl.IDNhanVienLayMau = dt.Rows[i]["IDNhanVienLayMau"].ToString().TrimEnd();
//psl.isLayMauLan2 = false;
//psl.IDPhieuLan1 = "";
//psl.TinhTrangLucLayMau=
//psl.SLTruyenMau = 0;
//                    psl.NgayTruyenMau = new DateTime();
//                    psl.CheDoDinhDuong=
//psl.TrangThaiPhieu
//psl.TrangThaiMau
//psl.isKhongDat
//psl.NgayNhanMau
//psl.MaXetNghiem
//psl.Para
//psl.isTruoc24h
//psl.isSinhNon
//psl.isNheCan
//psl.isGuiMauTre
//psl.IDChuongTrinh
//psl.MaGoiXN
//psl.TenNhanVienLayMau
//psl.SDTNhanVienLayMau
//psl.NoiLayMau = dv.DiaChiDVCS;
//psl.isHuyMau = false;
//psl.LyDoKhongDat=
//psl.isDongBo = false;
//                    psl.isXoa = false;
//psl.DiaChiLayMau = dv.DiaChiDVCS;
//psl.isXNLan2 = false;
//                    psl.IDNhanVienXoa = null;
//                    psl.NgayGioXoa = null;
//                    psl.LuuYPhieu = null;
//psl.NgayCoKQ=


                }
                MessageBox.Show("Đã Import xong !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        
        List<PSDanhMucDonViCoSo> dmdvcs = new List<PSDanhMucDonViCoSo>();
        private void FrmImportData_Load(object sender, EventArgs e)
        {
            dmdvcs = BioNet_Bus.GetDanhSachDonViCoSo();
        }
    }
}