using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeApplication.Models
{
    public class Category
    {
        public ObservableCollection<Grade> Grades { get; set; }
        public string CategoryName { get; set; }
        public double CategoryWeight
        {
            get; set;
        }
        public double AverageCategory
        {
            get
            {
                if (Grades.Count() == 0) return 0;
                double sum = 0;
                foreach (Grade grade in Grades)
                {
                    sum += grade.Value;
                }
                return Math.Round(sum / (Grades.Count()), 2);
            }
        }

        public Category(string CategoryName, double CategoryWeight, ObservableCollection<Grade> Grades)
        {
            this.CategoryName = CategoryName;
            this.CategoryWeight = CategoryWeight;
            this.Grades = Grades;
        }
        public Category(string CategoryName, double CategoryWeight)
        {
            this.CategoryName = CategoryName;
            this.CategoryWeight = CategoryWeight;
            Grades = new ObservableCollection<Grade>();
        }
    }
}
