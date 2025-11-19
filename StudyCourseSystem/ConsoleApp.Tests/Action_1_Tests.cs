using System.Text;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleApp.Tests;

public class Action_1_Tests
{
    private List<Teacher> teachers;
    private List<Student> students;
    private Teacher teacher_1;
    private Teacher teacher_2;
    private Teacher teacher_3;
    private Student student_1;
    private Student student_2;
    private Student student_3;
    private Course course_1;
    public Action_1_Tests()
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

        teacher_1.Add_To_Course(course_1);
    }
    [Fact]
    public void FindPerson_ExpectNotFoundPerson() //checks if non-existent person is not found
    {
        List<Person> allPeople = teachers.Cast<Person>().Concat(students.Cast<Person>()).ToList();
        Person? found = Person.Find_Person(allPeople, "Артемьевна Анна Ильична");
        Assert.Null(found);
    }
    [Fact]
    public void FindPersin_IsFound() //checks if person is found
    {
        List<Person> allPeople = teachers.Cast<Person>().Concat(students.Cast<Person>()).ToList();
        Person? found = Person.Find_Person(allPeople, "Артемьевна Лариса Ильична");
        Assert.True(found == student_3);
    }
    [Fact]
    public void Show_Person_Info_StudentFormat() //checks format for student
    {
        var sb_3 = new StringBuilder();
        sb_3.AppendLine();
        sb_3.AppendLine($"ФИО: Артемьевна Лариса Ильична");
        sb_3.AppendLine($"Id: 164578");
        sb_3.AppendLine($"Группа: K4637");
        Assert.Equal(sb_3.ToString(), student_3.Show_Person_Info().ToString());
    }
    [Fact]
    public void Show_Person_Info_TeacherFormat() //checks format for teacher
    {
        var sb_4 = new StringBuilder();
        sb_4.AppendLine();
        sb_4.AppendLine($"ФИО: Сорокина Татьяна Анатольевна");
        sb_4.AppendLine($"Id: 567843");
        sb_4.AppendLine($"Подразделение: Институт Математики");
        sb_4.AppendLine("Ведёт курсы:");
        sb_4.AppendLine("офлайн-курс 'КТ, программирование и математика 💻'");
        Assert.Equal(sb_4.ToString(), teacher_1.Show_Person_Info().ToString());
    }
}
