using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoleafLightController
{
    class Buttons 
    {
        public static MetroButton NewSetupButton(string name, string text,EventHandler e)
        {
            MetroButton btn = new MetroButton
            {
                Name = name,
                Text = text,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btn.Click += new EventHandler(e);

            return btn;
        }

       
    }
}
