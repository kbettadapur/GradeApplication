using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeApplication.Models;
using System.Collections.ObjectModel;

namespace GradeApplication.ViewModels
{
    public class CourseWindowViewModel : ViewModel
    {
      
        private CourseWindow courseWin;
        public Course Course { get; set; }
        public double CourseAverage
        {
            get { return Course.CourseAverage; }
        }
        public ObservableCollection<Course> Courses { get; set; }
        public string CategoryName { get; set; }
        public double CategoryWeight { get; set; }
        
               
        public RelayCommand OnReturnBtnClickedCommand { get; set; }
        public RelayCommand AddCategoryCommand { get; set; }
        public RelayCommand AddGradeCommand { get; set; }
        public RelayCommand RemoveGradeCommand { get; set; }
        public RelayCommand RemoveCategoryCommand { get; set; }
        public double GradeInput { get; set; }

        
       
        /*public bool isEnabled {
            get
            {
                double weightNum = 0;
                foreach (Category c in CourseClicked.Categories)
                {
                    weightNum += Double.Parse(c.WeightText);
                }
                if (weightNum < 100) { return true; }
                else { return false; }
                    
            }
            set { }
        }*/
        

        public CourseWindowViewModel(CourseWindow cWin, Course CurrentCourse, ObservableCollection<Course> Courses)
        {
            this.Courses = Courses;
            Course = CurrentCourse;
            RemoveCategoryCommand = new RelayCommand(RemoveCategory);
            RemoveGradeCommand = new RelayCommand(RemoveGrade);
            AddCategoryCommand = new RelayCommand(AddCategory);
            OnReturnBtnClickedCommand = new RelayCommand(OnReturnBtnClicked);
            AddGradeCommand = new RelayCommand(AddGrade);
            courseWin = cWin;
            
            Console.WriteLine("Course Categories: " + Course.Categories.Count());         
        }
        
        public void OnReturnBtnClicked(object parameter)
        {
            Console.WriteLine("Button Clicked");
            Saver.SaveData(Courses);
            Course.Categories.Clear();
            new MainWindow().Show();
            courseWin.ClearListView();
            courseWin.Closer();
            
        }

        public void AddCategory(object parameter)
        {
            double doubleWeight = 0;
            if (CategoryWeight == 0.0D)
            {
                CategoryWeight = 0;
            }
            Category NewCategory = new Category(this.CategoryName, this.CategoryWeight);
            
            Course.Categories.Add(NewCategory);
            Saver.SaveData(Courses);
        }

        public void AddGrade(object sender)
        {
            if (GradeInput == 0.0D)
            {
                GradeInput = 0;
            }
            Category SelectedCategory = (Category)sender;
            SelectedCategory.Grades.Add(new Grade(GradeInput));
            OnPropertyChanged("CourseAverage");
            Saver.SaveData(Courses);
        }

        public void RemoveGrade(object sender)
        {   
            Console.WriteLine(sender);
        }

        public void RemoveCategory(object sender)
        {
            Category categoryToRemove = (Category)sender;
            Course.Categories.Remove(categoryToRemove);
            OnPropertyChanged("CourseAverage");
            Saver.SaveData(Courses);
        }

        public void Test()
        {
            //Console.WriteLine("CategoryListItem: " + CategoryListItem);
            //Console.WriteLine("GradeListItem: " + GradeListItem);
        }

    }
}
