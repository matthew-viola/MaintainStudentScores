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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        List<Student> studentlist = new List<Student>();
        private void btnNew_Click(object sender, EventArgs e)
        {
            Form addnew = new Add();
            addnew.ShowDialog();
            if (addnew.DialogResult == DialogResult.OK)
            {
                Student s = (Student)addnew.Tag;
                studentlist.Add(s);
                liStudents.Items.Add(DisplayList(s));
            }
            else
            {
                return;
            }
        }
        private string DisplayList(Student s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(s.Name);
            sb.Append(" | ");
            sb.Append(string.Join(" | ", s.Scores));
            return sb.ToString();
        }

        private void liStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liStudents.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                int selected = liStudents.SelectedIndex;
                List<int> sc = studentlist[selected].Scores;
                int t = studentlist[selected].Scores.Count;
                int total = 0;
                int count = 0;
                int a = 0;
                for (int i = 0; i < t; i++)
                {
                    total += sc[i];
                }
                count = sc.Count;
                if (count != 0)
                {
                    a = total / count;
                    txtTotal.Text = total.ToString();
                    txtCount.Text = count.ToString();
                    txtAvg.Text = a.ToString();
                }
                else
                {
                    return;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selected = liStudents.SelectedIndex;
            Form f = new frmUpdate();
            if (selected != -1)
            {
                f.Tag = studentlist[selected];
                f.ShowDialog();
                Student s = (Student)f.Tag;
                studentlist.RemoveAt(selected);
                studentlist.Insert(selected, s);
                liStudents.Items.RemoveAt(selected);
                liStudents.Items.Insert(selected, DisplayList(s));
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selected = liStudents.SelectedIndex;
            if (selected != -1)
            {
                liStudents.Items.RemoveAt(selected);
                studentlist.RemoveAt(selected);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<int> s1 = new List<int>();
            s1.Add(90);
            s1.Add(80);
            s1.Add(85);
            string n1 = "Danny Devito";
            List<int> s2 = new List<int>();
            s2.Add(75);
            s2.Add(65);
            s2.Add(85);
            string n2 = "Charlie Day";
            List<int> s3 = new List<int>();
            s3.Add(75);
            s3.Add(80);
            s3.Add(40);
            string n3 = "Glenn Howerton";
            Student sample1 = new Student(n1, s1);
            Student sample2 = new Student(n2, s2);
            Student sample3 = new Student(n3, s3);
            studentlist.Add(sample1);
            studentlist.Add(sample2);
            studentlist.Add(sample3);
            liStudents.Items.Add(DisplayList(sample1));
            liStudents.Items.Add(DisplayList(sample2));
            liStudents.Items.Add(DisplayList(sample3));
        }
    }
}
