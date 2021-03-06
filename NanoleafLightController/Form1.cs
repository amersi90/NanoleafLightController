﻿using MetroFramework.Controls;
using MetroFramework.Forms;
using NanoleafLightController.User_Controlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoleafLightController
{
    public partial class Form1 : MetroForm
    {
        private string _path;
        public bool toogle;
        public static bool mainPanelActive;



       

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            _path = new FileInfo().GetFilePath();
            this.Size = new Size(431, 160);
            this.Resizable = false;
            this.ShadowType = MetroFormShadowType.None;
            if (!File.Exists(_path))
            {
                
                this.Size = new Size(431, 550);
                SetupUserControl setupUserControl = new SetupUserControl();
                setupUserControl.BringToFront();
                metroMainPanel.Controls.Add(setupUserControl);


            }
            else
            {
                metroMainPanel.Controls.Add(new MainUserControl());
                mainPanelActive = true;
                lblResizeForm.Text = "v";

            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            if(mainPanelActive)
            {
                if (!toogle)
                {
                    lblResizeForm.Text = "^";
                    this.Size = new Size(431, 550);
                    
                }
                else
                {
                   
                    lblResizeForm.Text = "v";
                    this.Size = new Size(431, 160);

                }
                toogle = !toogle;
            }
            
            
            
            
        }
        
    }
}
