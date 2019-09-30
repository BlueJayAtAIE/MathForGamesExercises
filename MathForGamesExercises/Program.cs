using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesExercises
{
    class Program
    {
        struct Point
        {
            public float x;
            public float y;
            public float z;
        }

        static void Main(string[] args)
        {
            //Variables.
            char userInputChar = '?';
            float userInputA, userInputB, userInputC; //, userInputD, userInputE;
            Point P1 = new Point();
            Point P2 = new Point();

            // Main Loop
            while (userInputChar != '!')
            {
                Console.Clear();
                Console.Write("Enter a letter for the cooresponding exercise. Enter \"?\" for help. Enter \"!\" to quit. > ");
                userInputChar = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                switch (userInputChar)
                {
                    case '!':
                        Console.WriteLine("\nNow closing...");
                        break;
                    case '?':
                        Console.WriteLine("\nProblem directory:");
                        Console.WriteLine("\"A\" - Math Formula 1.a");
                        Console.WriteLine("\"B\" - Math Formula 1.b");
                        Console.WriteLine("\"C\" - Math Formula 1.c");
                        Console.WriteLine("\"D\" - Math Formula 1.d");
                        Console.WriteLine("\"E\" - Math Formula 1.e");
                        Console.WriteLine("\"F\" - Trigonometry 3.a");
                        Console.WriteLine("\"G\" - Trigonometry 3.b");
                        Console.WriteLine("\"H\" - Trigonometry 8Ch");
                        break;
                    case 'a':
                        Console.Write("Quadratic time. Give me X. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        QuadraticEquation(userInputA);
                        break;
                    case 'b':
                        Console.Write("\nAlright we're gonna do it again but with 3 variables. Give me A. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        Console.Write("Now B. > ");
                        float.TryParse(Console.ReadLine(), out userInputB);
                        Console.Write("Finally C. > ");
                        float.TryParse(Console.ReadLine(), out userInputC);
                        QuadraticFormulaSqrtCheck(userInputA, userInputB, userInputC);
                        break;
                    case 'c':
                        Console.Write("\nI don't actually know what this is but I need 3 variables from you. Give me S. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        Console.Write("Now E .> ");
                        float.TryParse(Console.ReadLine(), out userInputB);
                        Console.Write("Finally T. > ");
                        float.TryParse(Console.ReadLine(), out userInputC);
                        LinearBlend(userInputA, userInputB, userInputC);
                        break;
                    case 'd':
                        Console.Write("\nHey it's the points equation- I need 4 variables. Give me P1.x. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P1.x = userInputA;
                        Console.Write("Now P1.y. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P1.y = userInputA;
                        Console.Write("Next P2.x. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P2.x = userInputA;
                        Console.Write("Finally P2.y. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P2.y = userInputA;
                        PointsDistance(P1, P2);
                        break;
                    case 'e':
                        Console.Write("\nNow it's time for the product of 2 points, I need 6 variables. Give me P.x. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P1.x = userInputA;
                        Console.Write("Now P.y. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P1.y = userInputA;
                        Console.Write("Next P.z. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P1.z = userInputA;
                        Console.Write("Next Q.x. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P2.x = userInputA;
                        Console.Write("Next Q.y. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P2.y = userInputA;
                        Console.Write("Finally Q.z. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        P2.z = userInputA;
                        PointsProduct(P1, P2);
                        break;
                    case 'f':
                        Console.Write("Time for some Conversions- enter an amount in Degrees. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        Console.WriteLine($"{userInputA} Degrees is {DegToRad(userInputA)} Radians");
                        break;
                    case 'g':
                        Console.Write("Time for some Conversions- enter an amount in Radians. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        Console.WriteLine($"{userInputA} Radians is {RadToDeg(userInputA)} Degrees");
                        break;
                    case 'h':
                        Console.Write("\nI'm about to solve all of a triangle's angles- all I need is the sides. Give me A. > ");
                        float.TryParse(Console.ReadLine(), out userInputA);
                        Console.Write("Now B .> ");
                        float.TryParse(Console.ReadLine(), out userInputB);
                        Console.Write("Finally C. > ");
                        float.TryParse(Console.ReadLine(), out userInputC);
                        TriangleSolver(userInputA, userInputB, userInputC);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey(true);
            }

            // Functions
            // Math Forumulas -------
            float QuadraticEquation(float x)
            {
                float result = x * x + x * 2 + 7;
                Console.WriteLine($"{result} = {x}^2 + {x}*2 + 7");
                return result;
            }

            // TODO (?)
            // There wasn't clear direction in the exercise sheet on what this needed to do.
            void QuadraticFormulaSqrtCheck(float a, float b, float c)
            {
                float square = b * b - 4 * a * c;
                double squareCheck = Math.Sqrt(Convert.ToDouble(square));
                if (squareCheck < 0)
                {
                    Console.WriteLine($"Polynomial has no roots.");
                }
                else
                {
                    Console.WriteLine($"Polynomial has roots.");
                }
            }

            float LinearBlend(float s, float e, float t)
            {
                float result = s + t * (e - s);
                Console.WriteLine($"{result} = {s} + {t}({e} - {s})");
                return result;
            }

            float PointsDistance(Point p1, Point p2)
            {
                float square = (p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y);
                float squareCheck = (float)Math.Sqrt(Convert.ToDouble(square));
                Console.WriteLine($"{squareCheck} = Sqrt(({p2.x} - {p1.x})^2 + ({p2.y} - {p1.y})^2)");
                return squareCheck;
            }

            float PointsProduct(Point p, Point q)
            {
                float result = p.x * q.x + p.y * q.y + p.z * q.z;
                Console.WriteLine($"{result} = {p.x} * {q.x} + {p.y} * {q.y} + {p.z} * {q.z}");
                return result;
            }

            // Trigonometry ---------
            float DegToRad(float deg)
            {
                float rad = (deg / 180) * (float)Math.PI;
                return rad;
            }

            float RadToDeg(float rad)
            {
                float deg = (rad / (float)Math.PI) * 180;
                return deg;
            }

            Point TriangleSolver(float a, float b, float c)
            {
                // Visualize it like this: Triangle with sides a, b, and c, and angles X, Y, and Z.
                // The angles are directly Opposite to the letter that corresponds to them in the angle list (by order) ex: a is Opposite of X. 
                // Adjacent and Hypotenuse don't matter bc they play the same role.

                // TEST CASE: ENTER 60, 50, 20
                Point triangleAngles = new Point();
                float tmp;

                // Finding X
                tmp = (b * b + c * c - a * a) / (2 * b * c);
                triangleAngles.x = (float)Math.Acos(tmp);
                triangleAngles.x = RadToDeg(triangleAngles.x);

                // Finding Z
                tmp = Math.Abs(((c * c) - ((a * a) + (b * b))) / -(2 * a * b));
                //Console.WriteLine($"TEST CASE: {Math.Abs((c * c) - ((a * a) + (b * b)))} / {Math.Abs(-(2 * a * b))} SHOULD be 5700 / 6000");
                //Console.WriteLine($"TEST CASE: {tmp} SHOULD be around 0.95");
                triangleAngles.z = (float)Math.Acos(tmp);
                triangleAngles.z =  RadToDeg(triangleAngles.z);
                //Console.WriteLine($"TEST CASE: {triangleAngles.z} SHOULD be around 18.2");
                // also theres a way to make this a lot shorter- having to do with taking the sqrt of the two adjacent sides and... something after that

                // Finding Y
                triangleAngles.y = 180 - triangleAngles.x - triangleAngles.z;

                Console.WriteLine($"Angle A is {triangleAngles.x}");
                Console.WriteLine($"Angle B is {triangleAngles.y}");
                Console.WriteLine($"Angle C is {triangleAngles.z}");

                return triangleAngles;
            }
        }
    }
}
