using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eleon_SCADA.Forms
{
    public partial class Form_VestasParameterTool : Form
    {
        public Form_VestasParameterTool()
        {
            InitializeComponent();
        }



        private void button_Change_Click(object sender, EventArgs e)
        {
            int Group;
            int Index;
            short OldValue;
            short NewValue;

            try
            {
                Group = Convert.ToInt16(textBox_Group1.Text);
                Index = Convert.ToInt16(textBox_Index1.Text);
                OldValue = Convert.ToInt16(textBox_Old.Text);
                NewValue = Convert.ToInt16(textBox_New.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input value - \n" + ex.Message, "Error");
                return;
            }

            try
            {
                Program.myVestasController.Change_Parameter(1, Group, Index, OldValue, NewValue);
                MessageBox.Show("Parameter changed", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            int Group;
            int Index;
            Park.Parameter_Info ParamInfo;

            textBox_Value.Text = "";
            textBox_Text.Text = "";

            try
            {
                Group = Convert.ToInt16(textBox_Group2.Text);
                Index = Convert.ToInt16(textBox_Index2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input value - \n" + ex.Message, "Error");
                return;
            }

            try
            {
                ParamInfo = Program.myVestasController.Read_Parameter(1, Group, Index);
                textBox_Group2.Text = ParamInfo.Group.ToString();
                textBox_Index2.Text = ParamInfo.Index.ToString();
                textBox_Value.Text = ParamInfo.Value.ToString();
                textBox_Text.Text = ParamInfo.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }
    }
}
