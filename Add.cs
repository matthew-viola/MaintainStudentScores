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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }
        List<int> sendit = new List<int>();
        private void Add_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int score = Convert.ToInt32(txtScore.Text);
                if (score <= 100 && score >= 0)
                {
                    sendit.Add(score);
                    txtScoreList.Text = string.Join(" ", sendit);
                    txtScore.Text = "";
                    txtScore.Focus();
                }
                else
                {
                    MessageBox.Show("Enter a score between 0 and 100");
                    txtScore.Focus();
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter a valid score");
                txtScore.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScoreList.Text = "";
            sendit = new List<int>();
            txtScore.Text = "";
            txtScore.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                Student newstudent = new Student(Convert.ToString(txtName.Text), sendit);
                Tag = newstudent;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
        }
    }
}
