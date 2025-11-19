using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleApp.Tests;

public class Action_4_Tests
{
    private List<Student> students;
    private Teacher teacher_1;
    private Course course_2;
    public Action_4_Tests()
    {
        teacher_1 = new Teacher(567843, "Сорокина Татьяна Анатольевна", "Институт Математики");
        students = new List<Student>();
        course_2 = new Online_Course("Физика и фотоника 🧑‍🔬", "онлайн-курс", students, "Zoom", null);
    }
    [Fact]
    public void Add_To_Course_AddTeacherToCourse_ExpectsTeacherCourseList()
    {
        teacher_1.Add_To_Course(course_2);
        Assert.Contains(course_2, teacher_1.Courses);
    }
    [Fact]
    public void Add_To_Course_AddTeacherToCourse_ExpectsCourseTeacher()
    {
        teacher_1.Add_To_Course(course_2);
        Assert.True(course_2.Teacher == teacher_1);
    }
}

