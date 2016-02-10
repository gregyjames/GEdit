using GEdit.Properties;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GEdit
{
    public sealed class Texttab : TabPage
    {
        private CustomText _text;

        public string FILENAME = "";

        settings mySettings;

        void getSettings()
        {
            var fileName = "";

            if (File.Exists(@"settings.xml"))
            {
                fileName = "settings.xml";
            }

            else
            {
                fileName = Directory.GetCurrentDirectory() + "\\Themes\\Default.xml";
            }

            Parallel.Invoke(() => {
                using (var myFileStream = new FileStream(fileName, FileMode.Open))
                {
                    var mySerializer = new XmlSerializer(typeof(settings));

                    settings obj = (settings)mySerializer.Deserialize(myFileStream);

                    mySettings = obj;
                }
            });
        }

        public Texttab()
        {
            getSettings();
            _text = new CustomText(mySettings);
            
            Controls.Add(_text);
            Text = Resources.Texttab_Texttab_New_Tab;
        }


    }
}
