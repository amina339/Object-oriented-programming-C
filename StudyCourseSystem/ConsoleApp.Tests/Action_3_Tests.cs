using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleApp.Tests;

public class Action_3_Tests
{
    private List<Teacher> teachers;
    private List<Course> courses;
    private List<Student> students;
    private Teacher teacher_1;
    private Teacher teacher_2;
    private Course course_1;
    private Course course_2;
    private Course course_3;
    public Action_3_Tests()
    {
        teacher_1 = new Teacher(567843, "Сорокина Татьяна Анатольевна", "Институт Математики");
        teacher_2 = new Teacher(897432, "Арашов Михаил Михаилович", "Институт Физики");
        teachers = new List<Teacher>() { teacher_1, teacher_2 };
        students = new List<Student>();

        course_1 = new Offline_Course("КТ, программирование и математика 💻", "офлайн-курс", teacher_1, students, "Кронверский 49, ауд. 4506");
        course_2 = new Online_Course("Физика и фотоника 🧑‍🔬", "онлайн-курс", students, "Zoom", teacher_2);
        courses = new List<Course>() { course_1, course_2 };

        teacher_1.Add_To_Course(course_1);
        teacher_2.Add_To_Course(course_2);
    }
    [Fact]
    public void Delete_Course_ExpectCourseNotInCourse() //checks that courses list doesnt contain removed course
    {
        Courses_Management.Delete_Course(course_1, courses, teachers);
        Assert.DoesNotContain(course_1, courses);
    }
    [Fact]
    public void Delete_Course_ExpectCourseNotInTeacherList() //checks that teachers courses list does not contain removed course
    {
        Courses_Management.Delete_Course(course_1, courses, teachers);
        Assert.DoesNotContain(course_1, teacher_1.Courses);
    }
}