namespace ProblemOnMultiLevel
{        
        internal class StudentProfessorTest
        {
            static void Main(string[] args)
            {
                Person p = new Person();
                p.Greet();

                Student s = new Student();
                s.SetAge(16);
                s.Greet();
                Console.WriteLine("Age : " + s.age);

                Teacher t = new Teacher();
                t.SetAge(40);
                t.Greet();
                t.Explain();
            }
        }
}