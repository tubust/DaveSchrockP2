using System;
using System.Collections.Generic;
using System.Text;

namespace DaveSchrockP2
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            userData[] u1 = new userData[5];
            char choice = 'Y';
            int calOut, desiOut = 0;
            bool getGoing = false;
            Console.WriteLine("Welcome to the calorie calculator program");
            Console.WriteLine();
            while(choice=='Y' && counter != 5)
            {
                Console.Write("Please enter your name: ");
                u1[counter].name = Console.ReadLine();
                Console.Write("Please enter your age: ");
                while (getGoing == false)
                {
                    try
                    {
                        u1[counter].age = Int32.Parse(Console.ReadLine());
                        getGoing = true;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Error! Please enter an integer number:");
                    }
                }
                getGoing = false;
                Console.Write("Please enter your height in inches  1 Foot = 12 inches: ");
                while (getGoing == false)
                {
                    try
                    {
                        u1[counter].height = Int32.Parse(Console.ReadLine());
                        getGoing = true;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Error! Please enter an integer number:");
                    }
                }
                getGoing = false;
                Console.Write("Please enter your gender M or F: ");
                u1[counter].personSex = char.ToUpper(char.Parse(Console.ReadLine()));
                while (!(u1[counter].personSex == 'M' || u1[counter].personSex == 'F'))
                {
                    Console.Write("Please enter M or F: ");
                    u1[counter].personSex = char.ToUpper(char.Parse(Console.ReadLine()));
                }
                Console.WriteLine(" S = Sedentary or less than 30 minutes exercise ");
                Console.WriteLine(" L = Low activity or at least 30 minutes exercise ");
                Console.WriteLine(" A = Active or at least 1 hour 45 minutes exercise ");
                Console.WriteLine(" E = Extreme or at least 4 hour 15 minutes exercise ");
                Console.Write("Please enter your activity level: ");
                u1[counter].actLevel = char.ToUpper(char.Parse(Console.ReadLine()));
                while (!(u1[counter].actLevel == 'S' || u1[counter].actLevel == 'L' || u1[counter].actLevel == 'A' || u1[counter].actLevel == 'E'))
                {
                    Console.Write("Please enter a S,L,A,E ");
                    Console.WriteLine(" S = Sedentary or less than 30 minutes exercise ");
                    Console.WriteLine(" L = Low activity or at least 30 minutes exercise ");
                    Console.WriteLine(" A = Active or at least 1 hour 45 minutes exercise ");
                    Console.WriteLine(" E = Extreme or at least 4 hour 15 minutes exercise ");
                    Console.Write("Please enter your activity level: ");
                    u1[counter].actLevel = char.ToUpper(char.Parse(Console.ReadLine()));
                }
                Console.Write("Please enter your current weight: ");
                while (getGoing == false)
                {
                    try
                    {
                        u1[counter].weight = Int32.Parse(Console.ReadLine());
                        getGoing = true;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Error! Please enter an integer number:");
                    }
                }
                getGoing = false;     
                Console.Write("Please enter the weight you want to achieve: ");
                while (getGoing == false)
                {
                    try
                    {
                        u1[counter].desiredWeight = Int32.Parse(Console.ReadLine());
                        getGoing = true;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Error! Please enter an integer number:");
                    }
                }
                getGoing = false;
                u1[counter].currentCal = calculateCalories(u1[counter].age, u1[counter].height, u1[counter].weight, u1[counter].personSex, u1[counter].actLevel);
                u1[counter].desiredCal = calculateCalories(u1[counter].age, u1[counter].height, u1[counter].desiredWeight, u1[counter].personSex, u1[counter].actLevel);
                counter++;
                Console.Write("Do you wish to continue? Y or N?: ");
                choice = char.ToUpper(char.Parse(Console.ReadLine()));
                while (!(choice == 'Y' || choice == 'N'))
                {
                    Console.Write("Please enter a Y or N :");
                    choice = char.ToUpper(char.Parse(Console.ReadLine()));
                }
                if (choice == 'Y')
                {
                    Console.WriteLine("You can enter {0} more people", (5 - counter));
                }
            }
            Console.WriteLine("{0,-10} {1,-2} {2,-3} {3,-5} {4,-2} {5,-5} -> {6,-8} {7,-5} -> {8,-8}", "Name","Sex","Age","Height","Activity","CurrWeight","Target","DesiWeight","Target");
            for(int x=0; x<counter; x++)
            {
                calOut = (int)(u1[x].currentCal);
                desiOut = (int)(u1[x].desiredCal);
                Console.WriteLine("{0,-10} {1,-2} {2,4} {3,6} {4,-2} {5,16} -> {6,6} {7,12} -> {8,6}" ,u1[x].name,u1[x].personSex,u1[x].age,u1[x].height,u1[x].actLevel,u1[x].weight,calOut,u1[x].desiredWeight,desiOut);
                calOut = 0;
                desiOut = 0;
            }
            Console.WriteLine("Thanks for using the calorie calculator");
            Console.ReadLine();
        }
        struct userData
        {
            public char personSex,actLevel;
            public int age, height, weight, desiredWeight;
            public double currentCal, desiredCal;
            public string name;
        }
        public static double calculateCalories(int a, int h, int w, char p, char ac)
        {
            double ps,weightMult,heightMult,mult,total1,total2,totalAll;
            double actMult = 0;
            if(p == 'M')
            {
                ps = 9.72;
                weightMult = 6.46;
                heightMult = 12.8;
                mult = 864;
            }
            else
            {
                ps = 7.31;
                weightMult = 4.95;
                heightMult = 16.78;
                mult = 387;
            }
            if(ac == 'S')
            {
                actMult = 1;
            }
            else if(ac == 'L' && p == 'M')
            {
                actMult = 1.12;
            }
            else if(ac == 'L' && p == 'F')
            {
                actMult = 1.14;
            }
            else if(ac == 'A')
            {
                actMult = 1.27;
            }
            else if(ac == 'E' && p == 'M')
            {
                actMult = 1.54;
            }
            else if(ac == 'E' && p == 'F')
            {
                actMult = 1.45;
            }
            total1 = a * ps ;
            total1 = mult - total1;
            total2 = (w * weightMult)+(h * heightMult);
            total2 = (total2 * actMult);
            totalAll = total1 + total2;
            return totalAll;
        }
    }
}
