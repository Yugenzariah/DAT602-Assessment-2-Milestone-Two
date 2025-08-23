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
    }
}
