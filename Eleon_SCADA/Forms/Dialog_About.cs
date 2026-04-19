using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
{
    public partial class Dialog_About : Form
    {
        public Dialog_About()
        {
            InitializeComponent();

            System.Reflection.Assembly thisAssem = typeof(Program).Assembly;
            System.Reflection.AssemblyName thisAssemName = thisAssem.GetName();

            Version ver = thisAssemName.Version;

            label_Version.Text = ver.ToString();
            
        }

        private void Form_About_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
