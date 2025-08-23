using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheRaze.Data;
using TheRaze.Utils;

namespace TheRaze.Forms
{
    public partial class AdminForm : Form
    {
        private readonly AdminDao _admin = new AdminDao();

        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtGameId.Text, out var gameId))
                {
                    MessageBox.Show("Enter a valid GameID (number).");
                    return;
                }
                _admin.KillGame(gameId);
                MessageBox.Show("Game killed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kill failed: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var u = txtU.Text.Trim();
                var e1 = txtE.Text.Trim();
                var p = txtP.Text; // prototype password
                var isAdmin = chkAdmin.Checked;

                if (string.IsNullOrWhiteSpace(u) || string.IsNullOrWhiteSpace(e1) || string.IsNullOrEmpty(p))
                {
                    MessageBox.Show("Please fill username, email, and password.");
                    return;
                }

                _admin.AddPlayer(u, e1, HashHelper.FakeHash(p), isAdmin);
                MessageBox.Show("Player added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtPlayerId.Text, out var playerId))
                {
                    MessageBox.Show("Enter a valid PlayerID.");
                    return;
                }
                var u = txtU2.Text.Trim();
                var e2 = txtE2.Text.Trim();
                var p2 = txtP2.Text; // prototype password
                var isAdmin = chkAdmin2.Checked;
                var isLocked = chkLocked2.Checked;

                if (string.IsNullOrWhiteSpace(u) || string.IsNullOrWhiteSpace(e2) || string.IsNullOrEmpty(p2))
                {
                    MessageBox.Show("Please fill username, email, and password.");
                    return;
                }

                _admin.UpdatePlayer(playerId, u, e2, HashHelper.FakeHash(p2), isAdmin, isLocked);
                MessageBox.Show("Player updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtPlayerIdDel.Text, out var playerId))
                {
                    MessageBox.Show("Enter a valid PlayerID.");
                    return;
                }
                _admin.DeletePlayer(playerId);
                MessageBox.Show("Player deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }
    }
}
