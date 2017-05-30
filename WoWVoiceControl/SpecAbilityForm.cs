using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWVoiceControl.Classes;

namespace WoWVoiceControl
{
    public partial class SpecAbilityForm : Form
    {
        string specName;
        string[] specAbilities;
        WoWClass @class;

        public SpecAbilityForm(WoWClass @class, string specName)
        {
            InitializeComponent();

            this.@class = @class;

            this.specName = specName;
            this.specAbilities = @class.ClassSpecialisationAbilityNames[specName];


            // If the ability name column is entered, deseslect. Ability name doesn't have to be selected.
            dgvAbilities.CellEnter += (sender, e) => { if (e.ColumnIndex == 0) (sender as DataGridView).ClearSelection(); };

            dgvAbilities.ClearSelection();

            dgvAbilities.KeyDown += dgvAbilities_KeyDown;

            dgvAbilities.CellEnter += dgvAbilities_CellEnter;
            dgvAbilities.CellLeave += dgvAbilities_CellLeave;
        }

        private void SpecAbilityForm_Load(object sender, EventArgs e)
        {
            Text = specName;

            // On load, iterate through known abilities and add them to datagridview. Perhaps in future allow for saving to and reading from file
            foreach (string ability in specAbilities)
            {
                int index = dgvAbilities.Rows.Add();

                dgvAbilities.Rows[index].Cells["abilityNameColumn"].Value = ability;
            }
        }

        // Clear cell if keybinding was not set
        private void dgvAbilities_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && (sender as DataGridView).CurrentCell.Value.Equals("Press key(s) to set keybinding..."))
                (sender as DataGridView).CurrentCell.Value = string.Empty;
        }

        // Prompt to set keybinding
        private void dgvAbilities_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
                (sender as DataGridView).CurrentCell.Value = "Press key(s) to set keybinding...";
        }

        // Set the cell to the formatted key value
        private void dgvAbilities_KeyDown(object sender, KeyEventArgs e)
        {
            if ((sender as DataGridView).CurrentCellAddress.X == 1)
            {
                string formattedString = KeyHelper.GetFormattedKeyString();

                if (formattedString.Contains("NumPad"))
                {
                    MessageBox.Show("Numpad keybinds not allowed (yet)");
                    return;
                }

                (sender as DataGridView).CurrentCell.Value = formattedString;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            // When start is clicked, iterate through table rows to set the keybindings to the key string that will be sent to SendKeys
            foreach (DataGridViewRow row in dgvAbilities.Rows)
            {
                if (row.Cells[1].Value == null)
                    continue;

                string ability = row.Cells[0].Value.ToString(), keybind = KeyHelper.GetKeyString(row.Cells[1].Value.ToString());

                @class.AddHotKey(ability, keybind);
            }

        }
    }
}
