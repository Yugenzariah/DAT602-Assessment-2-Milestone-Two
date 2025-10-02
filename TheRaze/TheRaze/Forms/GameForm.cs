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

namespace TheRaze.Forms
{
    public partial class GameForm : Form
    {
        private readonly GameDao _game = new GameDao();

        public GameForm()
        {
            InitializeComponent();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtPlayerGameId.Text, out var pgId))
                {
                    MessageBox.Show("Enter a valid PlayerGameID (number).");
                    return;
                }
                if (!uint.TryParse(txtTargetTileId.Text, out var tileId))
                {
                    MessageBox.Show("Enter a valid TargetTileID (number).");
                    return;
                }

                _game.MovePlayer(pgId, tileId);
                MessageBox.Show("Moved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Move failed: " + ex.Message);
            }
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtPlayerGameId.Text, out var pgId))
                {
                    MessageBox.Show("Enter a valid PlayerGameID (number).");
                    return;
                }
                if (!int.TryParse(txtDelta.Text, out var delta))
                {
                    MessageBox.Show("Enter a valid Score Δ (integer).");
                    return;
                }

                _game.AddScore(pgId, delta);
                MessageBox.Show("Score updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Score update failed: " + ex.Message);
            }
        }


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            new AdminForm().ShowDialog(this);
        }

        private void btnPickup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtPlayerGameId.Text, out var pgId))
                {
                    MessageBox.Show("Enter a valid PlayerGameID.");
                    return;
                }
                if (!uint.TryParse(txtItemId.Text, out var itemId))
                {
                    MessageBox.Show("Enter a valid ItemID.");
                    return;
                }
                if (!short.TryParse(txtQuantity.Text, out var qty))
                {
                    MessageBox.Show("Enter a valid Quantity.");
                    return;
                }
                _game.PickupItem(pgId, itemId, qty);
                MessageBox.Show("Item picked up successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pickup failed: " + ex.Message);
            }
        }

        private void btnResetBoard_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtResetGameId.Text, out var gameId))
                {
                    MessageBox.Show("Enter a valid Reset Game ID.");
                    return;
                }
                if (!int.TryParse(txtWidth.Text, out var width) || width <= 0)
                {
                    MessageBox.Show("Enter a valid Width (positive number).");
                    return;
                }
                if (!int.TryParse(txtHeight.Text, out var height) || height <= 0)
                {
                    MessageBox.Show("Enter a valid Height (positive number).");
                    return;
                }
                _game.ResetBoard(gameId, width, height);
                MessageBox.Show("Board reset successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset board failed: " + ex.Message);
            }
        }

        private void btnPlaceItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtPlaceTileId.Text, out var tileId))
                {
                    MessageBox.Show("Enter a valid Tile ID.");
                    return;
                }
                if (!uint.TryParse(txtPlaceItemId.Text, out var itemId))
                {
                    MessageBox.Show("Enter a valid Place Item ID.");
                    return;
                }
                if (!short.TryParse(txtPlaceQty.Text, out var qty))
                {
                    MessageBox.Show("Enter a valid Place Qty.");
                    return;
                }
                _game.PlaceItemOnTile(tileId, itemId, qty);
                MessageBox.Show("Item placed on tile successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Place item failed: " + ex.Message);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uint.TryParse(txtPlayerIdToDelete.Text, out var playerId))
                {
                    MessageBox.Show("Enter a valid Player ID to Delete.");
                    return;
                }

                var result = MessageBox.Show(
                    "Are you sure you want to delete this account? This cannot be undone!",
                    "Delete Account",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var auth = new AuthDao();
                    auth.DeleteOwnAccount(playerId);
                    MessageBox.Show("Account deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete account failed: " + ex.Message);
            }
        }
    }
}
