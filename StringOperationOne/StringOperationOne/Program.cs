namespace StringOperationOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word, output;
            Console.WriteLine("----StringOperationOne----");
            Console.WriteLine("Enter the string");
            word = Console.ReadLine();
            char ch = word[0];
            output = ch + word + ch;
            Console.WriteLine(output);
        }
    }
}