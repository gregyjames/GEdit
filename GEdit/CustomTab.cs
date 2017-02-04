using MaterialSkin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEdit
{
    public class CustomTab : TabPage
    {
        public static userSettings LoadSettings(Boolean x)
        {
            userSettings mySettings = new userSettings();
            if (File.Exists("settings.json"))
            {
                using (StreamReader file = File.OpenText(@"settings.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    mySettings = (userSettings)serializer.Deserialize(file, typeof(userSettings));
                }
            }

            return mySettings;
        }

        public String fileName = "";
        public userSettings settings = LoadSettings(true);

        public CustomTab()
        {
            this.Text = "New Tab";
            var hor = new SplitContainerX();
            var con = new ConsoleControl.ConsoleControl();
            con.StopProcess();
            var _text = new CustomText(settings);


            con.Name = "CON";

            con.Dock = DockStyle.Fill;
            con.BackColor = ((int)settings.Primary).ToColor();
            con.BorderStyle = BorderStyle.None;
            con.Padding = new Padding(0);
            con.Margin = new Padding(0);
            con.InternalRichTextBox.BorderStyle = BorderStyle.None;
            this.Controls.Add(hor);
            hor.Panel1.Controls.Add(_text);

            hor.Panel2.Controls.Add(con);
            hor.Panel2Collapsed = true;
        }
    }
    }
