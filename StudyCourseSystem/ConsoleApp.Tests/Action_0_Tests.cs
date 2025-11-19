using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleApp.Tests;

public class Action_0_Tests
{
    private List<Teacher> teachers;
    private List<Student> students;
    private List<Course> courses;
    private Teacher teacher_1;
    private Teacher teacher_2;
    private Teacher teacher_3;
    private Student student_1;
    private Student student_2;
    private Student student_3;
    private Course course_1;
    private Course course_2;
    private Course course_3;
    public Action_0_Tests()
    {
        teacher_1 = new Teacher(567843, "Сорокина Татьяна Анатольевна", "Институт Математики");
        teacher_2 = new Teacher(897432, "Арашов Михаил Михаилович", "Институт Физики");
        teacher_3 = new Teacher(598254, "Презентова Мария Алексеевна", "Институт Биологии");
        teachers = new List<Teacher>() { teacher_1, teacher_2, teacher_3 };

        student_1 = new Student(598243, "Береснев Антон Артемович", "M5423");
        student_2 = new Student(692654, "Ульянова Ульяна Михайловна", "R8675");
        student_3 = new Student(164578, "Артемьевна Лариса Ильична", "K4637");
        students = new List<Student>() { student_1, student_2, student_3 };

        course_1 = new Offline_Course("КТ, программирование и математика 💻", "офлайн-курс", teacher_1, students, "Кронверский 49, ауд. 4506");
        course_2 = new Online_Course("Физика и фотоника 🧑‍🔬", "онлайн-курс", students, "Zoom", teacher_2);
        course_3 = new Offline_Course("Биология и экология 🥬", "офлайн-курс", teacher_3, students, "Ломоносова 9, ауд. 3229");
        courses = new List<Course>() { course_1, course_2, course_3 };

        teacher_1.Add_To_Course(course_1);
        teacher_2.Add_To_Course(course_2);
        teacher_3.Add_To_Course(course_3);
    }

    [Fact]
    public void NotFoundCourse()
    {

        Course? not_found = Courses_Management.Find_Course(courses, "Math");
        Assert.Null(not_found);
    }
    [Fact]
    public void FoundCourse()
    {
        Course? not_found = Courses_Management.Find_Course(courses, "Биология и экология 🥬");
        Assert.True(not_found == course_3);
    }
    [Fact]
    public void EmptyCourseInfo()
    {
        List<Student> empty_student = new List<Student>();
        Course new_course_1 = new Offline_Course("", "офлайн", null, empty_student, "");
        var sb_1 = new StringBuilder();
        sb_1.AppendLine();
        sb_1.Append("офлайн: название еще не определено ⏳ 0");
        sb_1.AppendLine();
        sb_1.Append("Преподаватель еще не определен ℹ️");
        sb_1.AppendLine();
        sb_1.Append($"Место проведения 📍: место проведения еще не определено ⏳");
        sb_1.AppendLine();
        sb_1.Append($"Состав обучающихся 👨‍🎓:");
        sb_1.AppendLine();
        sb_1.AppendLine("ℹ️ Студенты пока еще не записаны на этот курс");
        Assert.Equal(sb_1.ToString(), new_course_1.ShowCourseInfo().ToString());
    }
    [Fact]
    public void FullCourseInfo()
    {
        List<Student> empty_student = new List<Student>();
        Course new_course_2 = new Offline_Course("Math", "офлайн", teacher_1, empty_student, "Ломоносова 9");
        var sb_2 = new StringBuilder();
        sb_2.AppendLine();
        sb_2.Append("офлайн: Math");
        sb_2.AppendLine();
        sb_2.Append($"Преподаватель 👩‍🏫: Сорокина Татьяна Анатольевна, Id 567843, Институт Математики");
        sb_2.AppendLine();
        sb_2.Append($"Место проведения 📍: Ломоносова 9");
        sb_2.AppendLine();
        sb_2.Append($"Состав обучающихся 👨‍🎓:");
        sb_2.AppendLine();
        sb_2.AppendLine("ℹ️ Студенты пока еще не записаны на этот курс");
        Assert.Equal(sb_2.ToString(), new_course_2.ShowCourseInfo().ToString());
    }
}


