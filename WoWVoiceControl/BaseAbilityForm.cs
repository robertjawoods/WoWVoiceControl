using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWVoiceControl.Classes;

namespace WoWVoiceControl
{
    public partial class BaseAbilityForm : Form
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        
        WoWClass chosenClass;

        public BaseAbilityForm(WoWClass @class)
        {
            InitializeComponent();

            chosenClass = @class;

            // If the ability name column is entered, deseslect. Ability name doesn't have to be selected.
            dgvAbilities.CellEnter += (sender, e) => { if (e.ColumnIndex == 0) (sender as DataGridView).ClearSelection(); };

            dgvAbilities.ClearSelection();

            dgvAbilities.KeyDown += dgvAbilities_KeyDown;

            this.Icon = @class.ClassIcon;

            dgvAbilities.CellEnter += dgvAbilities_CellEnter;
            dgvAbilities.CellLeave += dgvAbilities_CellLeave;
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

        private void AbilityForm_Load(object sender, EventArgs e)
        {
            Text = chosenClass.ClassName;

            GenerateSpecButtons();

            // On load, iterate through known abilities and add them to datagridview. Perhaps in future allow for saving to and reading from file
            foreach (string ability in chosenClass.ClassAbilityNames)
            {
                int index = dgvAbilities.Rows.Add();

                dgvAbilities.Rows[index].Cells["abilityNameColumn"].Value = ability;
            }
        }

        private void GenerateSpecButtons()
        {
            int totalButtons = chosenClass.ClassSpecialisationAbilityNames.Count;

            int gapSize = 50, buttonWith = (dgvAbilities.Width / totalButtons) - (gapSize / totalButtons);

            int buttonCount = 0;

            Point lastButtonPosition = new Point();


            foreach (string spec in chosenClass.ClassSpecialisationAbilityNames.Keys)
            {
                Button button = new Button();

                if (buttonCount == 0)
                    button.Location = new Point(dgvAbilities.Location.X, dgvAbilities.Location.Y - button.Height - 15);
                else
                    button.Location = new Point(lastButtonPosition.X + buttonWith+ gapSize, lastButtonPosition.Y);

                button.Text = spec;

                lastButtonPosition = button.Location;

                button.Width = buttonWith;

                button.Click += Button_Click;

                Controls.Add(button);

                buttonCount++;

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            FormProvider.SpecAbilityForm(chosenClass, (sender as Button).Text).Show();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {

            // When start is clicked, iterate through table rows to set the keybindings to the key string that will be sent to SendKeys
            foreach (DataGridViewRow row in dgvAbilities.Rows)
            {
                if (row.Cells[1].Value == null)
                    continue;

                string ability = row.Cells[0].Value.ToString(), keybind = KeyHelper.GetKeyString(row.Cells[1].Value.ToString());

                chosenClass.AddHotKey(ability, keybind);
            }

            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            Process p = Process.GetProcessesByName("Wow-64").FirstOrDefault();
            IntPtr h = p.MainWindowHandle;
            recEngine.LoadGrammarAsync(chosenClass.GenerateGrammar());
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string key;
            try
            {
                chosenClass.ClassAbilityBindings.TryGetValue(e.Result.Text, out key);
                SendKeys.Send(key);
            }
            catch
            {
                SpeechSynthesizer mySynth = new SpeechSynthesizer();
                mySynth.SpeakAsync("This ability is not bound!");
            }
        }
    }
}
