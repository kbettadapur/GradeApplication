using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeApplication.Models
{
    public class Saver
    {
        public static void SaveData(ObservableCollection<Course> courses)
        {
            string SaveString = "";
            StreamWriter FileWriter = new StreamWriter("SavedData.txt");
            for (int i = 0; i < courses.Count(); i++)
            {
                SaveString = SaveString + courses[i].Name + ",";
                for (int j = 0; j < courses[i].Categories.Count(); j++)
                {
                    SaveString = SaveString + courses[i].Categories[j].CategoryName;
                    SaveString = SaveString + "|" + courses[i].Categories[j].CategoryWeight.ToString();

                    if (!(j == courses[i].Categories.Count() - 1) && courses[i].Categories[j].Grades.Count() == 0)
                    {
                        SaveString = SaveString + "/";
                    }
                    else if (courses[i].Categories[j].Grades.Count() != 0)
                    {
                        SaveString = SaveString + "|";
                    }

                    if (j==courses[i].Categories.Count() - 1 && courses[i].Categories[j].Grades.Count() == 0)
                    {
                        SaveString = SaveString + Environment.NewLine;
                    }
                    
                    for (int k = 0; k < courses[i].Categories[j].Grades.Count(); k++)
                    {
                        if (k == courses[i].Categories[j].Grades.Count() - 1 && j == courses[i].Categories.Count() - 1)
                        {
                            SaveString = SaveString + courses[i].Categories[j].Grades[k].Value + Environment.NewLine;
                        }
                        else if (k == courses[i].Categories[j].Grades.Count() - 1)
                        {
                            SaveString = SaveString + courses[i].Categories[j].Grades[k].Value + "/";
                        }
                        else
                        {
                            SaveString = SaveString + courses[i].Categories[j].Grades[k].Value + "|";
                        }
                        
                        
                    }
                    
                }  
                
                if (courses[i].Categories.Count() == 0)
                {
                    SaveString = SaveString + Environment.NewLine;
                }             
            }

            FileWriter.Write(SaveString);
            FileWriter.Close();
        }
        public static ObservableCollection<Course> LoadData()
        {
            ObservableCollection<Course> courses = new ObservableCollection<Course>();
            StreamReader savedData;
            if (File.Exists("SavedData.txt")) { 
                savedData = new StreamReader("SavedData.txt");
            } 
            else 
            {
                savedData = new StreamReader(File.Create("SavedData.txt"));
            }
            
            while (savedData.Peek() > 0)
            {
                string line = savedData.ReadLine();
                string[] courseLine = line.Split(',');
                Console.WriteLine("courseLine length: " + courseLine.Length);
                if (courseLine[1] == "")
                {
                    courses.Add(new Course(courseLine[0]));
                }
                else
                {
                    var categories = new ObservableCollection<Category>();
                    var categoriesList = courseLine[1].Split('/');
                    foreach (string categoriesString in categoriesList)
                    {
                        var grades = new ObservableCollection<Grade>();

                        var categoriesStringArray = categoriesString.Split('|');
                        var categoryName = categoriesStringArray[0];
                        var weightText = categoriesStringArray[1];
                        for (int i = 2; i < categoriesStringArray.Length; i++)
                        {
                            grades.Add(new Grade(Double.Parse(categoriesStringArray[i])));

                        }
                        categories.Add(new Category(categoryName, Double.Parse(weightText), grades));
                        

                    }
                    courses.Add(new Course(courseLine[0], categories));
                }
            }

            savedData.Close();
            return courses;
        }
    }
}
