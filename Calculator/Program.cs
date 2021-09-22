using System;
using System.Threading;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
           do  
            {
                Console.Clear();
                Console.WriteLine("\t\t\t+-*/+-*/ Simple Calculator program +-*/+-*/ \n" +
                " It's a basic calculator doing only + , - , * , / operations between two numbers.\n" +
                " Please enter the type of operation you want to make : ");
                string operation = Console.ReadLine();
                ValidOperation(ref operation);
                float [] value = new float[2];
                Console.WriteLine("Please enter the first number :");
                value[0] = ValidNumber(Console.ReadLine());
                Console.WriteLine("Please enter the second number :");
                value[1] = ValidNumber(Console.ReadLine());
                Console.WriteLine($"{value[0]} {operation} {value[1]} = {Calculate(operation, value[0], value[1])}");
                Console.WriteLine("Press any key to restart the program , or press enter key to exit ..");
            }
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
            Console.Beep();
            Console.WriteLine("Program will exit!");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }


        /// <summary>
        /// Method to check if the entered operation symbol is valid
        /// </summary>
        /// <param name="input"></param>
        static void ValidOperation(ref string input)
        {
            if ((input != "+") && (input != "-") && (input != "*") && (input != "/"))
            {
                Console.Beep();
                Console.WriteLine($"Wrong entry ({input}) please enter a valid operation + ' - ' * ' / :");
                input = Console.ReadLine();
                ValidOperation(ref input);
            }
        }

        /// <summary>
        /// Method to check if the entered number is parsable and valid
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float  ValidNumber(string x)
        {
            float number;
            bool valid = float.TryParse(x, out number);
            if (!valid)
            {
                Console.Beep();
                Console.WriteLine($"Wrong entry ({x}) please enter a valid numeric number ");
                return ValidNumber(Console.ReadLine()); 
            }
            else
                return number;
        }

        /// <summary>
        /// Method to heck which operation the user entered and call the suitable mathematical operation method
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static float Calculate (string operation,float v1, float v2 )
        {
            switch (operation)
            {
                case "+":
                   return Addition(v1,v2);
                
                case "-":
                    return Subtraction(v1,v2);
                 
                    
                case "*":
                    return Multiplication(v1,v2);
                   
                case "/":
                    return Division(v1,v2);   
            }
            return 0;
        }

        // Addition method
        public static float Addition(float num1, float num2)
        {
            return num1 + num2;
        }

        // Subtraction method
        public static float Subtraction(float num1, float num2)
        {
            return num1 - num2;
        }

        //Division method
        public static float Division(float num1, float num2)
        {
            if ((num1 == 0) || (num2 == 0))
            { 
                Console.WriteLine($"Invalid operation {num1} / {num2} , Divided by zero!!!");
                return float.PositiveInfinity;
            }
            else
                return num1 / num2;
        }

        //Multiplication method
        public static float Multiplication(float num1, float num2)
        {
            return num1 * num2;
        }
    }


}
