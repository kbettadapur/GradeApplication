using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeApplication.Models
{
    public class Course
    {
        public Course(string name, ObservableCollection<Category> Categories)
        {
            this.Name = name;
            this.Categories = Categories;
        }

        public Course(string name)
        {
            this.Name = name;
            this.Categories = new ObservableCollection<Category>();
        }

        public string Name { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public double CourseAverage
        {
            get
            {
                if (Categories.Count() == 0)
                {
                    return 0;
                }
                double totalWeight = 0;
                double average = 0;
                foreach (Category c in Categories)
                {
                    if (c.Grades.Count() != 0) totalWeight += c.CategoryWeight;
                }
                foreach (Category c in Categories)
                {
                    if (c.Grades.Count() != 0) average += c.AverageCategory * (c.CategoryWeight / totalWeight);
                }
                return Math.Round(average, 2);
            }
        }
    }
}
