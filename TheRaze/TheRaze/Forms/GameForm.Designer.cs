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
            label5 = new Label();
            txtItemId = new TextBox();
            txtQuantity = new TextBox();
            label6 = new Label();
            btnPickup = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtResetGameId = new TextBox();
            txtWidth = new TextBox();
            txtHeight = new TextBox();
            btnResetBoard = new Button();
            label10 = new Label();
            txtPlaceTileId = new TextBox();
            txtPlaceItemId = new TextBox();
            label11 = new Label();
            label12 = new Label();
            txtPlaceQty = new TextBox();
            btnPlaceItem = new Button();
            btnDeleteAccount = new Button();
            txtPlayerIdToDelete = new TextBox();
            label13 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(343, 12);
            label1.Name = "label1";
            label1.Size = new Size(206, 32);
            label1.TabIndex = 0;
            label1.Text = "Gameplay (TEST)";
            // 
            // txtPlayerGameId
            // 
            txtPlayerGameId.Location = new Point(12, 98);
            txtPlayerGameId.Margin = new Padding(3, 4, 3, 4);
            txtPlayerGameId.Name = "txtPlayerGameId";
            txtPlayerGameId.Size = new Size(114, 27);
            txtPlayerGameId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 2;
            label2.Text = "Player Game ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(726, 92);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 3;
            label3.Text = "Target Tile ID";
            // 
            // txtTargetTileId
            // 
            txtTargetTileId.Location = new Point(726, 116);
            txtTargetTileId.Margin = new Padding(3, 4, 3, 4);
            txtTargetTileId.Name = "txtTargetTileId";
            txtTargetTileId.Size = new Size(114, 27);
            txtTargetTileId.TabIndex = 4;
            // 
            // btnMove
            // 
            btnMove.Location = new Point(726, 185);
            btnMove.Margin = new Padding(3, 4, 3, 4);
            btnMove.Name = "btnMove";
            btnMove.Size = new Size(86, 31);
            btnMove.TabIndex = 5;
            btnMove.Text = "Move Player";
            btnMove.UseVisualStyleBackColor = true;
            btnMove.Click += btnMove_Click;
            // 
            // txtDelta
            // 
            txtDelta.Location = new Point(726, 269);
            txtDelta.Margin = new Padding(3, 4, 3, 4);
            txtDelta.Name = "txtDelta";
            txtDelta.Size = new Size(114, 27);
            txtDelta.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(726, 245);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 7;
            label4.Text = "Score";
            // 
            // btnAddScore
            // 
            btnAddScore.Location = new Point(681, 332);
            btnAddScore.Margin = new Padding(3, 4, 3, 4);
            btnAddScore.Name = "btnAddScore";
            btnAddScore.Size = new Size(86, 31);
            btnAddScore.TabIndex = 8;
            btnAddScore.Text = "Add Score";
            btnAddScore.UseVisualStyleBackColor = true;
            btnAddScore.Click += btnAddScore_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(785, 332);
            btnAdmin.Margin = new Padding(3, 4, 3, 4);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(86, 31);
            btnAdmin.TabIndex = 9;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 139);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 10;
            label5.Text = "Item ID:";
            // 
            // txtItemId
            // 
            txtItemId.Location = new Point(12, 163);
            txtItemId.Margin = new Padding(3, 4, 3, 4);
            txtItemId.Name = "txtItemId";
            txtItemId.Size = new Size(114, 27);
            txtItemId.TabIndex = 11;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(12, 220);
            txtQuantity.Margin = new Padding(3, 4, 3, 4);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(114, 27);
            txtQuantity.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 196);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 12;
            label6.Text = "Quantity:";
            // 
            // btnPickup
            // 
            btnPickup.Location = new Point(12, 255);
            btnPickup.Margin = new Padding(3, 4, 3, 4);
            btnPickup.Name = "btnPickup";
            btnPickup.Size = new Size(114, 31);
            btnPickup.TabIndex = 14;
            btnPickup.Text = "Pickup Item";
            btnPickup.UseVisualStyleBackColor = true;
            btnPickup.Click += btnPickup_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(200, 76);
            label7.Name = "label7";
            label7.Size = new Size(110, 20);
            label7.TabIndex = 15;
            label7.Text = "Reset Game ID:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(200, 132);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 16;
            label8.Text = "Width:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(200, 187);
            label9.Name = "label9";
            label9.Size = new Size(57, 20);
            label9.TabIndex = 17;
            label9.Text = "Height:";
            // 
            // txtResetGameId
            // 
            txtResetGameId.Location = new Point(200, 101);
            txtResetGameId.Margin = new Padding(3, 4, 3, 4);
            txtResetGameId.Name = "txtResetGameId";
            txtResetGameId.Size = new Size(114, 27);
            txtResetGameId.TabIndex = 18;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(200, 156);
            txtWidth.Margin = new Padding(3, 4, 3, 4);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(114, 27);
            txtWidth.TabIndex = 19;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(200, 211);
            txtHeight.Margin = new Padding(3, 4, 3, 4);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(114, 27);
            txtHeight.TabIndex = 20;
            // 
            // btnResetBoard
            // 
            btnResetBoard.Location = new Point(200, 246);
            btnResetBoard.Margin = new Padding(3, 4, 3, 4);
            btnResetBoard.Name = "btnResetBoard";
            btnResetBoard.Size = new Size(114, 31);
            btnResetBoard.TabIndex = 21;
            btnResetBoard.Text = "Reset Board";
            btnResetBoard.UseVisualStyleBackColor = true;
            btnResetBoard.Click += btnResetBoard_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(379, 76);
            label10.Name = "label10";
            label10.Size = new Size(55, 20);
            label10.TabIndex = 22;
            label10.Text = "Tile ID:";
            // 
            // txtPlaceTileId
            // 
            txtPlaceTileId.Location = new Point(379, 98);
            txtPlaceTileId.Margin = new Padding(3, 4, 3, 4);
            txtPlaceTileId.Name = "txtPlaceTileId";
            txtPlaceTileId.Size = new Size(114, 27);
            txtPlaceTileId.TabIndex = 23;
            // 
            // txtPlaceItemId
            // 
            txtPlaceItemId.Location = new Point(379, 156);
            txtPlaceItemId.Margin = new Padding(3, 4, 3, 4);
            txtPlaceItemId.Name = "txtPlaceItemId";
            txtPlaceItemId.Size = new Size(114, 27);
            txtPlaceItemId.TabIndex = 24;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(379, 132);
            label11.Name = "label11";
            label11.Size = new Size(100, 20);
            label11.TabIndex = 25;
            label11.Text = "Place Item ID:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(379, 187);
            label12.Name = "label12";
            label12.Size = new Size(74, 20);
            label12.TabIndex = 26;
            label12.Text = "Place Qty:";
            // 
            // txtPlaceQty
            // 
            txtPlaceQty.Location = new Point(379, 211);
            txtPlaceQty.Margin = new Padding(3, 4, 3, 4);
            txtPlaceQty.Name = "txtPlaceQty";
            txtPlaceQty.Size = new Size(114, 27);
            txtPlaceQty.TabIndex = 27;
            // 
            // btnPlaceItem
            // 
            btnPlaceItem.Location = new Point(379, 255);
            btnPlaceItem.Margin = new Padding(3, 4, 3, 4);
            btnPlaceItem.Name = "btnPlaceItem";
            btnPlaceItem.Size = new Size(114, 31);
            btnPlaceItem.TabIndex = 28;
            btnPlaceItem.Text = "Place Item";
            btnPlaceItem.UseVisualStyleBackColor = true;
            btnPlaceItem.Click += btnPlaceItem_Click;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.Location = new Point(12, 412);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(157, 29);
            btnDeleteAccount.TabIndex = 29;
            btnDeleteAccount.Text = "Delete My Account";
            btnDeleteAccount.UseVisualStyleBackColor = true;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // txtPlayerIdToDelete
            // 
            txtPlayerIdToDelete.Location = new Point(12, 378);
            txtPlayerIdToDelete.Margin = new Padding(3, 4, 3, 4);
            txtPlayerIdToDelete.Name = "txtPlayerIdToDelete";
            txtPlayerIdToDelete.Size = new Size(157, 27);
            txtPlayerIdToDelete.TabIndex = 30;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 354);
            label13.Name = "label13";
            label13.Size = new Size(137, 20);
            label13.TabIndex = 31;
            label13.Text = "Player ID to Delete:";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(label13);
            Controls.Add(txtPlayerIdToDelete);
            Controls.Add(btnDeleteAccount);
            Controls.Add(btnPlaceItem);
            Controls.Add(txtPlaceQty);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txtPlaceItemId);
            Controls.Add(txtPlaceTileId);
            Controls.Add(label10);
            Controls.Add(btnResetBoard);
            Controls.Add(txtHeight);
            Controls.Add(txtWidth);
            Controls.Add(txtResetGameId);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnPickup);
            Controls.Add(txtQuantity);
            Controls.Add(label6);
            Controls.Add(txtItemId);
            Controls.Add(label5);
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
            Margin = new Padding(3, 4, 3, 4);
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
        private Label label5;
        private TextBox txtItemId;
        private TextBox txtQuantity;
        private Label label6;
        private Button btnPickup;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtResetGameId;
        private TextBox txtWidth;
        private TextBox txtHeight;
        private Button btnResetBoard;
        private Label label10;
        private TextBox txtPlaceTileId;
        private TextBox txtPlaceItemId;
        private Label label11;
        private Label label12;
        private TextBox txtPlaceQty;
        private Button btnPlaceItem;
        private Button btnDeleteAccount;
        private TextBox txtPlayerIdToDelete;
        private Label label13;
    }
}