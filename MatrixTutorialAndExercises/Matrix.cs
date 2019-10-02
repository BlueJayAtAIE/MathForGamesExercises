﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace MatrixTutorialAndExercises
{
    class Matrix
    {
        public struct Matrix2
        {
            // m1, m3
            // m2, m4

            public float m1, m2, m3, m4;

            public static Matrix2 identity = new Matrix2(1, 0, 0, 1);
            /// Creates a Matrix2 to the specified floats.
            /// </summary>
            public Matrix2(float M1, float M2, float M3, float M4)
            {
                m1 = M1; m2 = M3;
                m3 = M3; m4 = M4;
            }
            /// <summary>
            /// Returns the transpotition of the Matrix2.
            /// </summary>
            public Matrix2 GetTransposed()
            {
                return new Matrix2(
                    m1, m2,
                    m3, m4);
            }

            /// <summary>
            /// DEBUG TOOL: For printing out the numbers in the Matrix2.
            /// </summary>
            public void PrintCels()
            {
                Console.WriteLine($"{m1}, {m2}");
                Console.WriteLine($"{m3}, {m4}");
            }

            public static Matrix2 operator *(Matrix2 lhs, Matrix2 rhs)
            {
                return new Matrix2(
                    lhs.m1 * rhs.m1 + lhs.m2 + rhs.m3,    lhs.m1 * rhs.m2 + lhs.m2 * rhs.m4,
                    lhs.m3 * rhs.m1 + lhs.m4 + rhs.m3,    lhs.m3 * rhs.m2 + lhs.m4 * rhs.m4);
            }

            public static Vector2 operator *(Matrix2 lhs, Vector2 rhs)
            {
                return new Vector2((lhs.m1 * rhs.x) + (lhs.m3 * rhs.y),
                    (lhs.m2 * rhs.x) + (lhs.m4 * rhs.y));
            }
        }

        public struct Matrix3
        {
            // m1, m4, m7
            // m2, m5, m8
            // m3, m6, m9

            public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

            public static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
            /// Creates a Matrix3 to the specified floats.
            /// </summary>
            public Matrix3(float M1, float M2, float M3, float M4, float M5, float M6, float M7, float M8, float M9)
            {
                // Okay so this would make everything Row Major and
                // all the later examples really want to use Column
                // Major. Because of this, we have to use just this
                // system for the sake of consistancy.

                //m1 = M1; m2 = M2; m3 = M3;
                //m4 = M4; m5 = M5; m6 = M6;
                //m7 = M7; m8 = M8; m9 = M9;

                m1 = M1; m4 = M2; m7 = M3;
                m2 = M4; m5 = M5; m8 = M6;
                m3 = M7; m6 = M8; m9 = M9;
            }
            /// <summary>
            /// Returns the transpotition of the Matrix3.
            /// </summary>
            public Matrix3 GetTransposed()
            {
                return new Matrix3(
                    m1, m2, m3,
                    m4, m5, m6,
                    m7, m8, m9);
            }

            /// <summary>
            /// DEBUG TOOL: For printing out the numbers in the Matrix3.
            /// </summary>
            public void PrintCels()
            {
                Console.WriteLine($"{m1}, {m4}, {m7}");
                Console.WriteLine($"{m2}, {m5}, {m8}");
                Console.WriteLine($"{m3}, {m6}, {m9}");
            }

            public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
            {
                return new Matrix3(
                lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,    lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,    lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,
                lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,    lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,    lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,
                lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,    lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,    lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9);
            }

            public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
            {
                return new Vector3((lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z), 
                    (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                    (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z));
            }
        }

        static void Main(string[] args)
        {
            Matrix3 TestA = new Matrix3(1, 4, 7, 2, 5, 8, 3, 6, 9);
            Matrix3 TestB = new Matrix3(9, 6, 3, 8, 5, 2, 7, 4, 1);

            Matrix3 TestC = new Matrix3(90, 54, 18, 114, 69, 24, 138, 84, 30);
            Vector3 TestD = new Vector3(2, 4, 6);

            Matrix3 TestResult = TestA * TestB;
            TestResult.PrintCels(); 
            // Final Result: 90, 54, 18, 114, 69, 24, 138, 84, 30

            Console.WriteLine("\n");

            Vector3 TestResultB = TestC * TestD;
            TestResultB.PrintValues("Final Result"); 
            // Final result: 504, 648, 792

            Console.WriteLine("\n");

            //Matrix3 TestTranspose = TestResult.GetTransposed();
            //TestTranspose.PrintCels();

            Console.WriteLine("\nEnd of program. Press any key to continue.");
            Console.ReadKey();
        }
    }
}