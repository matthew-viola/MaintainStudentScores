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
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }
        List<int> updatedlist = new List<int>();
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            Student s = (Student)Tag;
            updatedlist = s.Scores;
            txtName.Text = s.Name;
            for(int i = 0; i < s.Scores.Count; i++)
            {
                libxScores.Items.Add(s.Scores[i]);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form f = new UpdateAdd();
            f.ShowDialog();
            if(f.DialogResult == DialogResult.OK)
            {
                int newscore = (int)f.Tag;
                libxScores.Items.Add(newscore);
                updatedlist.Add(newscore);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selected = libxScores.SelectedIndex;
            Form f = new UpdateUpdate();
            if (selected != -1)
            {
                f.Tag = updatedlist[selected];
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    int newscore = (int)f.Tag;
                    //      MessageBox.Show(newscore.ToString());
                    libxScores.Items.RemoveAt(selected);
                    libxScores.Items.Insert(selected, newscore);
                    updatedlist[selected] = newscore;
                }
            }
            else
            {
                return;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selected = libxScores.SelectedIndex;
            if (selected != -1) {
                libxScores.Items.RemoveAt(selected);
                updatedlist.RemoveAt(selected);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            libxScores.Items.Clear();
            updatedlist.Clear();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Student s = new Student(txtName.Text, updatedlist);
            Tag = s;
            DialogResult = DialogResult.OK;
        }
    }
}
