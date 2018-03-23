using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using Newtonsoft.Json;
using System.IO;

namespace GEdit
{
    public partial class Settings : MaterialForm
    {
        public userSettings mySettings;

        public void LoadSettings()
        {
            if (File.Exists("settings.json"))
            {
                using (StreamReader file = File.OpenText(@"settings.json"))
                {
                    mySettings = new userSettings();
                    JsonSerializer serializer = new JsonSerializer();
                    mySettings = (userSettings)serializer.Deserialize(file, typeof(userSettings));
                }
            }
        }

        public Settings()
        {
            InitializeComponent();
            LoadSettings();
            var skinmanager = MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkinManager.Themes.DARK;
            if (mySettings == null)
            {
                skinmanager.ColorScheme = new ColorScheme(MaterialSkin.Primary.BlueGrey800, MaterialSkin.Primary.BlueGrey800, MaterialSkin.Primary.BlueGrey50, MaterialSkin.Accent.Green200, MaterialSkin.TextShade.WHITE);
            }
            else
            {
                skinmanager.ColorScheme = new ColorScheme(mySettings.Primary, mySettings.Primary, mySettings.Primary, mySettings.Accent, MaterialSkin.TextShade.WHITE);
            }
        }

        public T GetEnumValue<T>(int intValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val = ((T[])Enum.GetValues(typeof(T)))[0];

            foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
            {
                if (Convert.ToInt32(enumValue).Equals(intValue))
                {
                    val = enumValue;
                    break;
                }
            }
            return val;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.FromArgb(51, 51, 51);
            comboBox2.BackColor = Color.FromArgb(51, 51, 51);

            var Pcolor = GetEnumValue<Primary>((int)mySettings.Primary);

            comboBox1.Text = Pcolor.ToString();

            var Acolor = GetEnumValue<Accent>((int)mySettings.Accent);

            comboBox2.Text = Acolor.ToString();

            foreach (var item in Enum.GetValues(typeof(MaterialSkin.Primary)))
            {
                comboBox1.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(MaterialSkin.Accent)))
            {
                comboBox2.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySettings.Primary = (MaterialSkin.Primary)comboBox1.SelectedItem;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySettings.Accent = (MaterialSkin.Accent)comboBox2.SelectedItem;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            JsonSerializer ser = new JsonSerializer();
            JsonWriter writer;

            using (StreamWriter file = File.CreateText(@"settings.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, mySettings);
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            fc[0].Refresh();
        }
    }
    }
    public class userSettings
    {
        public Primary Primary { get; set; }
        public Accent Accent { get; set; }

        public userSettings(Primary Main, Accent Secondary)
        {
            Primary = Main;
            Accent = Secondary;
        }

    public userSettings()
    {
    }
}
