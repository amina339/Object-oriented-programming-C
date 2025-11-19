using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class Courses_Management
{
    public static bool Create_Course(string title, string type, string place, List<Course> courses)
    {
        List<Student> empty_students = new List<Student>();
        
        if (type == "онлайн-курс")
        {
            Course course = new Online_Course(title, type, empty_students, place, null);
            courses.Add(course);
            return true;
                
        }
        else if (type == "офлайн-курс")
        {
            Course course = new Offline_Course(title, type, null, empty_students, place);
            courses.Add(course);
            return true;
        }
        return false;
    }
    public static void Delete_Course(Course course, List<Course> courses, List<Teacher> teachers)
    {
        courses.Remove(course);
        foreach (Teacher teacher in teachers)
        {
            if (teacher.Courses is not null)
            {
                if (teacher.Courses.Contains(course))
                {
                    teacher.Remove_From_Course(course);
                }
            }
        }
        Console.WriteLine($"Вы удалили курс '{course.Title}' из системы ℹ️");
    }
    public static Course? Find_Course(List<Course> courses, string chosen_course_title)
    {
        foreach (Course course in courses)
        {
            if (course.Title == chosen_course_title) { return course; }
        }
        return null;
            
    }
    public static void Show_Courses(List<Course> courses)
    {
        Console.WriteLine("Впишите название курса, с которым хотите совершить данное действие: ");
        foreach (Course course in courses)
        {
            Console.WriteLine(course.Title);
        }
    }
}
    
