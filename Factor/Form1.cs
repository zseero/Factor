using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Factor
{
    public partial class Form1 : Form
    {
        FactorHandler factor;
        public Form1()
        {
            InitializeComponent();
            factor = new FactorHandler(input, output);
        }

        private void letsfactor_Click(object sender, EventArgs e)
        {
            factor.Run();
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            factor.Run();
        }
    }
}
