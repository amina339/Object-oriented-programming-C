using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Person
{
    private int _age;
    private int _id;
    public int Id {
        get { return _id; }
        set
        {
            if (value < 100000 || value > 1000000)
                Console.WriteLine("Id должен быть шестизначным числом");
            else
                _id = value;
        }
    }
    public string FullName { get; set; }
    public abstract void Show_Person_Info();

    public Person(int id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }
    public static Person? Find_Person<T>(List<T> allPeople) where T : Person
    {
        while (true)
        {
            Console.WriteLine("Впишите ФИО персоны, которую хотите найти из списка");
            foreach (Person person in allPeople)
            {
                Console.WriteLine(person.FullName);
            }
            string chosen_person_name = Console.ReadLine();
            foreach (Person person in allPeople)
            {
                if (person.FullName == chosen_person_name)
                { return person; }
            }
            Console.WriteLine("Человек не найден. Попробуете снова? (д/любой другой знак)");
            string answer = Console.ReadLine();
            if (answer != "д") { return null; }
        }
    }
}

public class Student : Person
{
    public string Group { get; set; }
    public Student(int id, string fullName, string group)
        : base(id, fullName)
    {
        Group = group;
    }
    public override void Show_Person_Info()
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.AppendLine($"ФИО: {FullName}");
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Группа: {Group}");
        Console.WriteLine(sb.ToString());
    }
}

public class Teacher : Person
{
    public string Institute { get; set; }
    public List<Course> Courses = new List<Course>();
    public override void Show_Person_Info()
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.AppendLine($"ФИО: {FullName}");
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Подразделение: {Institute}");
        if (Courses.Count == 0) { sb.AppendLine("Преподаватель пока не был назначен на курс ⏳"); }
        else
            {
                sb.AppendLine("Ведёт курсы:");
                for (int i = 0; i < Courses.Count; i++)
                {
                    sb.AppendLine($"{Courses[i].Type} '{Courses[i].Title}'");
                }
            }
        Console.WriteLine(sb.ToString());
    }
    public void Add_To_Course(Course course)
    {
        Courses.Add( course );
    }
    public void Remove_From_Course(Course course)
    {
        Courses.Remove(course);
    }
    public Teacher(int id, string fullName, string institute)
        : base(id, fullName)
    {
        Institute = institute;
    }
}