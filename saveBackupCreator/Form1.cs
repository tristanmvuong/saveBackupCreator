//windows form for backing up save files

#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace saveBackupCreator
{
    public partial class formSaveBackup : Form
    {
        private readonly string localAppDir;
        private BindingList<string> saveLocations;
        private readonly string APP_DIR = "SaveBackupCreator";
        private readonly string SAVE_LOCATIONS_FILE = "saveLocations.txt";
        private readonly BindingList<int> frequencies = new BindingList<int>(new int[] {0, 1, 5, 10, 15, 30});
        private Dictionary<string, int> settings;
        private Timer timer1;

        public formSaveBackup()
        {
            InitializeComponent();

            localAppDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            saveLocations = new BindingList<string>(new List<string>());
            this.comboBoxFrequency.DataSource = frequencies;
            settings = new Dictionary<string, int>();

            try
            {
                //retrieves locations of save files and backup frequency that were written to the settings file
                string[] settingsFromFile = File.ReadAllLines(Path.Combine(localAppDir, APP_DIR, SAVE_LOCATIONS_FILE));
                foreach (string s in settingsFromFile)
                {
                    string[] setting = s.Split(',');
                    if (!settings.ContainsKey(setting[0]))
                    {
                        settings.Add(setting[0], int.Parse(setting[1]));
                    }
                }
                saveLocations = new BindingList<string>(new List<string>(settings.Keys));
            }
            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory(Path.Combine(localAppDir, APP_DIR));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            //sets the selected frequency to either a saved value or 0
            this.comboBoxSaves.DataSource = saveLocations;
            if (settings.TryGetValue(this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem), out int value))
            {
                this.comboBoxFrequency.SelectedItem = value;
            }
            else
            {
                this.comboBoxFrequency.SelectedItem = 0;
            }
        }

        //deletes a saved location
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string selectedItem = this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem);

            settings.Remove(selectedItem);
            saveLocations.Remove(selectedItem);
        }

        //removes the .bak from the latest backup
        private void buttonRestore_Click(object sender, EventArgs e)
        {
            string saveLocation = this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem);
            if (!Directory.Exists(saveLocation))
            {
                return;
            }

            string[] files = Directory.GetFiles(saveLocation);

            foreach (string s in files)
            {
                if (Path.GetExtension(s).Equals(".bak"))
                {
                    File.Copy(s, s.Remove(s.Length - 4, 4), true);
                }
            }
        }

        //updates the save location and backup frequency in a temporary data structure
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string selectedItem = this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem);

            settings[selectedItem] = int.Parse(this.comboBoxFrequency.GetItemText(this.comboBoxFrequency.SelectedItem));

            if (!saveLocations.Contains(selectedItem))
            {
                saveLocations.Add(selectedItem);
            }
        }

        //writes the latest updates to the settings file
        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            List<string> settingsList = new List<string>();
            foreach(string s in settings.Keys)
            {
                settingsList.Add(s + ',' + settings[s]);
            }
            File.WriteAllLines(Path.Combine(localAppDir, APP_DIR, SAVE_LOCATIONS_FILE), settingsList);
        }

        //brings up the browse folder dialog so the save location can be chosen
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (!saveLocations.Contains(dialog.SelectedPath))
                    {
                        saveLocations.Add(dialog.SelectedPath);
                    }
                    this.comboBoxSaves.SelectedItem = dialog.SelectedPath;
                }
            }
        }

        //backup frequency is always set to a value
        private void comboBoxSaves_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (settings.TryGetValue(this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem), out int value))
            {
                this.comboBoxFrequency.SelectedItem = value;
            }
            else
            {
                this.comboBoxFrequency.SelectedItem = 0;
            }
        }
        
        //save backup tick start
        private void buttonStart_Click(object sender, EventArgs e)
        {
            int interval = int.Parse(this.comboBoxFrequency.GetItemText(this.comboBoxFrequency.SelectedItem)) * 60 * 1000;
            if (interval <= 0)
            {
                return;
            }

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = interval; // in miliseconds
            timer1.Start();

            this.buttonStart.Enabled = false;
            this.buttonUpdate.Enabled = false;
            this.buttonDelete.Enabled = false;
            this.buttonRestore.Enabled = false;
            this.comboBoxFrequency.Enabled = false;
            this.comboBoxSaves.Enabled = false;
        }

        //save backup tick stops
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Stop();
            }

            this.buttonStart.Enabled = true;
            this.buttonUpdate.Enabled = true;
            this.buttonDelete.Enabled = true;
            this.buttonRestore.Enabled = true;
            this.comboBoxFrequency.Enabled = true;
            this.comboBoxSaves.Enabled = true;
        }

        //creates a copy of the latest .sav file in the chosen location
        private void timer1_Tick(object sender, EventArgs e)
        {
            string saveLocation = this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem);
            if (!Directory.Exists(saveLocation))
            {
                return;
            }

            string[] files = Directory.GetFiles(saveLocation);
            string latest = null;
            DateTime latestTime = DateTime.MinValue;

            foreach (string s in files)
            {
                if (Path.GetExtension(s).Equals(".sav"))
                {
                    if (File.GetLastWriteTime(s).CompareTo(latestTime) >= 0)
                    {
                        latestTime = File.GetLastWriteTime(s);
                        latest = s;
                    }
                    File.Copy(s, s.Remove(s.Length - 4, 4), true);
                }
            }

            if (latest != null)
            {
                string copy = Path.Combine(saveLocation, long.Parse(latestTime.ToString("yyyyMMddHHmmss")) + ".sav.bak");
                File.Copy(latest, copy, true);
            }
        }
    }
}
