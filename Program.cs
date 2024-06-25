using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TypeOfCustomer();
            //Input Customer Name
            string choice = Getchoice();
            Console.WriteLine("Enter customer Name: ");
            string customerNames = Console.ReadLine();

           

            //Input the previous month water number and check if input is valid
            Console.WriteLine("Enter the previous month water number: ");
            int previousWaterConsumption;
            while (!int.TryParse(Console.ReadLine(), out previousWaterConsumption))
            {
                Console.WriteLine("Error: Invalid previous month water number! Please enter again.");
                Console.WriteLine("Re-enter the previous month water number: ");
            }

            // Input this month water number and check if input is valid
            Console.WriteLine("Enter this month water number: ");
            int currentWaterConsumption;
            while (!int.TryParse(Console.ReadLine(), out currentWaterConsumption))
            {
                Console.WriteLine("Error: Invalid this month water number! Please enter again.");
                Console.WriteLine("Re-enter the this month water number: ");
            }

            while (currentWaterConsumption < previousWaterConsumption)
            {          
                Console.WriteLine("Re-enter the this month water number: ");
                currentWaterConsumption = int.Parse(Console.ReadLine());
                
            }

            //Calculate water consumption
            int waterUsage = currentWaterConsumption - previousWaterConsumption;
            double PRICE = waterBill(currentWaterConsumption - previousWaterConsumption, choice);
            double Bill = GetBill(PRICE);
            double TotalBill = GetTotal(Bill);

            // Output Print waterUsage, Price, Bill, TotalBill
            Console.WriteLine("--------------------------Water Bill--------------------------");
            Console.WriteLine("     Customer Name: " + customerNames);
            Console.WriteLine("     Last month’s water meter readings: " + previousWaterConsumption);
            Console.WriteLine("     This month’s water meter readings: " + currentWaterConsumption);
            Console.WriteLine("     Amount of water consumed: " + waterUsage + "m3");
            Console.WriteLine("     Water fee is: " + PRICE + "VND");
            Console.WriteLine("     Water fee include environment fee is: " + Bill + "VND");
            Console.WriteLine("     Total water bill payable is: " + TotalBill + "VND");
            Console.ReadLine();
            Console.Clear();
            
        }
        static void TypeOfCustomer()
        {
            Console.WriteLine("1 - Household, 2 - Administrative agency, 3 - Production unit, 4 - Business service):");
            Console.WriteLine("1 - Household");
            Console.WriteLine("2 - Administrative agency");
            Console.WriteLine("3 - Production unit");
            Console.WriteLine("4 - Business service");
        }


        static string Getchoice()
        {
            // Input information for customer choice
            Console.WriteLine("Enter your choose:");
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine("Error: Invalid customer type! Please enter again.");
                Console.WriteLine("Re-enter your choose: ");
                choice = Console.ReadLine();
            }
            return choice;

        }
        static double waterBill(int waterUsage, string choice)
        {
            // Assigns the value of the right operand to the left operand.
            const double PRICE_LEVEL_1 = 5.973;
            const double PRICE_LEVEL_2 = 7.052;
            const double PRICE_LEVEL_3 = 8.699;
            const double PRICE_LEVEL_4 = 15.929;
            const double PRICE_FOR_AGENCIES = 9.955;
            const double PRICE_FOR_PRODUCTION = 11.615;
            const double PRICE_FOR_BUSINESS = 22.068;
            double PRICE = 0;

            switch (choice)
            {
                case "1": // Household
                    if (waterUsage <= 10)
                    {
                        PRICE = (waterUsage * PRICE_LEVEL_1);
                    }
                    else if (waterUsage > 10 && waterUsage <= 20)
                    {
                        PRICE = (10 * PRICE_LEVEL_1) + ((waterUsage - 10) * PRICE_LEVEL_2);
                    }
                    else if (waterUsage > 20 && waterUsage <= 30)
                    {
                        PRICE = (10 * PRICE_LEVEL_1) + (10 * PRICE_LEVEL_2) + ((waterUsage - 20) * PRICE_LEVEL_3);
                    }
                    else
                    {
                        PRICE = (10 * PRICE_LEVEL_1) + (10 * PRICE_LEVEL_2) + (10 * PRICE_LEVEL_3) + ((waterUsage - 30) * PRICE_LEVEL_4);
                    }
                    break;
                case "2": // Administrative agency
                    PRICE = waterUsage * PRICE_FOR_AGENCIES;
                    break;
                case "3":  // Production units
                    PRICE = waterUsage * PRICE_FOR_PRODUCTION;
                    break;
                case "4": // Business services
                    PRICE = waterUsage * PRICE_FOR_BUSINESS;
                    break;
            }
            return PRICE;

        }

        static double GetBill(double PRICE)
        {
            // Calculate Bill with 10% ENV
            double ENV = 0.1;
            double Bill =0 ;
            Bill = (PRICE * ENV) + PRICE;
            return Bill;
        }
        static double GetTotal(double Bill)
        {
            // Calculate TotaBill with 10 % VAT
            double VAT = 0.1;
            double TotalBill = 0;
            TotalBill = (Bill * VAT) + Bill;
            return TotalBill;
        }
        
    }
}
