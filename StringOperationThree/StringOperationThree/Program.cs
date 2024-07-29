namespace StringOperationThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----StringOperationThree----");
            string word, output;

            Console.WriteLine("Enter the string");
            word = Console.ReadLine();
            if (word.Length <= 3)
            {
                output = word + word + word;

            }
            else
            {
                string substr = word.Substring(0, 3);
                output = substr + word + substr;

            }

            Console.WriteLine(output);
        }
    }
}