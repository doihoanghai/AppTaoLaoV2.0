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
using System.Collections;
using BioNetModel.Data;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        private string empLogin = string.Empty;
        private string empCode = string.Empty;
        private int posLevel = 0;
        private int positionCode = 0;
        private List<string> lstMenu;
        private bool isGroup = false;
        private int totalMenu = 0;
        private int totalMenuEmpCheck = 0;
        private List<PSMenuSecurity> lstMenuByEmp = new List<PSMenuSecurity>();
        private List<PSMenuSecurityPosition> lstMenuByPosition = new List<PSMenuSecurityPosition>();
        private List<PSMenuSecurityPosition> lstMenuByPositionNew = new List<PSMenuSecurityPosition>();

        public FrmPhanQuyen(TreeNode node, string _empLogin)
        {
            this.empLogin = _empLogin;
            InitializeComponent();
            this.treeAuthor.Nodes.Clear();
            this.treeAuthor.Nodes.Add(node);
        }

        private string DisplayTotalMenu()
        {
            this.totalMenu = 0;
            this.totalMenuEmpCheck = 0;
            this.CountItemMenu(treeAuthor.Nodes[0]);
            this.CountItemMenuEmployeeCheck(treeAuthor.Nodes[0]);
            string result = "(" + this.totalMenuEmpCheck + "/" + this.totalMenu + ")";
            return result;
        }

        private void CountItemMenu(TreeNode nodes)
        {
            foreach (TreeNode node in nodes.Nodes)
            {
                this.totalMenu++;
                if (node.Nodes.Count > 0)
                {
                    CountItemMenu(node);
                }
            }
        }

        private void CountItemMenuEmployeeCheck(TreeNode nodes)
        {
            foreach (TreeNode node in nodes.Nodes)
            {
                if (node.Checked)
                    this.totalMenuEmpCheck++;
                if (node.Nodes.Count > 0)
                {
                    CountItemMenuEmployeeCheck(node);
                }
            }
        }

        private void FrmPhanQuyen_Load(object sender, EventArgs e)
        {
            this.LoadEmployeePosition();
            this.lblTotalMenu.Text = this.DisplayTotalMenu();
        }

        private void LoadEmployeePosition()
        {
            try
            {
                TreeNode anode, anode1;
                treeEmployee.Nodes.Clear();
                treeEmployee.ItemHeight = 18;
                var lstEmpPosition = BioBLL.GetEmployeeByPosition(0);
                foreach (var position in lstEmpPosition)
                {
                    anode = new TreeNode(position.PositionName + " (cấp " + position.Level + ")");
                    anode.Tag = position.PositionCode;
                    treeEmployee.Nodes.Add(anode);
                    foreach (var emp in position.Employee)
                    {
                        anode1 = new TreeNode(emp.EmployeeName + " (" + emp.EmployeeCode + ")");
                        anode1.Tag = position.PositionCode + ":" + emp.EmployeeCode;
                        anode.Nodes.Add(anode1);
                    }
                }
                treeEmployee.ExpandAll();
            }
            catch { }
        }

        private void butQuyen_All_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeCode = string.Empty;
                int i = treeEmployee.SelectedNode.Parent == null ? 0 : 1;
                employeeCode = treeEmployee.SelectedNode.Tag.ToString().Split(':')[i];
                if (employeeCode != string.Empty)
                {
                    this.butQuyen_All.Checked = !butQuyen_All.Checked;
                    this.butQuyen_All.ToolTipText = butQuyen_All.Checked ? "Bỏ chọn tất cả" : "Chọn tất cả";
                    this.f_Chon_All();
                }
                else
                {
                    XtraMessageBox.Show(" Chọn user cần phân quyền sử dụng!", "PowerMED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { return; }
        }

        private void f_Chon_All()
        {
            try
            {
                foreach (TreeNode anode in treeAuthor.Nodes)
                {
                    anode.Checked = butQuyen_All.Checked;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode, butQuyen_All.Checked);
                    }
                }
            }
            catch
            {
            }
        }

        private void f_Chon_Quyen(TreeNode v_node, bool v_bool)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = v_bool;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode, v_bool);
                    }
                }
            }
            catch
            {
            }
        }

        private void FindItem(TreeNode nodes, bool isCheck)
        {
            if (nodes.Nodes.Count > 0)
            {
                foreach (TreeNode node in nodes.Nodes)
                {
                    node.Checked = isCheck;
                    FindItem(node, isCheck);
                }
            }
        }

        private void treeAuthor_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                FindItem(e.Node, true);
                e.Node.ForeColor = Color.Red;
            }
            else
            {
                FindItem(e.Node, false);
                e.Node.ForeColor = Color.Black;
            }
            lblTotalMenu.Text = this.DisplayTotalMenu();
        }

        public void FindItemToCheckByParent(TreeNode oParentNode)
        {
            if (oParentNode.Checked)
            {
                lstMenu.Add(oParentNode.Name + "," + oParentNode.Text);
            }
            foreach (TreeNode oSubNode in oParentNode.Nodes)
            {
                FindItemToCheckByParent(oSubNode);
            }
        }

        public void FindItemToCheckByEmp(TreeNode oParentNode)
        {
            if (lstMenuByEmp.Where(x => x.MenuCode == oParentNode.Name).Count() > 0)
            {
                oParentNode.Checked = true;
            }
            else
                oParentNode.Checked = false;
            foreach (TreeNode oSubNode in oParentNode.Nodes)
            {
                FindItemToCheckByEmp(oSubNode);
            }
        }

        public void FindItemToCheckByPosition(TreeNode oParentNode)
        {
            if (lstMenuByPosition.Where(x => x.MenuCode == oParentNode.Name).Count() > 0)
            {
                oParentNode.Checked = true;
            }
            else
                oParentNode.Checked = false;
            foreach (TreeNode oSubNode in oParentNode.Nodes)
            {
                FindItemToCheckByPosition(oSubNode);
            }
        }

        private void treeEmployee_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                EnableRadio(true);
                this.isGroup = true;
                this.positionCode = Convert.ToInt32(treeEmployee.SelectedNode.Tag.ToString());
                e.Node.ForeColor = Color.Red;
                lstMenuByPosition.Clear();
                lstMenuByPosition = BioBLL.ListMenuSecurity(this.positionCode);
                FindItemToCheckByPosition(treeAuthor.Nodes[0]);
            }
            else
            {
                EnableRadio(false);
                this.isGroup = false;
                this.empCode = treeEmployee.SelectedNode.Tag.ToString().Split(':')[treeEmployee.SelectedNode.Parent == null ? 0 : 1];
                e.Node.ForeColor = Color.Red;
                lstMenuByEmp.Clear();
                lstMenuByEmp = BioBLL.ListMenuSecurity(empCode);
                FindItemToCheckByEmp(treeAuthor.Nodes[0]);
            }
            lblTotalMenu.Text = this.DisplayTotalMenu();

        }

        private void EnableRadio(bool en)
        {
            this.rdoApplyForEmp.Enabled = en;
            this.rdoApplyToDefault.Enabled = en;
            this.rdoDefault.Enabled = en;
        }

        private void treeEmployee_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeEmployee.SelectedNode.ForeColor = Color.Black;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lstMenu = new List<string>();
                FindItemToCheckByParent(treeAuthor.Nodes[0]);

                if (this.isGroup)
                {
                    if (this.positionCode == 0)
                    {
                        XtraMessageBox.Show("Chưa chọn nhân viên để thực hiện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int checkLevel = this.CheckLevelPositionWithPosCode(this.empLogin);
                    if (checkLevel == 0)
                    {
                        XtraMessageBox.Show("Bạn không thể chỉnh sửa nhóm nhân viên trên cấp!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkLevel == -1)
                    {
                        XtraMessageBox.Show("Bạn không thể chỉnh sửa nhóm nhân viên bằng cấp!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkLevel == -2)
                    {
                        XtraMessageBox.Show("Lỗi không thể sửa phẩn quyền!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (rdoDefault.Checked)
                    {
                        if (UpdateMenuForPosition())
                        {
                            XtraMessageBox.Show("Cập nhật phân quyền thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật phân quyền thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else if (rdoApplyForEmp.Checked)
                    {
                        UpdateMenuForPosition();

                        var lstEmpPosition = BioBLL.GetEmployeeByPosition(this.positionCode);
                        List<string> menu = CompareWithTwoList(lstMenuByPosition, lstMenuByPositionNew);

                        foreach (var empPosition in lstEmpPosition)
                        {
                            foreach (var emp in empPosition.Employee)
                            {
                                this.empCode = emp.EmployeeCode;
                                for (int i = 0; i < menu.Count; i++)
                                {
                                    string[] items = menu[i].Split(',');
                                    PSMenuSecurity menuSecurity = new PSMenuSecurity
                                    {
                                        MenuCode = items[0],
                                        MenuName = items[1],
                                        EmployeeCode = this.empCode,
                                        CreateDate = DateTime.Now
                                    };
                                    if (items[2] == "Check")
                                    {
                                        BioBLL.InsertItemMenuSercurity(menuSecurity);
                                    }
                                    else
                                    {
                                        BioBLL.DeleteItemMenuSercurity(menuSecurity);
                                    }
                                }
                            }
                        }
                        XtraMessageBox.Show("Cập nhật phân quyền thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (rdoApplyToDefault.Checked)
                    {
                        UpdateMenuForPosition();
                        var lstEmpPosition = BioBLL.GetEmployeeByPosition(this.positionCode);
                        foreach (var empPosition in lstEmpPosition)
                        {
                            foreach (var emp in empPosition.Employee)
                            {
                                this.empCode = emp.EmployeeCode;
                                UpdateMenuForEmp();
                            }
                        }
                        XtraMessageBox.Show("Cập nhật phân quyền thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Chưa chọn thiết lập phân quyền cho nhóm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rdoDefault.Focus();
                        return;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(this.empCode))
                    {
                        XtraMessageBox.Show("Chưa chọn nhân viên để thực hiện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int checkLevel = this.CheckLevelPositionWithEmpCode(this.empLogin, this.empCode);
                    if (checkLevel == 0)
                    {
                        XtraMessageBox.Show("Bạn không thể chỉnh sửa nhân viên trên cấp!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkLevel == -1)
                    {
                        XtraMessageBox.Show("Bạn không thể chỉnh sửa nhân viên bằng cấp!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkLevel == -2)
                    {
                        XtraMessageBox.Show("Lỗi không thể sửa phẩn quyền!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (UpdateMenuForEmp())
                    {
                        XtraMessageBox.Show("Cập nhật phân quyền thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Cập nhật phân quyền thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Cập nhật phân quyền thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool UpdateMenuForEmp()
        {
            try
            {
                List<PSMenuSecurity> lstMenuSecurity = new List<PSMenuSecurity>();
                for (int i = 0; i < lstMenu.Count; i++)
                {
                    string item = lstMenu[i];
                    string[] items = item.Split(',');
                    PSMenuSecurity menuSecurity = new PSMenuSecurity
                    {
                        MenuCode = items[0],
                        MenuName = items[1],
                        EmployeeCode = empCode,
                        CreateDate = DateTime.Now
                    };
                    lstMenuSecurity.Add(menuSecurity);
                }
                return BioBLL.UpdateMenuSercurity(lstMenuSecurity, empCode);
            }
            catch { return false; }

        }

        private bool UpdateMenuForPosition()
        {
            try
            {
                List<PSMenuSecurityPosition> lstMenuSecurity = new List<PSMenuSecurityPosition>();
                for (int i = 0; i < lstMenu.Count; i++)
                {
                    string item = lstMenu[i];
                    string[] items = item.Split(',');
                    PSMenuSecurityPosition menuSecurity = new PSMenuSecurityPosition
                    {
                        MenuCode = items[0],
                        MenuName = items[1],
                        PositionCode = this.positionCode,
                        CreateDate = DateTime.Now
                    };
                    lstMenuSecurity.Add(menuSecurity);
                }
                this.lstMenuByPositionNew = lstMenuSecurity;
                return BioBLL.UpdateMenuSercurityPosition(lstMenuSecurity, this.positionCode);
            }
            catch { return false; }
        }

        private List<string> CompareWithTwoList(List<PSMenuSecurityPosition> listOld, List<PSMenuSecurityPosition> listNew)
        {
            List<string> listDifferent = new List<string>();
            List<string> getList = new List<string>();
            List<string> lstOld = new List<string>();
            List<string> lstNew = new List<string>();
            foreach (var item in listOld)
            {
                lstOld.Add(item.MenuCode + "," + item.MenuName);
            }
            foreach (var item in listNew)
            {
                lstNew.Add(item.MenuCode + "," + item.MenuName);
            }
            getList = lstOld.Except(lstNew).ToList();
            listDifferent.AddRange(getList);
            getList = lstNew.Except(lstOld).ToList();
            listDifferent.AddRange(getList);
            // Generate result list
            lstItemCheck = new List<string>();
            FindItemChecked(treeAuthor.Nodes[0]);
            for (int i = 0; i < listDifferent.Count; i++)
            {
                string menuCode = listDifferent[i].ToString();
                listDifferent[i] = menuCode + ",Uncheck";
                if (lstItemCheck.Contains(menuCode))
                {
                    listDifferent[i] = menuCode + ",Check";
                }
            }
            return listDifferent;
        }

        List<string> lstItemCheck = new List<string>();
        private void FindItemChecked(TreeNode nodes)
        {
            foreach (TreeNode node in nodes.Nodes)
            {
                string item = node.Name + "," + node.Text;
                if (node.Checked)
                    lstItemCheck.Add(item);
                if (node.Nodes.Count > 0)
                    FindItemChecked(node);
            }
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            this.NodeTextSearch();
        }

        private void NodeTextSearch()
        {
            this.ClearColorSelected();
            this.FindByText();
        }

        private void ClearColorSelected()
        {
            TreeNodeCollection nodes = this.treeEmployee.Nodes;
            foreach (TreeNode n in nodes)
            {
                this.ClearRecursive(n);
            }
        }

        private void FindByText()
        {
            TreeNodeCollection nodes = this.treeEmployee.Nodes;
            foreach (TreeNode n in nodes)
            {
                this.FindRecursive(n);
            }
        }

        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Text.ToLower().IndexOf(this.txtTim.Text.ToLower().Trim()) != -1)
                    tn.BackColor = Color.Yellow;
                FindRecursive(tn);
            }
        }

        private void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive(tn);
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            this.txtTim.Text = "";
        }

        private int CheckLevelPositionWithEmpCode(string empLogin, string empCode)
        {
            try
            {
                if (empLogin == empCode) { return 2; }
                else
                {
                    PSEmployee employeeLogin = new PSEmployee();
                    employeeLogin = BioBLL.GetEmployeeByCode(empLogin);
                    PSEmployee employee = new PSEmployee();
                    employee = BioBLL.GetEmployeeByCode(empCode);
                    int levelLogin = employeeLogin.PSEmployeePosition.Level;
                    int level = employee.PSEmployeePosition.Level;
                    if (levelLogin < level) { return 1; }
                    else if (levelLogin == level) { return -1; }
                    else { return 0; }
                }
            }
            catch { return -2; }
        }

        private int CheckLevelPositionWithPosCode(string empLogin)
        {
            try
            {
                PSEmployee employeeLogin = new PSEmployee();
                employeeLogin = BioBLL.GetEmployeeByCode(empLogin);
                PSEmployeePosition postion = new PSEmployeePosition();
                postion = BioBLL.GetPositionByCode(this.positionCode);
                int levelLogin = employeeLogin.PSEmployeePosition.Level;
                int level = postion.Level;
                if (levelLogin < level) { return 1; }
                else if (levelLogin == level) { return -1; }
                else { return 0; }
            }
            catch { return -2; }
        }
    }
}