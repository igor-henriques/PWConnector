using PWConnector.Utils;

namespace PWConnector.Forms;

public partial class MainForm : Form
{
    private readonly MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString());
    private int amountSwitched = 0, amountErased = 0;
    private Gamedbd gamedbd;
    private List<Account> allAccounts;
    private List<GRoleData> Roles = new List<GRoleData>();

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

            await LoadRoles(conf);

            btnConnect.Text = $"Loaded {allAccounts.Count} accounts | {Roles.Count} roles.";
            EnableElements(true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "ERRO");
        }
    }

    private async Task LoadRoles(ConfigurationsForm conf)
    {
        this.gamedbd = new Gamedbd(conf.Host, conf.Port);

        PWGlobal.UsedPwVersion = conf.version;

        this.allAccounts = await GetAllAccounts(connection, gamedbd);

        foreach (var account in allAccounts.Where(x => x != null))
        {
            foreach (var role in account.Roles)
            {
                try
                {
                    Roles.Add(GetRoleData.Get(gamedbd, role.Id));
                }
                catch (Exception)
                {
                    MessageBox.Show($"Impossible to get information from role ID {role.Id}");
                }
            }
        }
    }

    private async Task<List<Account>> GetAllAccounts(MySqlConnection conn, IPwDaemonConfig gamedbd)
    {
        var accounts = await DAO.GetAccounts();

        progressBar.Maximum = accounts.Count;

        List<Role> allRoles = new();

        for (int i = 0; i < accounts.Count; i++)
        {
            var accountRoles = GetUserRoles.Get(gamedbd, accounts[i].Id).ToRoleList();

            if (accountRoles != null)
            {
                accounts[i].Roles = accounts[i].Roles ?? accountRoles;

                if (accounts[i].Roles?.Count <= 0)
                    accounts[i].Roles.AddRange(accountRoles);
            }

            if (i % 6 == 0)
            {
                progressBar.Value = allRoles.Count > progressBar.Maximum ? progressBar.Maximum : allRoles.Count;
            }
        }

        progressBar.Value = progressBar.Maximum;

        return accounts;
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
    }

    private void btnRemoveComponent_Click(object sender, EventArgs e)
    {
        if (flowLayoutNew.Controls.Count > 0 && flowLayoutOld.Controls.Count > 0)
        {
            flowLayoutOld.Controls.RemoveAt(flowLayoutOld.Controls.Count - 1);
            flowLayoutNew.Controls.RemoveAt(flowLayoutNew.Controls.Count - 1);
        }
    }

    private async void btnSwitch_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(tbItemID.Text.Trim()))
            {
                EnableElements(false);

                var octetRelations = BuildOctetRelations();

                amountSwitched = 0;

                foreach (var role in Roles.Where(x => x != null))
                {
                    if (octetRelations.Count <= 0)
                    {
                        role.GRolePocket.Items = await LoopInventory(role.GRolePocket.Items, null, false);
                        role.GRoleEquipment.Items = await LoopInventory(role.GRoleEquipment.Items, null, false);
                        role.GRoleStorehouse.Items = await LoopInventory(role.GRoleStorehouse.Items, null, false);

                        PutRoleData.Put(gamedbd, role);
                    }
                    else
                    {
                        foreach (var relation in octetRelations)
                        {
                            role.GRolePocket.Items = await LoopInventory(role.GRolePocket.Items, relation, false);
                            role.GRoleEquipment.Items = await LoopInventory(role.GRoleEquipment.Items, relation, false);
                            role.GRoleStorehouse.Items = await LoopInventory(role.GRoleStorehouse.Items, relation, false);

                            PutRoleData.Put(gamedbd, role);
                        }
                    }
                }

                MessageBox.Show($"{amountSwitched} items affected.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableElements(true);
            }
            else
            {
                tbItemID.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public async Task<GRoleInventory[]> LoopInventory(GRoleInventory[] inventory, OctetRelation octetRelation, bool removeItem)
    {
        try
        {
            List<GRoleInventory> toRemove = new List<GRoleInventory>();

            var currentInventory = inventory;

            if (removeItem)
            {
                foreach (var item in currentInventory)
                {
                    if (item.Id.Equals(int.Parse(tbItemRemove.Text)))
                    {
                        amountErased++;
                        toRemove.Add(item);
                    }
                }

                currentInventory = Array.FindAll(currentInventory, x => !toRemove.Contains(x));
            }
            else
            {
                foreach (var item in currentInventory)
                {
                    if (tbGeneric.Enabled)
                    {
                        if (item.Id.Equals(int.Parse(tbItemID.Text.Trim())))
                        {
                            item.Octet = tbGeneric.Text.Trim();
                            item.Proctype = cbProctype.Checked ? int.Parse(tbProctype.Text) : item.Proctype;

                            amountSwitched++;
                        }
                    }
                    else
                    {
                        if (item.Octet.Equals(octetRelation.oldOctet) && item.Id.Equals(int.Parse(tbItemID.Text)))
                        {
                            item.Octet = octetRelation.newOctet;
                            item.Proctype = cbProctype.Checked ? int.Parse(tbProctype.Text) : item.Proctype;

                            amountSwitched++;
                        }
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
                    int.TryParse(oldControl.Name.Replace("tbOld", default), out int indexControl);

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
                int.TryParse(oldControl.Name.Replace("tbOld", default), out int indexControl);

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
        if (int.TryParse(tbItemID.Text, out int res))
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
            cbProctype.Checked = false;
            btnCreateComponent.Enabled = true;
            btnRemoveComponent.Enabled = true;
        }
    }

    private void cbProctype_CheckedChanged(object sender, EventArgs e)
    {
        tbProctype.Enabled = cbProctype.Checked;

        if (cbProctype.Checked)
            cbGenericSolution.Checked = cbProctype.Checked;
    }

    private void tbProctype_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(tbProctype.Text, out int res))
        {
            tbProctype.Text = res.ToString();
        }
        else
        {
            tbProctype.Clear();
        }
    }

    private async void btnDel_Click(object sender, EventArgs e)
    {
        EnableElements(false);

        amountErased = 0;

        foreach (var role in Roles.Where(x => x != null))
        {
            role.GRolePocket.Items = await LoopInventory(role.GRolePocket.Items, null, true);
            role.GRoleEquipment.Items = await LoopInventory(role.GRoleEquipment.Items, null, true);
            role.GRoleStorehouse.Items = await LoopInventory(role.GRoleStorehouse.Items, null, true);

            PutRoleData.Put(gamedbd, role);
        }

        MessageBox.Show($"{amountErased} items erased.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        EnableElements(true);
    }

    private void panel1_MouseEnter(object sender, EventArgs e)
    {
        EnableElements(false);
    }

    private void panel1_MouseLeave(object sender, EventArgs e)
    {
        EnableElements(true);
    }
}