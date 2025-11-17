using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class Courses_Management
{
    public static Course? Create_Course()
    {
        List<Student> empty_students = new List<Student>();
        Console.WriteLine("Впишите название курса, который хотите создать: ");
        string title = Console.ReadLine();
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Впишите тип курса, который хотите создать (онлайн-курс/офлайн-курс): ");
            string type = Console.ReadLine();
            if (type == "онлайн-курс")
            {
                Console.WriteLine("Впишите платформу, на которой будет реализован курс: ");
                string platform = Console.ReadLine();
                Course course = new Online_Course(title, type, empty_students, platform, null);
                return course;
                
            }
            else if (type == "офлайн-курс")
            {
                Console.WriteLine("Впишите место, в котором будет преподаваться курс: ");
                string place = Console.ReadLine();
                Course course = new Offline_Course(title, type, null, empty_students, place);
                return course;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуете заново? (д/любой другой знак): ");
                string answer = Console.ReadLine();
                if (answer != "д") { flag = false; }
            }
        }
        Console.WriteLine("Вы отменили создание курса ❌");
        return null;
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
    public static Course? Find_Course(List<Course> courses)
    {
        while (true)
        {
            Console.WriteLine("Впишите название курса, с которым хотите совершить данное действие: "); 
            foreach (Course course in courses)
            {
                Console.WriteLine(course.Title);
            }
            string chosen_course_title = Console.ReadLine()?.Trim();
            foreach (Course course in courses)
            {
                if (course.Title == chosen_course_title) { return course; }
            }
            Console.WriteLine("Курс не найден. Попробуете снова? (д/любой другой знак)");
            string answer = Console.ReadLine();
            if (answer != "д") { return null; }
        }
    }
}
    
