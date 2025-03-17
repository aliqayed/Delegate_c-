using System;
using System.Collections.Generic;

namespace Delegate_c_
{
    #region Delegate
    delegate int MyDelegate(int x, int y);
    delegate void MyDelegate1();
    delegate double d2(double x, double y);
    public delegate void MyDel(Exam Ex); // Declare the delegate
    #endregion

    #region Event
    public delegate void mydel(Button b);

    public class Button
    {
        public string txt = "Click Me";
        // Declare the event using EventHandler
        public event mydel Click;
        public void OnClick()
        {
            if (Click != null)
            {
                Click(this);
            }
            else
            {
                Console.WriteLine("No Event Handler");
            }
        }
    }
    public class page // subscriber
    {

        public void dispaly(Button B)
        {
            Console.WriteLine("Button Clicked \t" + B.txt);
        }
    }
    #endregion

    #region Event_implement_Delegate_in_class_admin_student
    public class Exam
    {
        public int id { get; set; }
        public string Subject { get; set; }
        public Dictionary<string, List<string>> question { get; set; }
        public int Time { get; set; }
        public event MyDel Start_Exam;// Declare the event
        public Exam(int id, string Subject, Dictionary<string, List<string>> question, int Time)
        {
            this.id = id;
            this.Subject = Subject;
            this.question = question;
            this.Time = Time;
        }
        public void StartExam()// Trigger the event
        {
            if (Start_Exam != null)
            {
                Start_Exam(this);//fire the event
            }
            else
            {
                Console.WriteLine("No Event Handler");
            }
        }
        public override string ToString()
        {
            string txt = $"id: {id} \t \t Subject: {Subject}  \t\t Time: {Time}";
            foreach (var item in question)
            {
                txt += $" Question Key {item.Key}Question: {item.Value} \t\n";

            }
            return txt;
        }
    }
    public class Student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(int id, string Name, int Age)
        {
            this.id = id;
            this.Name = Name;
            this.Age = Age;

        }

