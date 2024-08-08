namespace ProblemOnClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] person = new Person[3];
            string name;
            for(int i=0;i<3;i++)
            {
               Console.WriteLine("Enter the Name");
                name = Console.ReadLine();
                person[i] = new Person(name);
            }
            for(int i=0;i<3; i++)
            {
                Console.WriteLine(person[i].ToString());
            }

        }
    }
}