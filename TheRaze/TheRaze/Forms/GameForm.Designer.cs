namespace TheRaze.Forms
{
    partial class GameForm
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
            label1 = new Label();
            txtPlayerGameId = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtTargetTileId = new TextBox();
            btnMove = new Button();
            txtDelta = new TextBox();
            label4 = new Label();
            btnAddScore = new Button();
            btnAdmin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 9);
            label1.Name = "label1";
            label1.Size = new Size(162, 25);
            label1.TabIndex = 0;
            label1.Text = "Gameplay (TEST)";
            // 
            // txtPlayerGameId
            // 
            txtPlayerGameId.Location = new Point(335, 130);
            txtPlayerGameId.Name = "txtPlayerGameId";
            txtPlayerGameId.Size = new Size(100, 23);
            txtPlayerGameId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(335, 112);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 2;
            label2.Text = "Player Game ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(335, 170);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 3;
            label3.Text = "Target Tile ID";
            // 
            // txtTargetTileId
            // 
            txtTargetTileId.Location = new Point(335, 188);
            txtTargetTileId.Name = "txtTargetTileId";
            txtTargetTileId.Size = new Size(100, 23);
            txtTargetTileId.TabIndex = 4;
            // 
            // btnMove
            // 
            btnMove.Location = new Point(335, 240);
            btnMove.Name = "btnMove";
            btnMove.Size = new Size(75, 23);
            btnMove.TabIndex = 5;
            btnMove.Text = "Move Player";
            btnMove.UseVisualStyleBackColor = true;
            btnMove.Click += btnMove_Click;
            // 
            // txtDelta
            // 
            txtDelta.Location = new Point(335, 303);
            txtDelta.Name = "txtDelta";
            txtDelta.Size = new Size(100, 23);
            txtDelta.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(335, 285);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Score";
            // 
            // btnAddScore
            // 
            btnAddScore.Location = new Point(296, 350);
            btnAddScore.Name = "btnAddScore";
            btnAddScore.Size = new Size(75, 23);
            btnAddScore.TabIndex = 8;
            btnAddScore.Text = "Add Score";
            btnAddScore.UseVisualStyleBackColor = true;
            btnAddScore.Click += btnAddScore_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(387, 350);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(75, 23);
            btnAdmin.TabIndex = 9;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdmin);
            Controls.Add(btnAddScore);
            Controls.Add(label4);
            Controls.Add(txtDelta);
            Controls.Add(btnMove);
            Controls.Add(txtTargetTileId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPlayerGameId);
            Controls.Add(label1);
            Name = "GameForm";
            Text = "GameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPlayerGameId;
        private Label label2;
        private Label label3;
        private TextBox txtTargetTileId;
        private Button btnMove;
        private TextBox txtDelta;
        private Label label4;
        private Button btnAddScore;
        private Button btnAdmin;
    }
}