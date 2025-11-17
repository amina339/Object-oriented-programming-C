using System.Linq;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Teacher teacher_1 = new Teacher(567843, "Сорокина Татьяна Анатольевна", "Институт Математики");
        Teacher teacher_2 = new Teacher(897432, "Арашов Михаил Михаилович", "Институт Физики");
        Teacher teacher_3 = new Teacher(598254, "Презентова Мария Алексеевна", "Институт Биологии");
        List<Teacher> teachers = new List<Teacher>() { teacher_1, teacher_2 , teacher_3 };

        Student student_1 = new Student(598243, "Береснев Антон Артемович", "M5423");
        Student student_2 = new Student(692654, "Ульянова Ульяна Михайловна", "R8675");
        Student student_3 = new Student(164578, "Артемьевна Лариса Ильична", "K4637");
        List<Student> students = new List<Student>() { student_1, student_2, student_3 };

        Course course_1 = new Offline_Course("КТ, программирование и математика 💻", "офлайн-курс", teacher_1, students, "Кронверский 49, ауд. 4506");
        Course course_2 = new Online_Course("Физика и фотоника 🧑‍🔬", "онлайн-курс", students, "Zoom", teacher_2);
        Course course_3 = new Offline_Course("Биология и экология 🥬", "офлайн-курс", teacher_3, students, "Ломоносова 9, ауд. 3229");
        List<Course> courses = new List<Course>() { course_1, course_2, course_3 };

        teacher_1.Add_To_Course(course_1);
        teacher_2.Add_To_Course(course_2);
        teacher_3.Add_To_Course(course_3);

        bool should_continue = true;
        while (should_continue)
        {
            Console.WriteLine("Выберите действие: посмотреть курс (0), найти персону (1), создать курс (2), удалить курс (3), назначить преподавaтеля на курс (4)");
            string answer = Console.ReadLine();
            if (answer == "0")
            {
                Course? found_course = Courses_Management.Find_Course(courses);
                if (found_course != null) { found_course.ShowCourseInfo(); }    
            }
            else if (answer == "1")
            {
                List<Person> allPeople = teachers.Cast<Person>().Concat(students.Cast<Person>()).ToList(); //?
                Person? person = Person.Find_Person(allPeople);
                if (person != null) {person.Show_Person_Info(); }
            }
            else if (answer == "2")
            {
                Course? new_course = Courses_Management.Create_Course();
                if (new_course != null) { courses.Add(new_course); Console.WriteLine($"✅ Вы создали {new_course.Type}: '{new_course.Title}'"); }
            }
            else if (answer == "3")
            {
                Course? found_course = Courses_Management.Find_Course(courses);
                if (found_course != null)
                {
                    Courses_Management.Delete_Course(found_course, courses, teachers);
                }
               
            }
            else if (answer == "4")
            {
                Course? course_found = Courses_Management.Find_Course(courses);
                if (course_found != null)
                {
                    Person? person = Person.Find_Person(teachers);
                    if (person != null)
                    {
                        course_found.Add_Change_Teacher((Teacher)person);
                    }
                }
            }
            else
            {
                Console.WriteLine("Введенный режим не существует. Хотите продолжить? (д/любой другой знак)");
                answer = Console.ReadLine();
                if (answer != "д") { should_continue = false; }
            }

            if (new List<string> { "0", "2", "3", "4" }.Contains(answer))
            {
                Console.WriteLine($"Режим ({answer}) окончен. Хотите продолжить? (д/любой другой знак)");
                answer = Console.ReadLine();
                if (answer != "д") { should_continue = false; }
            }
        }

        Console.WriteLine("Вы завершили работу 🤚");
    }
}