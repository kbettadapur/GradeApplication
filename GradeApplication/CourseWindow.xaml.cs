using GradeApplication.Models;
using GradeApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GradeApplication
{
    /// <summary>
    /// Interaction logic for CourseWindow.xaml
    /// </summary>
    public partial class CourseWindow : Window
    {
        public CourseWindow(Course course, ObservableCollection<Course> Courses)
        {
            InitializeComponent();
            DataContext = new CourseWindowViewModel(this, course, Courses);
            
            //ClassName.Text = course.Name;
        }

        public void Closer()
        {
            this.Close();
            
        }

        public void ClearListView()
        {
            DataContext = null;
        }

    }
}
