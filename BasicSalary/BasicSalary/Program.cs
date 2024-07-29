using System.ComponentModel.DataAnnotations;

namespace BasicSalary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ;
            Console.WriteLine("----Basic Salary----");
            double basicSalary, grossSalary, HRA, DA;
            Console.WriteLine("Enter the basic salary : ");
            basicSalary = Convert.ToDouble(Console.ReadLine());
            if (basicSalary <= 10000)
            {
                DA = (basicSalary / 100) * 80;
                HRA = (basicSalary / 100) * 20;
                grossSalary = basicSalary + DA + HRA;

            }
            else if (basicSalary <= 20000 && basicSalary > 10000)
            {
                DA = (basicSalary / 100) * 90;
                HRA = (basicSalary / 100) * 25;
                grossSalary = basicSalary + DA + HRA;

            }
            else
            {
                DA = (basicSalary / 100) * 95;
                HRA = (basicSalary / 100) * 30;
                grossSalary = basicSalary + DA + HRA;

            }
            Console.WriteLine("Gross Salary =" + grossSalary);
        }


    }
}