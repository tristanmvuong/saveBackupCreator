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
    public partial class Form1 : Form
    {
        private readonly string localAppDir;
        private BindingList<string> saveLocations;
        private readonly string APP_DIR = "SaveBackupCreator";
        private readonly string SAVE_LOCATIONS_FILE = "saveLocations.txt";

        public Form1()
        {
            InitializeComponent();

            localAppDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            saveLocations = new BindingList<string>(new List<string>());

            try
            {
                saveLocations = new BindingList<string>(new List<string>(File.ReadAllLines(Path.Combine(localAppDir, APP_DIR, SAVE_LOCATIONS_FILE))));
            }
            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory(Path.Combine(localAppDir, APP_DIR));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            this.comboBox1.DataSource = saveLocations;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (!saveLocations.Contains(dialog.SelectedPath))
                    {
                        saveLocations.Add(dialog.SelectedPath);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveLocations.Remove(this.comboBox1.GetItemText(this.comboBox1.SelectedItem));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string saveLocation = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            string[] files = Directory.GetFiles(saveLocation);

            foreach (string s in files)
            {
                if (Path.GetExtension(s).Equals(".bak"))
                {
                    File.Copy(s, s.Remove(s.Length - 4, 4), true);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(Path.Combine(localAppDir, APP_DIR, SAVE_LOCATIONS_FILE), saveLocations);
        }
    }
}
