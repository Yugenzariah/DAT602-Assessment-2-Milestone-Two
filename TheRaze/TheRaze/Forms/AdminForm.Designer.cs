namespace TheRaze.Forms
{
    partial class AdminForm
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtGameId = new TextBox();
            btnKill = new Button();
            groupBox2 = new GroupBox();
            txtU = new TextBox();
            txtE = new TextBox();
            txtP = new TextBox();
            chkAdmin = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            chkAdmin2 = new CheckBox();
            txtE2 = new TextBox();
            txtU2 = new TextBox();
            txtPlayerId = new TextBox();
            txtP2 = new TextBox();
            chkLocked2 = new CheckBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            txtPlayerIdDel = new TextBox();
            btnDelete = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnKill);
            groupBox1.Controls.Add(txtGameId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(33, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(127, 115);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kill Game";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Game ID";
            // 
            // txtGameId
            // 
            txtGameId.Location = new Point(6, 37);
            txtGameId.Name = "txtGameId";
            txtGameId.Size = new Size(100, 23);
            txtGameId.TabIndex = 1;
            // 
            // btnKill
            // 
            btnKill.Location = new Point(19, 77);
            btnKill.Name = "btnKill";
            btnKill.Size = new Size(75, 23);
            btnKill.TabIndex = 2;
            btnKill.Text = "Kill";
            btnKill.UseVisualStyleBackColor = true;
            btnKill.Click += btnKill_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtP);
            groupBox2.Controls.Add(btnAdd);
            groupBox2.Controls.Add(txtU);
            groupBox2.Controls.Add(chkAdmin);
            groupBox2.Controls.Add(txtE);
            groupBox2.Location = new Point(166, 31);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(209, 169);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add Player";
            // 
            // txtU
            // 
            txtU.Location = new Point(6, 19);
            txtU.Name = "txtU";
            txtU.PlaceholderText = "Username";
            txtU.Size = new Size(100, 23);
            txtU.TabIndex = 2;
            // 
            // txtE
            // 
            txtE.Location = new Point(6, 48);
            txtE.Name = "txtE";
            txtE.PlaceholderText = "Email";
            txtE.Size = new Size(100, 23);
            txtE.TabIndex = 3;
            // 
            // txtP
            // 
            txtP.Location = new Point(6, 77);
            txtP.Name = "txtP";
            txtP.PlaceholderText = "Password";
            txtP.Size = new Size(100, 23);
            txtP.TabIndex = 4;
            // 
            // chkAdmin
            // 
            chkAdmin.AutoSize = true;
            chkAdmin.Location = new Point(6, 106);
            chkAdmin.Name = "chkAdmin";
            chkAdmin.Size = new Size(73, 19);
            chkAdmin.TabIndex = 5;
            chkAdmin.Text = "Is Admin";
            chkAdmin.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(6, 131);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(6, 200);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // chkAdmin2
            // 
            chkAdmin2.AutoSize = true;
            chkAdmin2.Location = new Point(6, 150);
            chkAdmin2.Name = "chkAdmin2";
            chkAdmin2.Size = new Size(73, 19);
            chkAdmin2.TabIndex = 10;
            chkAdmin2.Text = "Is Admin";
            chkAdmin2.UseVisualStyleBackColor = true;
            // 
            // txtE2
            // 
            txtE2.Location = new Point(6, 89);
            txtE2.Name = "txtE2";
            txtE2.PlaceholderText = "Email";
            txtE2.Size = new Size(100, 23);
            txtE2.TabIndex = 9;
            // 
            // txtU2
            // 
            txtU2.Location = new Point(6, 60);
            txtU2.Name = "txtU2";
            txtU2.PlaceholderText = "Username";
            txtU2.Size = new Size(100, 23);
            txtU2.TabIndex = 8;
            // 
            // txtPlayerId
            // 
            txtPlayerId.Location = new Point(6, 31);
            txtPlayerId.Name = "txtPlayerId";
            txtPlayerId.PlaceholderText = "Player ID";
            txtPlayerId.Size = new Size(100, 23);
            txtPlayerId.TabIndex = 7;
            // 
            // txtP2
            // 
            txtP2.Location = new Point(6, 118);
            txtP2.Name = "txtP2";
            txtP2.PlaceholderText = "Password";
            txtP2.Size = new Size(100, 23);
            txtP2.TabIndex = 12;
            // 
            // chkLocked2
            // 
            chkLocked2.AutoSize = true;
            chkLocked2.Location = new Point(6, 175);
            chkLocked2.Name = "chkLocked2";
            chkLocked2.Size = new Size(75, 19);
            chkLocked2.TabIndex = 13;
            chkLocked2.Text = "Is Locked";
            chkLocked2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtP2);
            groupBox3.Controls.Add(chkLocked2);
            groupBox3.Controls.Add(txtPlayerId);
            groupBox3.Controls.Add(txtU2);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(txtE2);
            groupBox3.Controls.Add(chkAdmin2);
            groupBox3.Location = new Point(381, 31);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 236);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Update Player";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnDelete);
            groupBox4.Controls.Add(txtPlayerIdDel);
            groupBox4.Location = new Point(587, 31);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(200, 100);
            groupBox4.TabIndex = 15;
            groupBox4.TabStop = false;
            groupBox4.Text = "Delete Player";
            // 
            // txtPlayerIdDel
            // 
            txtPlayerIdDel.Location = new Point(6, 33);
            txtPlayerIdDel.Name = "txtPlayerIdDel";
            txtPlayerIdDel.PlaceholderText = "Player ID";
            txtPlayerIdDel.Size = new Size(100, 23);
            txtPlayerIdDel.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(6, 71);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 450);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "AdminForm";
            Text = "AdminForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnKill;
        private TextBox txtGameId;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox txtU;
        private TextBox txtE;
        private TextBox txtP;
        private CheckBox chkAdmin;
        private Button btnAdd;
        private Button btnUpdate;
        private CheckBox chkAdmin2;
        private TextBox txtE2;
        private TextBox txtU2;
        private TextBox txtPlayerId;
        private TextBox txtP2;
        private CheckBox chkLocked2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button btnDelete;
        private TextBox txtPlayerIdDel;
    }
}