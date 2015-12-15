using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GradeApplication.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

using GradeApplication.Models;

namespace GradeApplication
{
    public partial class GradeViewModel:ViewModel
    {
        public RelayCommand SaverCommand { get; set; }
        public RelayCommand AddCourseCommand { get; set; }
        public RelayCommand RemoveCourseCommand { get; set; }
        public MainWindow mainWin;
        public string CourseName { get; set; }
        public ObservableCollection<Course> CourseList { get; set; }
        public bool AddCourseClickable { get; set; }
        public Course courseToBeAdded;
        private Course _listItem;
        public Course ListItem
        {
            get
            {
                if (_listItem != null)
                {
                    ItemClicked(_listItem);
                }
                return null;
            }
            set { _listItem = value; }
        }
     
        public GradeViewModel(MainWindow win)
        {
            mainWin = win;
            RemoveCourseCommand = new RelayCommand(RemoveCourse);
            AddCourseCommand = new RelayCommand(AddCourse);
            CourseList = Saver.LoadData();
        }

        public void AddCourse(object parameter)
        {
            CourseList.Add(new Course(CourseName));
            OnPropertyChanged("CourseList");
            
            Saver.SaveData(CourseList);
        }

        public void RemoveCourse(object sender)
        {
            Course removableCourse = (Course)sender;
            CourseList.Remove(removableCourse);
            foreach (Course i in CourseList)
            {
                Console.WriteLine("Course: " + i.Name);
            }

            Saver.SaveData(CourseList);
        }

        public void ItemClicked(object listItem)
        {
            new CourseWindow((Course)listItem, CourseList).Show();
            mainWin.Closer();
        }

    }
}