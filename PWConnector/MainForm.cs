using MySql.Data.MySqlClient;
using PWToolKit;
using PWToolKit.API.Gamedbd;
using PWToolKit.Models;
using PWToolKit.Packets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWConnector
{
    public partial class MainForm : Form
    {
        string connection = DatabaseConnection.GetConnectionString();
        int amountSwitched = 0;
        gamedbdConfig gamedbd;
        List<List<Tuple<int, string>>> allAccounts;
        List<GRoleData> Roles = new List<GRoleData>();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnEquips_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationsForm conf = new ConfigurationsForm(DatabaseConnection.GetDatabaseConnection().HOST);
                Hide();
                conf.ShowDialog();
                Show();

                await Task.Run(async () =>
                {
                    gamedbd = new gamedbdConfig(conf.Host, conf.Port);
                    PWGlobal.UsedPwVersion = conf.version;

                    allAccounts = (await Task.Run(() => GetAllAccounts(new MySqlConnection(connection), gamedbd))).Where(x => x != null).ToList();

                    foreach (var account in allAccounts)
                    {
                        foreach (var role in account.Where(x => !string.IsNullOrEmpty(x.Item2)))
                        {
                            try
                            {
                                Roles.Add(GetRoleData.Get(gamedbd, role.Item1));
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Impossible to get information from role {role.Item1}");
                            }
                        }
                    }
                });

                btnConnect.Text = $"Loaded {allAccounts.Count} accounts | {Roles.Count} roles.";
                EnableElements(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO");
            }
        }

        List<List<Tuple<int, string>>> GetAllAccounts(MySqlConnection conn, IPwDaemonConfig gamedbd)
        {
            MySqlConnection con = conn;

            con.Open();
            string query = "SELECT id FROM users";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd.CommandText, con);
            da.Fill(dt);
            con.Close();

            List<List<Tuple<int, string>>> allRoles = new List<List<Tuple<int, string>>>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                allRoles.Add(GetUserRoles.Get(gamedbd, int.Parse(dt.Rows[i][0].ToString())));

                if (i % 6 == 0)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        progressBar.Maximum = dt.Rows.Count;
                        progressBar.Value = allRoles.Count > progressBar.Maximum ? progressBar.Maximum : allRoles.Count;
                    });
                }
            }

            BeginInvoke((MethodInvoker)delegate
            {
                progressBar.Value = progressBar.Maximum;
            });

            return allRoles;
        }

        private void btnCreateComponent_Click(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
            tb.Size = new Size(110, 366);
            tb.Name = "tbOld" + flowLayoutOld.Controls.Count;
            tb.Text = "0";

            TextBox tb2 = new TextBox();
            tb2.Size = new Size(110, 366);
            tb2.Name = "tbNew" + flowLayoutNew.Controls.Count;
            tb2.Text = "0";

            flowLayoutOld.Controls.Add(tb);
            flowLayoutNew.Controls.Add(tb2);

            flowLayoutOld.Update();
            flowLayoutNew.Update();
        }

        private void btnRemoveComponent_Click(object sender, EventArgs e)
        {
            if (flowLayoutNew.Controls.Count > 0 && flowLayoutOld.Controls.Count > 0)
            {
                flowLayoutOld.Controls.RemoveAt(flowLayoutOld.Controls.Count - 1);
                flowLayoutNew.Controls.RemoveAt(flowLayoutNew.Controls.Count - 1);

                flowLayoutOld.Update();
                flowLayoutNew.Update();
            }
        }

        private async void btnSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                EnableElements(false);

                var octetRelations = BuildOctetRelations();
                amountSwitched = 0;

                foreach (var role in Roles.Where(x => x != null).ToList())
                {
                    if (octetRelations.Count <= 0)
                    {
                        role.GRolePocket.Items = await LoopInventory(role.GRolePocket.Items, null);
                        role.GRoleEquipment.Items = await LoopInventory(role.GRoleEquipment.Items, null);
                        role.GRoleStorehouse.Items = await LoopInventory(role.GRoleStorehouse.Items, null);

                        PutRoleData.Put(gamedbd, role);
                    }
                    else
                    {
                        foreach (var relation in octetRelations)
                        {
                            role.GRolePocket.Items = await LoopInventory(role.GRolePocket.Items, relation);
                            role.GRoleEquipment.Items = await LoopInventory(role.GRoleEquipment.Items, relation);
                            role.GRoleStorehouse.Items = await LoopInventory(role.GRoleStorehouse.Items, relation);

                            PutRoleData.Put(gamedbd, role);
                        }
                    }
                }

                MessageBox.Show($"{amountSwitched} items affected.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableElements(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task<GRoleInventory[]> LoopInventory(GRoleInventory[] inventory, OctetRelation octetRelation)
        {
            try
            {
                var currentInventory = inventory;

                foreach (var item in currentInventory)
                {
                    if (tbGeneric.Enabled)
                    {
                        if (item.Id.Equals(int.Parse(tbItemID.Text.Trim())))
                        {
                            item.Octet = tbGeneric.Text.Trim();
                            item.Proctype = cbProctype.Checked ? Convert.ToInt32(tbProctype.Text) : item.Proctype;

                            amountSwitched++;
                        }
                    }
                    else
                    {
                        if (item.Octet.Equals(octetRelation.oldOctet) && item.Id.Equals(int.Parse(tbItemID.Text)))
                        {
                            item.Octet = octetRelation.newOctet;
                            item.Proctype = cbProctype.Checked ? Convert.ToInt32(tbProctype.Text) : item.Proctype;

                            amountSwitched++;
                        }
                    }                    
                }

                return currentInventory;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void EnableElements(bool state)
        {
            cbProctype.Enabled = state;
            btnConnect.Enabled = state;
            cbGenericSolution.Enabled = state;
            btnCreateComponent.Enabled = state;
            btnRemoveComponent.Enabled = state;
            btnSwitch.Enabled = state;
            tbItemID.Enabled = state;
        }
        public List<OctetRelation> BuildOctetRelations()
        {
            List<OctetRelation> octetRelations = new List<OctetRelation>();

            if (!HasEmptyFields())
            {
                foreach (Control oldControl in flowLayoutOld.Controls)
                {
                    foreach (Control newControl in flowLayoutNew.Controls)
                    {
                        int indexControl;
                        int.TryParse(oldControl.Name.Replace("tbOld", default), out indexControl);

                        if (oldControl.Name.Contains(indexControl.ToString()) && newControl.Name.Contains(indexControl.ToString()))
                        {
                            OctetRelation octetRelation = new OctetRelation();

                            octetRelation.newOctet = newControl.Text.Trim();
                            octetRelation.oldOctet = oldControl.Text.Trim();

                            octetRelations.Add(octetRelation);
                        }
                    }
                }

                return octetRelations;
            }
            else
            {
                return null;
            }
        }
        bool HasEmptyFields()
        {
            bool res = false;

            foreach (Control oldControl in flowLayoutOld.Controls)
            {
                foreach (Control newControl in flowLayoutNew.Controls)
                {
                    int indexControl;
                    int.TryParse(oldControl.Name.Replace("tbOld", default), out indexControl);

                    if (oldControl.Name.Contains(indexControl.ToString()) && newControl.Name.Contains(indexControl.ToString()))
                    {
                        if (string.IsNullOrEmpty(oldControl.Text))
                        {
                            MessageBox.Show("The " + (indexControl + 1) + "º field on old octet is empty. This can be dangerous.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            oldControl.Focus();
                            res = true;
                        }

                        if (string.IsNullOrEmpty(newControl.Text))
                        {
                            MessageBox.Show("The " + (indexControl + 1) + "º field on new octet is empty. This can be dangerous.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            oldControl.Focus();
                            res = true;
                        }
                    }
                }
            }

            return res;
        }

        private void tbItemID_TextChanged(object sender, EventArgs e)
        {
            int res = 0;

            if (int.TryParse(tbItemID.Text, out res))
            {
                tbItemID.Text = res.ToString();
            }
            else
            {
                tbItemID.Clear();
            }
        }

        private void cbGenericSolution_CheckedChanged(object sender, EventArgs e)
        {
            tbGeneric.Enabled = cbGenericSolution.Checked;

            if (cbGenericSolution.Checked)
            {
                btnCreateComponent.Enabled = false;
                btnRemoveComponent.Enabled = false;
            }
            else
            {
                btnCreateComponent.Enabled = true;
                btnRemoveComponent.Enabled = true;
            }
        }

        private void cbProctype_CheckedChanged(object sender, EventArgs e)
        {
            tbProctype.Enabled = cbProctype.Checked;
        }

        private void tbProctype_TextChanged(object sender, EventArgs e)
        {
            int res = 0;

            if (int.TryParse(tbProctype.Text, out res))
            {
                tbProctype.Text = res.ToString();
            }
            else
            {
                tbProctype.Clear();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}
