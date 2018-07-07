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
using Tmds.MDns;
using System.Threading;
using Newtonsoft.Json;
namespace NanoleafLightController.User_Controlls
{
    public partial class SetupUserControl : MetroUserControl
    {
        private string _ipAdress, _port, _authCode;
        List<string> nanoleafFound;
        ListBox listbox;
        
        public SetupUserControl()
        {
            InitializeComponent();
            SendMdnsDiscovery("_nanoleafapi._tcp");

        }

        private void SetupUserControl_Load(object sender, EventArgs e)
        {
            nanoleafFound = new List<string>();
            AddControlsToPanel(Buttons.NewSetupButton("btnSearchForNanoleafs", "Search for nanoleafs", OnClickSearchNanoleaf), 1, 1);

            AddControlsToPanel(new MetroLabel()
            {   Name = "lblInfoStepOne",
                Text = "First we need to find your\n nanoleaf lights on the \nnetwork.",
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            }, 1, 0);



        }


        private void OnClickSearchNanoleaf(object sender, EventArgs e)
        {
            if(nanoleafFound.Count==0)
            {
                RemoveControlsFromPanel("lblInfoStepOne");
                RemoveControlsFromPanel("lblNoNanoleafsFound");
                AddControlsToPanel(new Label()
                {
                    Name = "lblNoNanoleafsFound",
                    Text = "No nanoleafs found on the network, please check that your nanoleaf is connected and try again",
                    ForeColor = Color.Red,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, 1, 0);
            }
            if (nanoleafFound.Count>1)
            {
                RemoveControlsFromPanel("btnSearchForNanoleafs");
                AddControlsToPanel(new Label()
                {
                    Name = "lblMultipleNanoleafs",
                    Text = "Multiple nanoleafs found,please select one and click next",
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, 1, 1);

                listbox = new ListBox
                {
                   
                    DataSource = nanoleafFound,
                    Dock = DockStyle.Fill,
                    
                };
                listbox.SelectedIndexChanged += OnIndexChanged;
                AddControlsToPanel(listbox, 1, 2);
                

                AddControlsToPanel(Buttons.NewSetupButton("btnNext", "Next", OnClickNext), 2, 4);
                

            }
            if (nanoleafFound.Count == 1)
            {
                RemoveControlsFromPanel("btnSearchForNanoleafs");
                RemoveControlsFromPanel("lblInfoStepOne");

                AddControlsToPanel(new Label()
                {
                    Name = "lblOneNanoleaf",
                    Text = "Nanoleaf lights found at " + nanoleafFound[0],
                    ForeColor = Color.Green,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, 1, 0);

                AddControlsToPanel(new Label()
                {
                    Name = "lblClickNext",
                    Text = "Click next to continue the setup process",
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, 1, 1);

                AddControlsToPanel(Buttons.NewSetupButton("btnNext", "Next", OnClickNext),2,4);
                string[] splittedString = nanoleafFound[0].Split(':');
                _ipAdress = splittedString[0];
                _port = splittedString[1];
                
            }
            
           
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            string[] splittedString = listbox.SelectedItem.ToString().Split(':');
            _ipAdress = splittedString[0];
            _port = splittedString[1];
        }

        private void OnClickNext(object sender, EventArgs e)
        {
            tableLayoutPanelSetup.Controls.Clear();
            AddControlsToPanel(new Label()
            {
                Name = "lblInfoLastStep",
                Text = "Set nanoleaf lights into pair-mode, by holding power button 5 seconds. After that click pair button",
                
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            }, 1, 0);
           

            AddControlsToPanel(Buttons.NewSetupButton("btnSendRequest", "Send request", OnClickSendRequest), 1, 1);
        }

        private void OnClickSendRequest(object sender, EventArgs e)
        {
            RemoveControlsFromPanel("lblCantConnect");
            NanoleafApiWrapper apiWrapper = new NanoleafApiWrapper(_ipAdress, _port);
            _authCode = apiWrapper.GetToken();
            if (_authCode.Contains("System.Net.WebException"))
            {
                AddControlsToPanel(new Label()
                {
                    Name = "lblCantConnect",
                    Text = "Cant establish connection with the nanoleaf, try again. Remember to hold power button 5 seconds, untile light controller starts flashing",
                    ForeColor = Color.Red,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, 1, 2);
            }
            else
            {
                //select only the token, removes /auth_token/ atribute
                Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(apiWrapper.GetToken());
                _authCode = data["auth_token"];
                NanoleafConnectionInfo nCI = new NanoleafConnectionInfo()
                {
                    AuthCode = _authCode,
                    IpAdress = _ipAdress,
                    Port = _port
                };
                //Create a file with connection information
                ConnectionDocument cD = new ConnectionDocument(nCI);
                cD.CreateFile();

                if(cD.exceptionThrown==null)
                { 
                    RemoveControlsFromPanel("lblCantConnect");
                    AddControlsToPanel(new Label()
                    {
                        Name = "lblEstablishedConnection",
                        Text = "Connected to nanoleaf. Click continue to open control menu.",
                        ForeColor = Color.Green,
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    }, 1, 2);

                    AddControlsToPanel(Buttons.NewSetupButton("btnFinish", "Continue", OnClickContinue), 2, 4);
                }
            }
        }

        private void OnClickContinue(object sender, EventArgs e)
        {
            //TODO close the usercontrol, and open main usercontrol
            Form1.mainPanelActive = true;
            this.SendToBack();
        }

        private void OnServiceAdded(object o, ServiceAnnouncementEventArgs e)
        {
            
            nanoleafFound.Add(e.Announcement.Addresses[0].ToString() + ":" + e.Announcement.Port);
           
        }

        public void SendMdnsDiscovery(string name)
        {
            
            ServiceBrowser serviceBrowser = new ServiceBrowser();
            serviceBrowser.ServiceAdded += OnServiceAdded;
            serviceBrowser.StartBrowse(name);
        }

        public void RemoveControlsFromPanel(string controlName)
        {
            foreach (Control item in tableLayoutPanelSetup.Controls.OfType<Control>())
            {
                if (item.Name == controlName)
                    tableLayoutPanelSetup.Controls.Remove(item);
            }
        }

        public void AddControlsToPanel(Control ctr, int column, int row)
        {
            tableLayoutPanelSetup.Controls.Add(ctr, column, row);
        }
    }
}
