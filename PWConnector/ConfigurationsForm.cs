using PWToolKit;
using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWConnector
{
    public partial class ConfigurationsForm : Form
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public PwVersion version { get; set; }
        public ConfigurationsForm(string host)
        {
            InitializeComponent();

            tbHost.Text = host;
            tbPort.Text = "29400";

            btnOk.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Host = "35.247.236.143";
            Port = 29400;
            
            if (!(string.IsNullOrEmpty(tbHost.Text) || string.IsNullOrEmpty(tbPort.Text) || cbVersion.SelectedIndex < 0))
            {                
                Host = tbHost.Text;
                Port = int.Parse(tbPort.Text);
                version = (PwVersion)cbVersion.SelectedItem;

                MessageBox.Show("The following procedure will possible take a few time because it requests all roles on every account. Please be patient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                if (string.IsNullOrEmpty(tbHost.Text))
                    tbHost.Focus();
                else if (string.IsNullOrEmpty(tbPort.Text))
                    tbPort.Focus();
                else if (cbVersion.SelectedIndex < 0)
                    cbVersion.Focus();
            }
        }

        private void tbHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPort.Focus();
            }
        }

        private void tbPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }

        private void ConfigurationsForm_Load(object sender, EventArgs e)
        {
            var values = Enum.GetValues(typeof(PwVersion));

            foreach (var value in values)
            {
                cbVersion.Items.Add(value);
            }
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            int res = 0;

            if (int.TryParse(tbPort.Text, out res))
            {
                tbPort.Text = res.ToString();
            }
            else
            {
                tbPort.Clear();
            }
        }
    }
}
