using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsTutorialAndExercises
{
    class Program
    {
        class Vector2
        {
            public float x, y;

            /// <summary>
            /// Creates an empty Vector2.
            /// </summary>
            public Vector2()
            {
                x = 0;
                y = 0;
            }

            /// <summary>
            /// Creates a new Vector 3 with the specified values.
            /// </summary>
            public Vector2(float X, float Y)
            {
                x = X;
                y = Y;
            }

            /// <summary>
            /// DEBUG TOOL: prints the values of the Vector2 to the console.
            /// </summary>
            public void PrintValues(string name)
            {
                Console.WriteLine($"Hello, I am Vector2 {name}. I am defined by ({x}, {y}).");
            }

            // Addition
            public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
            {
                return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
            }

            // Subtraction
            public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
            {
                return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
            }

            // Multiplication
            public static Vector2 operator *(Vector2 lhs, float rhs)
            {
                return new Vector2(lhs.x * rhs, lhs.y * rhs);
            }
            public static Vector2 operator *(float lhs, Vector2 rhs)
            {
                return new Vector2(lhs * rhs.x, lhs * rhs.y);
            }

            // Division
            public static Vector2 operator /(Vector2 lhs, float rhs)
            {
                return new Vector2(lhs.x / rhs, lhs.y / rhs);
            }
            public static Vector2 operator /(float lhs, Vector2 rhs)
            {
                return new Vector2(lhs / rhs.x, lhs / rhs.y);
            }
        }

        class Vector3
        {
            public float x, y, z;

            /// <summary>
            /// Creates an empty Vector3.
            /// </summary>
            public Vector3()
            {
                x = 0;
                y = 0;
                z = 0;
            }

            /// <summary>
            /// Creates a new Vector3 with the specified values.
            /// </summary>
            public Vector3(float X, float Y, float Z)
            {
                x = X;
                y = Y;
                z = Z;
            }

            /// <summary>
            /// DEBUG TOOL: prints the values of the Vector3 to the console.
            /// </summary>
            public void PrintValues(string name)
            {
                Console.WriteLine($"Hello, I am Vector3 {name}. I am defined by ({x}, {y}, {z}).");
            }

            // Addition
            public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
            {
                return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
            }

            // Subtraction
            public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
            {
                return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
            }

            // Multiplication
            public static Vector3 operator *(Vector3 lhs, float rhs)
            {
                return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
            }
            public static Vector3 operator *(float lhs, Vector3 rhs)
            {
                return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
            }

            // Division
            public static Vector3 operator /(Vector3 lhs, float rhs)
            {
                return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
            }
            public static Vector3 operator /(float lhs, Vector3 rhs)
            {
                return new Vector3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
            }
        }


        static void Main(string[] args)
        {
            Vector3 test = new Vector3(10, 10 , 10);
            Vector3 testAD = new Vector3(2, 2, 2);
            float testMD = 2;

            test.PrintValues("Test");

            test += testAD;
            test.PrintValues("Test");

            test -= testAD;
            test.PrintValues("Test");

            test *= testMD;
            test.PrintValues("Test");

            test /= testMD;
            test.PrintValues("Test");

            Console.WriteLine("\nEnd of program. Press any key to continue.");
            Console.ReadKey();
        }
    }
}
