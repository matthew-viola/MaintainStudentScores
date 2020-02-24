using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintainStudentScores
{
    public partial class UpdateAdd : Form
    {
        public UpdateAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int add = Convert.ToInt32(txtScore.Text);
                if(add >= 0 && add <= 100)
                {
                    Tag = add;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a score between 0 and 100");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid score");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateAdd_Load(object sender, EventArgs e)
        {
            txtScore.Focus();
        }
    }
}
