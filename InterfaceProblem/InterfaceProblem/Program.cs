namespace InterfaceProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gasolineRefuelAmount;
            Car car = new Car(0);
            Console.Write("Enter the amount of gasoline to refuel : ");
            gasolineRefuelAmount = Convert.ToInt32(Console.ReadLine());

            car.Refuel(gasolineRefuelAmount);
            car.Drive();
        }
    }
}