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

        public formSaveBackup()
        {
            InitializeComponent();

            localAppDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            saveLocations = new BindingList<string>(new List<string>());
            this.comboBoxFrequency.DataSource = frequencies;
            settings = new Dictionary<string, int>();

            try
            {
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

            this.comboBoxSaves.DataSource = saveLocations;
            int value = 0;
            if (settings.TryGetValue(this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem), out value))
            {
                this.comboBoxFrequency.SelectedItem = value;
            }
            else
            {
                this.comboBoxFrequency.SelectedItem = 0;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string selectedItem = this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem);

            settings.Remove(selectedItem);
            saveLocations.Remove(selectedItem);
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            string saveLocation = this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem);
            string[] files = Directory.GetFiles(saveLocation);

            foreach (string s in files)
            {
                if (Path.GetExtension(s).Equals(".bak"))
                {
                    File.Copy(s, s.Remove(s.Length - 4, 4), true);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string selectedItem = this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem);

            settings[selectedItem] = int.Parse(this.comboBoxFrequency.GetItemText(this.comboBoxFrequency.SelectedItem));

            if (!saveLocations.Contains(selectedItem))
            {
                saveLocations.Add(selectedItem);
            }
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            List<string> settingsList = new List<string>();
            foreach(string s in settings.Keys)
            {
                settingsList.Add(s + ',' + settings[s]);
            }
            File.WriteAllLines(Path.Combine(localAppDir, APP_DIR, SAVE_LOCATIONS_FILE), settingsList);
        }

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

        private void comboBoxSaves_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int value = 0;
            if (settings.TryGetValue(this.comboBoxSaves.GetItemText(this.comboBoxSaves.SelectedItem), out value))
            {
                this.comboBoxFrequency.SelectedItem = value;
            }
            else
            {
                this.comboBoxFrequency.SelectedItem = 0;
            }
        }
    }
}
