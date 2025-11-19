using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

public abstract class Course
{
    private static int num = 0;
    public Teacher? Teacher { get; set; }
    private string _title;
    public string Title
    {
        get { return _title; }
        set
        {
            if (string.IsNullOrEmpty(value)) { _title = $"название еще не определено ⏳ {num++}"; }
            else { _title = value; }
        }
    }
    public string Type { get; set; }
    public List<Student> Students { get; set; }
    public abstract StringBuilder ShowCourseInfo();
    public virtual void Add_Change_Teacher(Teacher teacher)
    {
        if (Teacher == null) { Teacher.Add_To_Course(this); Console.WriteLine($"Вы назначили преподавателя {Teacher.FullName} на курс '{Title}' ✅"); }
        else if (teacher.FullName != Teacher.FullName)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine($"На этом курсе уже есть преподаватель {Teacher.FullName}. Хотите поменять? (д/любой другой знак)");
                string answer = Console.ReadLine();
                if (answer == "д")
                {
                    string last_teacher_name = Teacher.FullName;
                    Teacher.Remove_From_Course(this);
                    Console.WriteLine($"✅ Вы удалили преподавателя {last_teacher_name} с курса '{Title}' и определили преподавателя {teacher.FullName} на это место");
                    teacher.Add_To_Course(this);
                    flag = false;
                }
                else { Console.WriteLine($"ℹ️ Действие отменено. Преподаватель {Teacher.FullName} остался на курсе '{Title}'"); flag = false; }
            }
        }
        else
        {
            Console.WriteLine($"Преподаватель {teacher.FullName} уже стоит на этом курсе");
        }
    }
    public Course(string title, string type, List<Student> students, Teacher? teacher)
    {
        Title = title; Type = type; Students = students; Teacher = teacher; 
    }
}

public class Online_Course : Course
{
    private string _platform;
    public string Platform
    {
        get { return _platform; }
        set
        {
            if (string.IsNullOrEmpty(value) || value=="") { _platform = "платформа еще не определена ⏳"; }
            else { _platform = value; }
        }
    }
    public override StringBuilder ShowCourseInfo()
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.Append($"{Type}: {Title}");
        sb.AppendLine();
        if (Teacher != null)
        {
            sb.Append($"Преподаватель 👩‍🏫: {Teacher.FullName}, Id {Teacher.Id}, {Teacher.Institute}");
        } 
        else
        {
            sb.Append("Преподаватель еще не определен ℹ️");
        }
        sb.AppendLine();
        sb.Append($"Платформа 💻: {Platform}");
        sb.AppendLine();
        sb.Append($"Состав обучающихся 👨‍🎓:");
        sb.AppendLine();
        if (Students.Count > 0)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                sb.AppendLine($"{Students[i].FullName}, Id {Students[i].Id}, группа {Students[i].Group}");
            }
        }
        else { sb.AppendLine("ℹ️ Студенты пока еще не записаны на этот курс"); }
        return sb;
    }
    public Online_Course(string title, string type, List<Student> students, string platform, Teacher teacher)
        : base(title, type, students, teacher)
    {
        Platform = platform;
    }
}

public class Offline_Course : Course
{
    private string _place;
    public string Place
    {
        get { return _place; }
        set
        {
            if (string.IsNullOrEmpty(value) || value == "")
            {
                _place = "место проведения еще не определено ⏳";
            }
            else
            {
                _place = value;
            }
        }
    }
    public override StringBuilder ShowCourseInfo()
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.Append($"{Type}: {Title}");
        sb.AppendLine();
        if (Teacher != null)
        {
            sb.Append($"Преподаватель 👩‍🏫: {Teacher.FullName}, Id {Teacher.Id}, {Teacher.Institute}");
        }
        else
        {
            sb.Append("Преподаватель еще не определен ℹ️");
        }
        sb.AppendLine();
        sb.Append($"Место проведения 📍: {Place}");
        sb.AppendLine();
        sb.Append($"Состав обучающихся 👨‍🎓:");
        sb.AppendLine();
        if (Students.Count > 0)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                sb.AppendLine($"{Students[i].FullName}, Id {Students[i].Id}, группа {Students[i].Group}");
            }
        }
        else { sb.AppendLine("ℹ️ Студенты пока еще не записаны на этот курс"); }
        return sb;
    }
    public Offline_Course(string title, string type, Teacher teacher, List<Student> students, string place)
        : base(title, type, students, teacher)
    {
        Place = place;
    }
}
