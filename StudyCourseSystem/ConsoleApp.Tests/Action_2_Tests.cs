using System.Text;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleApp.Tests;

public class Action_2_Tests
{
    private List<Course> courses;
    private Course course_1;
    private Course course_2;
    private Course course_3;
    public Action_2_Tests()
    {
        List<Student> students = new List<Student>();
        course_1 = new Offline_Course("КТ, программирование и математика 💻", "офлайн-курс", null, students, "Кронверский 49, ауд. 4506");
        course_2 = new Online_Course("Физика и фотоника 🧑‍🔬", "онлайн-курс", students, "Zoom", null);
        course_3 = new Offline_Course("Биология и экология 🥬", "офлайн-курс", null, students, "Ломоносова 9, ауд. 3229");
        courses = new List<Course>() { course_1, course_2, course_3 };
    }
    [Fact]
    public void CreateCourse_ExpectCoursesContainCourse() //checks if created course in course list
    {
        int original_length = courses.Count;
        if (Courses_Management.Create_Course("Math", "офлайн-курс", "Ломоносова", courses))
        {
            Assert.Equal(original_length + 1, courses.Count);
        }
    }
}
