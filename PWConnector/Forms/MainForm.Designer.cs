namespace PWConnector.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnConnect = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnCreateComponent = new System.Windows.Forms.Button();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.flowLayoutOld = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutNew = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.cbGenericSolution = new System.Windows.Forms.CheckBox();
            this.tbGeneric = new System.Windows.Forms.TextBox();
            this.cbProctype = new System.Windows.Forms.CheckBox();
            this.tbProctype = new System.Windows.Forms.TextBox();
            this.tbItemRemove = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRemoveComponent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(11, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(276, 37);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Get All Roles";
            this.toolTip.SetToolTip(this.btnConnect, "The first step: get all roles to inspect their inventory.");
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnEquips_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 54);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(275, 21);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            // 
            // btnCreateComponent
            // 
            this.btnCreateComponent.Enabled = false;
            this.btnCreateComponent.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.btnCreateComponent.Location = new System.Drawing.Point(11, 84);
            this.btnCreateComponent.Name = "btnCreateComponent";
            this.btnCreateComponent.Size = new System.Drawing.Size(232, 32);
            this.btnCreateComponent.TabIndex = 1;
            this.btnCreateComponent.Text = "Create Octet Relation";
            this.toolTip.SetToolTip(this.btnCreateComponent, "Each click create an relation which you can choose which octet will be replace by" +
        " other");
            this.btnCreateComponent.UseVisualStyleBackColor = true;
            this.btnCreateComponent.Click += new System.EventHandler(this.btnCreateComponent_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Enabled = false;
            this.btnSwitch.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.btnSwitch.Location = new System.Drawing.Point(11, 683);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(276, 37);
            this.btnSwitch.TabIndex = 4;
            this.btnSwitch.Text = "Switch";
            this.toolTip.SetToolTip(this.btnSwitch, "Run the modifications.");
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // flowLayoutOld
            // 
            this.flowLayoutOld.AutoScroll = true;
            this.flowLayoutOld.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutOld.Location = new System.Drawing.Point(11, 182);
            this.flowLayoutOld.MinimumSize = new System.Drawing.Size(106, 366);
            this.flowLayoutOld.Name = "flowLayoutOld";
            this.flowLayoutOld.Size = new System.Drawing.Size(133, 366);
            this.flowLayoutOld.TabIndex = 8;
            this.flowLayoutOld.WrapContents = false;
            // 
            // flowLayoutNew
            // 
            this.flowLayoutNew.AutoScroll = true;
            this.flowLayoutNew.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutNew.Location = new System.Drawing.Point(154, 182);
            this.flowLayoutNew.MinimumSize = new System.Drawing.Size(106, 366);
            this.flowLayoutNew.Name = "flowLayoutNew";
            this.flowLayoutNew.Size = new System.Drawing.Size(133, 366);
            this.flowLayoutNew.TabIndex = 8;
            this.flowLayoutNew.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Old Octet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(179, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Octet";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.LinkColor = System.Drawing.Color.Black;
            this.linkLabel.Location = new System.Drawing.Point(86, 728);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(111, 15);
            this.linkLabel.TabIndex = 10;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Created by Ironside";
            this.toolTip.SetToolTip(this.linkLabel, "Discord: Ironside#3862");
            this.linkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // tbItemID
            // 
            this.tbItemID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbItemID.Enabled = false;
            this.tbItemID.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemID.Location = new System.Drawing.Point(128, 126);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.Size = new System.Drawing.Size(159, 22);
            this.tbItemID.TabIndex = 3;
            this.toolTip.SetToolTip(this.tbItemID, "The ID Target Item which will be affected");
            this.tbItemID.TextChanged += new System.EventHandler(this.tbItemID_TextChanged);
            // 
            // cbGenericSolution
            // 
            this.cbGenericSolution.AutoSize = true;
            this.cbGenericSolution.Enabled = false;
            this.cbGenericSolution.Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.cbGenericSolution.Location = new System.Drawing.Point(12, 554);
            this.cbGenericSolution.Name = "cbGenericSolution";
            this.cbGenericSolution.Size = new System.Drawing.Size(145, 24);
            this.cbGenericSolution.TabIndex = 14;
            this.cbGenericSolution.Text = "Generic Solution:";
            this.toolTip.SetToolTip(this.cbGenericSolution, "Enable this if you want to replace every octet by this indenpendent of anything");
            this.cbGenericSolution.UseVisualStyleBackColor = true;
            this.cbGenericSolution.CheckedChanged += new System.EventHandler(this.cbGenericSolution_CheckedChanged);
            // 
            // tbGeneric
            // 
            this.tbGeneric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGeneric.Enabled = false;
            this.tbGeneric.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGeneric.Location = new System.Drawing.Point(154, 554);
            this.tbGeneric.Name = "tbGeneric";
            this.tbGeneric.Size = new System.Drawing.Size(126, 22);
            this.tbGeneric.TabIndex = 15;
            this.tbGeneric.Text = "0";
            this.toolTip.SetToolTip(this.tbGeneric, "Generic octet which will be switched on every target item");
            // 
            // cbProctype
            // 
            this.cbProctype.AutoSize = true;
            this.cbProctype.Enabled = false;
            this.cbProctype.Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.cbProctype.Location = new System.Drawing.Point(12, 586);
            this.cbProctype.Name = "cbProctype";
            this.cbProctype.Size = new System.Drawing.Size(125, 24);
            this.cbProctype.TabIndex = 19;
            this.cbProctype.Text = "New Proctype:";
            this.toolTip.SetToolTip(this.cbProctype, "Enable this if you want to replace every proctype by this indenpendent of anythin" +
        "g");
            this.cbProctype.UseVisualStyleBackColor = true;
            this.cbProctype.CheckedChanged += new System.EventHandler(this.cbProctype_CheckedChanged);
            // 
            // tbProctype
            // 
            this.tbProctype.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProctype.Enabled = false;
            this.tbProctype.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProctype.Location = new System.Drawing.Point(154, 586);
            this.tbProctype.Name = "tbProctype";
            this.tbProctype.Size = new System.Drawing.Size(126, 22);
            this.tbProctype.TabIndex = 17;
            this.tbProctype.Text = "0";
            this.toolTip.SetToolTip(this.tbProctype, "New proctype on every item");
            this.tbProctype.TextChanged += new System.EventHandler(this.tbProctype_TextChanged);
            // 
            // tbItemRemove
            // 
            this.tbItemRemove.BackColor = System.Drawing.Color.Brown;
            this.tbItemRemove.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbItemRemove.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemRemove.ForeColor = System.Drawing.Color.White;
            this.tbItemRemove.Location = new System.Drawing.Point(173, 19);
            this.tbItemRemove.Name = "tbItemRemove";
            this.tbItemRemove.Size = new System.Drawing.Size(62, 22);
            this.tbItemRemove.TabIndex = 17;
            this.tbItemRemove.Text = "0";
            this.tbItemRemove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tbItemRemove, "DANGER AREA");
            this.tbItemRemove.TextChanged += new System.EventHandler(this.tbItemID_TextChanged);
            this.tbItemRemove.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.tbItemRemove.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Location = new System.Drawing.Point(173, 41);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(62, 2);
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox4, "DANGER AREA");
            this.pictureBox4.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbItemRemove);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Location = new System.Drawing.Point(-10, 618);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 57);
            this.panel1.TabIndex = 20;
            this.toolTip.SetToolTip(this.panel1, "DANGER AREA");
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "REMOVE ITEM (ID):";
            this.toolTip.SetToolTip(this.label4, "DANGER AREA");
            this.label4.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // btnDel
            // 
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(237, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 51);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "DEL";
            this.toolTip.SetToolTip(this.btnDel, "DANGER AREA");
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            this.btnDel.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.btnDel.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // btnRemoveComponent
            // 
            this.btnRemoveComponent.Enabled = false;
            this.btnRemoveComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveComponent.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoveComponent.Location = new System.Drawing.Point(248, 84);
            this.btnRemoveComponent.Name = "btnRemoveComponent";
            this.btnRemoveComponent.Size = new System.Drawing.Size(39, 31);
            this.btnRemoveComponent.TabIndex = 2;
            this.btnRemoveComponent.Text = "-";
            this.btnRemoveComponent.UseVisualStyleBackColor = true;
            this.btnRemoveComponent.Click += new System.EventHandler(this.btnRemoveComponent_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Target Item ID:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(128, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 1);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(154, 574);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(126, 1);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(154, 606);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(126, 1);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(297, 750);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbProctype);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tbProctype);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tbGeneric);
            this.Controls.Add(this.cbGenericSolution);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbItemID);
            this.Controls.Add(this.btnRemoveComponent);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutNew);
            this.Controls.Add(this.flowLayoutOld);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.btnCreateComponent);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Octet Switcher";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnCreateComponent;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutOld;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnRemoveComponent;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbGenericSolution;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbGeneric;
        private System.Windows.Forms.CheckBox cbProctype;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbProctype;
        private System.Windows.Forms.TextBox tbItemRemove;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDel;
    }
}

