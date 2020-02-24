using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainStudentScores
{
    class Student
    {
        public string Name { get; set; }
        public List<int> Scores { get; set; }

        public Student(string name, List<int> scores)
        {
            this.Name = name;
            this.Scores = scores;
        }
        public Student()
        {

        }
       public int ScoreCount
        {
            get
            {
                return ScoreCount;
            }
            set
            {
                ScoreCount = Scores.Count;
            }
        }
        public int ScoreTotal
        {
            get
            {
                return ScoreTotal;
            }
            set
            {
                for(int i = 0; i < Scores.Count; i++)
                {
                    ScoreTotal += Scores[i];
                }
            }
        }
        public int Avg
        {
            get
            {
                return Avg;
            }
            set
            {
                Avg = ScoreTotal / ScoreCount;
            }
        }
    }
}