        public override string ToString()
        {
            return $"id: {id} \t Name: {Name} \t Email: {Age} \t\n";
        }
        public void Start_Exam(Exam Ex)
        {
            Console.WriteLine("Student Start Exam \t" + Ex.ToString());
            Console.WriteLine($"{Name}  start Answer Exam ");
        }
    }
    public class Admin
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Admin(int id, string Name, int Age)
        {
            this.id = id;
            this.Name = Name;
            this.Age = Age;

        }
        public override string ToString()
        {
            return $"id: {id} \t Name: {Name} \t Email: {Age} \t\n";
        }
        public void Montior(Exam Ex)
        {
            Console.WriteLine("Student Start Exam \t" + Ex.ToString());
            Console.WriteLine($"{Name}  start Montior {Ex.Subject} Exam , Time = {Ex.Time} m");
        }
    }
    class eventargs : EventArgs
    {
        public string txt { get; set; }
        public eventargs(string txt) : base()
        {
            this.txt = txt;
        }
    }
    #endregion
    internal class Program
    {
        #region delegate
        public static int Add(int x, int y) => x + y;

        public void Print(MyDelegate1 myDelegate)  /// can pass function As prameter
        {
            Console.WriteLine(myDelegate);
        }
        //public static double FDouble(int x = 5, int y = 8, d2 D) => D(x);
        public static double FDouble() => 3.14;
        public static double FDouble(int x, int y) => x + y;
        public static double FDouble(double x, double y, d2 D) => D(x, y);
        #endregion
        static void Main(string[] args)
        {
            #region Delegate
            MyDelegate myDelegate = new MyDelegate(Add);
            Console.WriteLine(myDelegate(10, 20));

            myDelegate = (x, y) => x * y;
            Console.WriteLine(myDelegate(10, 20));

            myDelegate = (x, y) => x - y;
            Console.WriteLine(myDelegate(10, 20));

            myDelegate = (x, y) => x / y;
            Console.WriteLine(myDelegate(10, 20));

            myDelegate = (x, y) => x % y;
            Console.WriteLine(myDelegate(10, 20));

            myDelegate = (x, y) => x & y;
            Console.WriteLine(myDelegate(10, 20));

            myDelegate = (x, y) => x | y;
            Console.WriteLine(myDelegate(6, 9));

            Console.Clear();
            MyDelegate1 myDelegate1 = new MyDelegate1(() => Console.WriteLine("Welcom To Ali "));
            myDelegate1();

            Console.Clear();
            Program program = new Program();
            program.Print(myDelegate1);
            //double d2(t) => 3.14;
            //d2 d2 = new d2(d2);
            Console.Clear();
            //Console.WriteLine(FDouble(5, 8, d2()));

            Console.WriteLine(FDouble(5, 8));
            Console.Clear();
            Console.WriteLine(FDouble(5, 8, (x, y) => x / y)); // anonymous function 
            Console.Clear();
            Console.WriteLine(FDouble(5, 8, (x, y) => x * y)); // anonymous function
            Console.Clear();
            Console.WriteLine(FDouble(5, 8, (x, y) => x - y)); // anonymous function
            Console.Clear();
            Console.WriteLine(FDouble(5, 8, (x, y) => x + y)); // anonymous function
            Console.Clear();
            Func<int, int, string, string> func = (x, r, name) => $"{(x + r)} --- {name}";
            string result = func(5, 6, "name");
            Console.WriteLine(result);

            Console.Clear();
            Func<int, int, int> fun = (x, r) => (x + r);
            Console.WriteLine(fun(5, 6));
            Console.Clear();
            Func<int, int, int> fun1 = (x, r) => (x - r);
            Console.WriteLine(fun1(5, 6));
            Console.Clear();
            Func<int, int, double> fun2 = (x, r) => (x / r);
            Console.WriteLine(fun2(5, 6));
            Console.Clear();
            Func<int, int, double> fun3 = (x, r) => (x * r);
            Console.WriteLine(fun3(5, 6));
            Console.Clear();
            Func<int, int, double> fun4 = (x, r) => (x % r);
            Console.WriteLine(fun4(5, 6));
            Console.Clear();
            Action<int, int> action = (x, r) => Console.WriteLine(x + r);
            action(5, 6);
            Console.Clear();
            Action<int, int> action1 = (x, r) => Console.WriteLine(x - r);
            action1(5, 6);
            Console.Clear();
            Action<String> action2 = (name) => Console.WriteLine(name);
            action2("Ali");
            Console.Clear();
            Action<String, String, int> action3 = (name, name1, age) => Console.WriteLine(name + name1 + age);
            action3("Ali", "Ali", 25);
            Console.Clear();
            Predicate<int> predicate = (x) => x > 5;
            Console.WriteLine(predicate(6));
            Console.Clear();
            //Predicate<int, double, bool> predicate1 = (x, y) => (x < 5 && y > 0.0);
            Func<int, double, bool> predicate1 = (x, y) => (x < 5 && y > 0.0);
            Console.WriteLine(predicate1(4, 0.0));
            Console.Clear();
            #endregion

            #region Event
            //Button button = new Button();
            //button.txt = "Click Me Save Change";
            //page p = new page();

            //button.Click += p.dispaly(button);
            //button.OnClick();//add event handler
            Button button = new Button();
            button.txt = "Click Me Save Changes";
            page p = new page();

            // Attach the event handler
            button.Click += p.dispaly;

            // Trigger the event (clicking the button)
            button.OnClick();  // This will invoke the dispaly method
            Console.Clear();
            #endregion

            #region Event_implement_Delegate_in_class_admin_student
            Dictionary<string, List<string>> question = new Dictionary<string, List<string>>();
            question.Add("Q1", new List<string> { "Q1", "Q2", "Q3" });
            question.Add("Q2", new List<string> { "Q1", "Q2", "Q3" });
            question.Add("Q3", new List<string> { "Q1", "Q2", "Q3" });
            question.Add("Q4", new List<string> { "Q1", "Q2", "Q3" });
            Exam exam = new Exam(1, "C#", question, 60);
            Student student = new Student(1, "Ali", 25);
            Admin admin = new Admin(1, "Admin", 25);
            exam.Start_Exam += student.Start_Exam;
            exam.Start_Exam += admin.Montior;
            exam.StartExam();

            #endregion

        }
    }
}
