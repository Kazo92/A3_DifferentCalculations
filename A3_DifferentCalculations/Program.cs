using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3_DifferentCalculations
{
    class Program
    {
        enum AvailableFormats { DOUBLE, FLOAT, INT, LONG, HEADING };

        static void Main(string[] args)
        {
            try
            {
                double inputX = GetValue("X");
                double inputY = GetValue("Y");

                WriteWholeLine(AvailableFormats.HEADING, inputX, inputY);
                WriteWholeLine(AvailableFormats.DOUBLE, inputX, inputY);
                WriteWholeLine(AvailableFormats.FLOAT, inputX, inputY);
                WriteWholeLine(AvailableFormats.INT, inputX, inputY);
                WriteWholeLine(AvailableFormats.LONG, inputX, inputY);
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Error noticed. Contact developer.");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        static double GetValue(string valueName)
        {
            double result;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{valueName}: ");
            Console.ResetColor();

            bool check = double.TryParse(Console.ReadLine(), out result);
            
            if (check) return result;
            else throw new ArgumentException("Chosen value is not numeric.");
        } 

        static void WriteWholeLine(AvailableFormats formatType, double inputX, double inputY)
        {
            double X=0;
            double Y=0;
            double division;

            switch (formatType)
            {
                case AvailableFormats.HEADING:
                    Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10}{7,10}",
                        "Format", "X/Y ? Y/X", "X*Y", "X+Y", "Sin(X)", "TG(Y)", "Sqrt(X)", "POW(X,Y)");
                    return;
                case AvailableFormats.DOUBLE:
                    X = inputX;
                    Y = inputY;
                    break;
                case AvailableFormats.INT:
                    X = (double)((int)inputX);
                    Y = (double)((int)inputY);
                    break;
                case AvailableFormats.LONG:
                    X = (double)((long)inputX);
                    Y = (double)((long)inputY);
                    break;
                case AvailableFormats.FLOAT:
                    X = (double)((float)inputX);
                    Y = (double)((float)inputY);
                    break;
                default:
                    return;
            }

            if (X == 0) division = X / Y;
            else if (Y == 0) division = Y / X;
            else division = 0;

            Console.WriteLine("{0,10}{1,10:F4}{2,10:F4}{3,10:F4}{4,10:F4}{5,10:F4}{6,10:F4}{7,10:F4}",
                formatType.ToString(), division, X*Y, X+Y, Math.Sin(X), Math.Tan(Y), Math.Sqrt(X), Math.Pow(X,Y));
        }
    }
}
