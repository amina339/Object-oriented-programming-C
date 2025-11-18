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
                bool flag = true;
                while (flag)
                {
                    Courses_Management.Show_Courses(courses);
                    string chosen_course_title = Console.ReadLine()?.Trim();
                    Course? found_course = Courses_Management.Find_Course(courses, chosen_course_title);
                    if (found_course != null) { found_course.ShowCourseInfo(); flag = false; }
                    else
                    {
                        Console.WriteLine("Курс не найден. Попробуете снова? (д/любой другой знак)");
                        string answer_ = Console.ReadLine();
                        if (answer_ != "д") { flag = false; }
                    }
                }
            }
            else if (answer == "1")
            {
                List<Person> allPeople = teachers.Cast<Person>().Concat(students.Cast<Person>()).ToList(); //?
                bool cont = true;
                while (cont)
                {
                    Person.Show_People(allPeople);
                    string chosen_person_name = Console.ReadLine()?.Trim();
                    Person? found_person = Person.Find_Person(allPeople, chosen_person_name);
                    if (found_person != null) { found_person.Show_Person_Info(); cont = false; }
                    else
                    {
                        Console.WriteLine("Человек не найден. Попробуете снова? (д/любой другой знак)");
                        string answer_ = Console.ReadLine();
                        if (answer_ != "д") { cont = false; }
                    }
                }
            }
            else if (answer == "2")
            {
                Console.WriteLine("Впишите название курса, который хотите создать: ");
                string title = Console.ReadLine();
                Course new_course = null;
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Впишите тип курса, который хотите создать (онлайн-курс/офлайн-курс): ");
                    string type = Console.ReadLine();
                    if (type == "онлайн-курс")
                    {
                        Console.WriteLine("Впишите платформу, на которой будет реализован курс: ");
                        string platform = Console.ReadLine();
                        new_course = Courses_Management.Create_Course(title, type, platform);
                        flag = false;
                    }
                    else if (type == "офлайн-курс")
                    {
                        Console.WriteLine("Впишите место, в котором будет преподаваться курс: ");
                        string place = Console.ReadLine();
                        new_course = Courses_Management.Create_Course(title, type, place);
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Попробуете заново? (д/любой другой знак): ");
                        string answer_ = Console.ReadLine();
                        if (answer_ != "д") { flag = false; }
                    }
                }
                if (new_course != null) { courses.Add(new_course); Console.WriteLine($"✅ Вы создали {new_course.Type}: '{new_course.Title}'"); }
                else { Console.WriteLine("Вы отменили создание курса ❌"); }
            }
            else if (answer == "3")
            {
                bool flag = true;
                while (flag)
                {
                    Courses_Management.Show_Courses(courses);
                    string chosen_course_title = Console.ReadLine()?.Trim();
                    Course? found_course = Courses_Management.Find_Course(courses, chosen_course_title);
                    if (found_course != null)
                    {
                        Courses_Management.Delete_Course(found_course, courses, teachers);
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Курс не найден. Попробуете снова? (д/любой другой знак)");
                        string answer_ = Console.ReadLine();
                        if (answer_ != "д") { flag = false; }
                    }
                }
            }
            else if (answer == "4")
            {
                bool flag = true;
                while (flag)
                {
                    Courses_Management.Show_Courses(courses);
                    string chosen_course_title = Console.ReadLine()?.Trim();
                    Course? found_course = Courses_Management.Find_Course(courses, chosen_course_title);
                    if (found_course == null)
                    {
                        Console.WriteLine("Курс не найден. Попробуете снова? (д/любой другой знак)");
                        string answer_ = Console.ReadLine();
                        if (answer_ != "д") { flag = false; }
                    }
                    else
                    {
                        bool cont = true;
                        while (cont)
                        {
                            Person.Show_People(teachers);
                            string chosen_person_name = Console.ReadLine()?.Trim();
                            Person? found_person = Person.Find_Person(teachers, chosen_person_name);
                            if (found_person != null) { found_course.Add_Change_Teacher((Teacher)found_person); cont = false; flag = false; }
                            else
                            {
                                Console.WriteLine("Человек не найден. Попробуете снова? (д/любой другой знак)");
                                string answer_ = Console.ReadLine();
                                if (answer_ != "д") { cont = false; flag = false; }
                            }
                        }
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