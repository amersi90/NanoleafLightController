using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.IO;
using Newtonsoft.Json;
namespace NanoleafLightController.User_Controlls
{

    public partial class MainUserControl : MetroUserControl
    {
        private string _path;
        NanoleafConnectionInfo connectionDetails;
        NanoleafApiWrapper apiWrapper;

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }

        public MainUserControl()
        {
            InitializeComponent();
        }

        private void MainUserControl_Load(object sender, EventArgs e)
        {

            
            _path = new FileInfo().GetFilePath();
            connectionDetails = JsonDeserializer.ConvertFromFile(_path);
            apiWrapper = new NanoleafApiWrapper(connectionDetails.IpAdress, connectionDetails.Port, connectionDetails.AuthCode);
            
            InitializeValues();
            listBox1.DataSource = JsonDeserializer.ListOfEffects(apiWrapper.GetEffets());
            Console.WriteLine(apiWrapper.GetEffets());
           


        }

        private void btnToogleLight_Click(object sender, EventArgs e)
        {
            if (apiWrapper.GetLightStatus())
            {
                btnToogleLight.BackgroundImage = NanoleafLightController.Properties.Resources.light_off;
                apiWrapper.SetState(false);
            }
            else
            {
                btnToogleLight.BackgroundImage = NanoleafLightController.Properties.Resources.light_on;
                apiWrapper.SetState(true);
                apiWrapper.SetBrightness(tbChangeBrightness.Value);
            }
        }
        public void InitializeValues()
        {
            btnToogleLight.BackgroundImage = NanoleafLightController.Properties.Resources.light_off;
            tbChangeBrightness.Value = apiWrapper.GetLightBrightness();
            lblBrightness.Text = tbChangeBrightness.Value.ToString()+"%";

            if (apiWrapper.GetLightStatus())
                btnToogleLight.BackgroundImage = NanoleafLightController.Properties.Resources.light_on;

            

        }

        private void tbChangeBrightness_ValueChanged(object sender, EventArgs e)
        {
            if(apiWrapper.GetLightStatus())
                apiWrapper.SetBrightness(tbChangeBrightness.Value);
            
            lblBrightness.Text = tbChangeBrightness.Value.ToString() + "%";
            
        }

        private void tblPanelMainMiddle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnApplyEffect_Click(object sender, EventArgs e)
        {
            if(apiWrapper.GetLightStatus())
            {
                apiWrapper.SetEffect(listBox1.SelectedItem.ToString());
            }
        }

        private void CommonColorsHandler(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;

            if(apiWrapper.GetLightStatus())
            {
                apiWrapper.SetColor(ctr.ForeColor);
            }
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog cD = new ColorDialog();
            cD.ShowDialog();
            if (apiWrapper.GetLightStatus())
                apiWrapper.SetColor(cD.Color);
        }
    }
}
