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
    public partial class UpdateUpdate : Form
    {
        public UpdateUpdate()
        {
            InitializeComponent();
        }

        private void UpdateUpdate_Load(object sender, EventArgs e)
        {
            txtScore.Text = Tag.ToString();
            txtScore.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int update = Convert.ToInt32(txtScore.Text);
                if (update >= 0 && update <= 100)
                {
                    Tag = update;
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
            Close();
        }
    }
}
