namespace StringOperationTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word, output;
            int len;
            Console.WriteLine("----StringOperationTwo----");
            Console.WriteLine("Enter the string");
            word = Console.ReadLine();
            len = word.Length;
            if (word.Length > 1)
            {
                output = word.Substring(len - 1) + word.Substring(1, len - 2) + word.Substring(0, 1);
            }
            else
                output = word;
            Console.WriteLine(output);
        }
    }
}