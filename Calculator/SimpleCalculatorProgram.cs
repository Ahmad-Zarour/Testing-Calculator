using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;

namespace Calculator
{
    public class SimpleCalculatorProgram
    {
       
        static void Main(string[] args)
        {
            float num1, num2;
            float[] arrayOfNumbers = new float[29];
            string input;
            do
            {
                Console.Clear();
                Console.Write("\t\t\t+-*/+-*/ Simple Calculator program +-*/+-*/ \n" +
                "It's a basic calculator doing only + , - , * , / operations between two numbers or up to 30 numbers for + , - operation.\n" +
                "Please enter the type of operation you want to make : ");

                // Get the type of mathematical operation and check if it's a valid + - * /
                string operation = Console.ReadLine();
                ValidOperation(ref operation);

                /* For multiplication and division operations , can only operate with two arrayOfNumberss , get the first the second number 
                and call the chosen operation*/
                if (operation == "/" || operation == "*")
                    
                {
                    Console.WriteLine("Please enter the first number :");
                    num1 = ValidNumber(Console.ReadLine());
                    Console.WriteLine("Please enter the second number :");
                    num2 = ValidNumber(Console.ReadLine());
                    Console.WriteLine($"{num1} {operation} {num2} = {Calculate(operation, num1, num2)}");
                }

                /* For addition and subtraction operations , it can operate with two or more values, 
                 * if the user enter a single value the program will ask for the second one and 
                 * call the basic Addition method that takes two values, otherwise the user can enter a list of numbers
                 * separated by any kind of character or a spaces so the program will get the numbers and place them
                 * in an array and call the overloaded method to makes the chosen operation */
                else
                {
                    Console.WriteLine("Please enter the first number (or) a list of real numbers only separated by comma, space, or any other letters :");
                    input = Console.ReadLine();

                    // To check if the user enter an input that contain digits , if not ask again to enter at least a value or more than one 
                    var digitsCounter = input.Count(n => char.IsNumber(n));
                    while (digitsCounter <= 0)
                    {
                        Console.Beep();
                        Console.WriteLine($"Wrong entry ({input}) please enter at least a nmber or more : ");
                        input = Console.ReadLine();
                        digitsCounter = input.Count(n => char.IsNumber(n));
                    }

                    // If the user enter only one value , so it will ask to enter the second one and call the basic method and makes the Calculation
                    
                    if (float.TryParse(input, out num1))
                    {
                        num1 = ValidNumber(input);
                        Console.WriteLine("Please enter the second number :");
                        num2 = ValidNumber(Console.ReadLine());
                        Console.WriteLine($"{num1} {operation} {num2} = {Calculate(operation, num1, num2)}");

                    }

                    /* In this case the user entered more than a value so program vill get all the numbers and
                       store them in lineOfNumbers and call the overloaded methods that takes an array */

                    else
                    {
                        Console.Write("Calculation done : ");
                        var lineOfNumbers = (Regex.Split(input, @"\D+").Where(v => !string.IsNullOrEmpty(v)).ToArray());
                        int i = 0;
                        foreach (var e in lineOfNumbers)
                        {
                            Console.Write($"{e}");
                            // just for formatting to avoid print out the last operation symbol before equal symbol
                            if (i <= lineOfNumbers.Length - 2)
                                Console.Write($" {operation} ");

                            arrayOfNumbers[i] = float.Parse(e);
                            i++;
                        }
                        Console.WriteLine(" = " + Calculate(operation, 0, 0, arrayOfNumbers));
                    }

                }
                

                Console.WriteLine("Press any key to restart the program , or press enter key to exit ..");
            }
            while (Console.ReadKey().Key != ConsoleKey.Enter);
            Console.Beep();
            Console.WriteLine("Program will exit!");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }


        /// <summary>
        /// Method to check if the entered operation symbol is valid
        /// </summary>
        /// <param name="input"></param>
        public static void ValidOperation(ref string input)
        {
            if ((input != "+") && (input != "-") && (input != "*") && (input != "/"))
            {
                Console.Beep();
                Console.Write($"Wrong entry ({input}) please enter a valid operation + ' - ' * ' / : ");
                input = Console.ReadLine();
                ValidOperation(ref input);
            }
        }

        /// <summary>
        /// Method to check if the entered number is parsable and valid
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float ValidNumber(string input)
        {
            float number;
            bool valid = float.TryParse(input, out number);
            if (!valid)
            {
                Console.Beep();
                Console.WriteLine($"Wrong entry ({input}) please enter a valid numeric number ");
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
        public static float Calculate(string operation, float  v1, float v2 ,params float [] arraysOfNumbers)
        {
            SimpleCalculatorProgram simpleCalculatorProgram = new SimpleCalculatorProgram();
            switch (operation)
            {
                case "+":
                    
                    if (arraysOfNumbers.Length > 0)
                        return simpleCalculatorProgram.Addition(arraysOfNumbers);
                    else
                        return simpleCalculatorProgram.Addition(v1,v2);

                case "-":
                    if (arraysOfNumbers.Length > 0)
                        return simpleCalculatorProgram.Subtraction(arraysOfNumbers);
                    else
                        return simpleCalculatorProgram.Subtraction(v1, v2);


                case "*":
                    return simpleCalculatorProgram.Multiplication(v1, v2);

                case "/":
                    return simpleCalculatorProgram.Division(v1, v2);
                default:
                    Console.WriteLine("Wrong entry!! Valid operation are  + ' - ' * ' / ");
                    break;
            }
            return 0;
        }
        /* the Addition and Subtraction overloaded methods written only as an approval demands for the assignment
           it could be done with one method for each operation*/
           
        // Addition method  .
        public float Addition(float num1, float num2)
        {
            return num1 + num2;
        }
        // Addition method that takes an array as argument.
        public float Addition(float[] num)
        {
            float total = 0;
            for (int i = 0; i < num.Length; i++)
                total += num[i];
            return total;
        }

        // Subtraction method .
        public float Subtraction(float num1, float num2)
        {
            return num1 - num2;
        }
        // Subtraction method that takes an array as argument.
        public float Subtraction(float[] num)
        {
            float total = num [0];
            for (int i = 1; i < num.Length; i++)
                total -=  num[i];
            return total;
        }

        //Division method.
        public float Division(float num1, float num2)
        {
            if  (num2 == 0)
            {
                Console.WriteLine($"Invalid Operation {num1} / {num2} Divide by Zero !!!");
                return float.PositiveInfinity;
            }
            else
                return num1 / num2;
        }

        //Multiplication method.
        public float Multiplication(float num1, float num2)
        {
            return num1 * num2;
        }

    }


}
