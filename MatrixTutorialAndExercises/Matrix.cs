using System;
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

            /// <summary>
            /// Creates a Matrix2 to the specified floats.
            /// </summary>
            public Matrix2(float M1, float M2, float M3, float M4)
            {
                m1 = M1; m2 = M3;
                m3 = M2; m4 = M4;
            }

            void Set(Matrix2 m)
            {
                m1 = m.m1; m3 = m.m3;
                m2 = m.m2; m4 = m.m4;
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

            // Scaling --------------------------------------
            public void SetScaled(float x, float y)
            {
                m1 = x; m3 = 0;
                m2 = 0; m4 = y;
            }

            public void SetScaled(Vector2 v)
            {
                m1 = v.x; m3 = 0;
                m2 = 0; m4 = v.y;
            }

            public void Scale(float x, float y)
            {
                Matrix2 m = new Matrix2();
                m.SetScaled(x, y);

                Set(this * m);
            }

            public void Scale(Vector2 v)
            {
                Matrix2 m = new Matrix2();
                m.SetScaled(v);

                Set(this * m);
            }

            // Rotating ----------------------------------------------
            // X
            public void SetRotateX(double radians)
            {
                Matrix2 m = new Matrix2(
                    1, (float)-Math.Sin(radians),
                    0, (float)Math.Cos(radians));

                Set(m);
            }

            public void RotateX(double radians)
            {
                Matrix2 m = new Matrix2();
                m.SetRotateX(radians);
                Set(this * m);
            }

            // Y
            public void SetRotateY(double radians)
            {
                Matrix2 m = new Matrix2(
                    (float)Math.Cos(radians), 0,
                    (float)Math.Sin(radians), 1);

                Set(m);
            }

            public void RotateY(double radians)
            {
                Matrix2 m = new Matrix2();
                m.SetRotateY(radians);
                Set(this * m);
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

            /// <summary>
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
            /// Sets the Matrix3 to the supplied Matrix3.
            /// </summary>
            void Set(Matrix3 m)
            {
                m1 = m.m1; m4 = m.m4; m7 = m.m7;
                m2 = m.m2; m5 = m.m5; m8 = m.m8;
                m3 = m.m3; m6 = m.m6; m9 = m.m9;
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

            // Scaling --------------------------------------
            public void SetScaled(float x, float y, float z)
            {
                m1 = x; m4 = 0; m7 = 0;
                m2 = 0; m5 = y; m8 = 0;
                m3 = 0; m6 = 0; m9 = z;
            }

            public void SetScaled(Vector3 v)
            {
                m1 = v.x; m4 = 0; m7 = 0;
                m2 = 0; m5 = v.y; m8 = 0;
                m3 = 0; m6 = 0; m9 = v.z;
            }

            public void Scale(float x, float y, float z)
            {
                Matrix3 m = new Matrix3();
                m.SetScaled(x, y, z);

                Set(this * m);
            }

            public void Scale(Vector3 v)
            {
                Matrix3 m = new Matrix3();
                m.SetScaled(v);

                Set(this * m);
            }

            // Rotating ----------------------------------------------
            // X
            public void SetRotateX(double radians)
            {
                Matrix3 m = new Matrix3(
                    1, 0, 0,
                    0, (float)Math.Cos(radians), (float)Math.Sin(radians),
                    0, (float)-Math.Sin(radians), (float)Math.Cos(radians));

                Set(m);
            }

            public void RotateX(double radians)
            {
                Matrix3 m = new Matrix3();
                m.SetRotateX(radians);
                Set(this * m);
            }

            // Y
            public void SetRotateY(double radians)
            {
                Matrix3 m = new Matrix3(
                    (float)Math.Cos(radians), 0, (float)-Math.Sin(radians),
                    0, 1, 0,
                    (float)Math.Sin(radians), 0, (float)Math.Cos(radians));

                Set(m);
            }

            public void RotateY(double radians)
            {
                Matrix3 m = new Matrix3();
                m.SetRotateY(radians);
                Set(this * m);
            }

            // Z
            public void SetRotateZ(double radians)
            {
                Matrix3 m = new Matrix3(
                    (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                    (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                    0, 0, 1);

                Set(m);
            }

            public void RotateZ(double radians)
            {
                Matrix3 m = new Matrix3();
                m.SetRotateZ(radians);
                Set(this * m);
            }

            // Euler Angle Based
            public void SetEuler(float pitch, float yaw, float roll)
            {
                Matrix3 x = new Matrix3();
                Matrix3 y = new Matrix3();
                Matrix3 z = new Matrix3();
                x.SetRotateX(pitch);
                y.SetRotateY(yaw);
                z.SetRotateZ(roll);

                Set(z * y * x);
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

            // Multiplication
            public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
            {
                return new Matrix3(
                lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,    
                lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,    
                lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,

                lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,    
                lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,    
                lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,

                lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,    
                lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,    
                lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9);
            }

            public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
            {
                return new Vector3((lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z), 
                    (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                    (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z));
            }
        }

        public struct Matrix4
        {
            public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

            public static Matrix4 identity = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

            public Matrix4(float M1, float M2, float M3, float M4, float M5, float M6, float M7, float M8, float M9, float M10, float M11, float M12, float M13, float M14, float M15, float M16)
            {
                m1 = M1;  m5 = M2;  m9 = M3;   m13 = M4;
                m2 = M5;  m6 = M6;  m10 = M7;  m14 = M8;
                m3 = M9;  m7 = M10; m11 = M11; m15 = M12;
                m4 = M13; m8 = M14; m12 = M15; m16 = M16;
            }

            /// <summary>
            /// Sets the Matrix4 to the supplied Matrix4.
            /// </summary>
            void Set(Matrix4 m)
            {
                m1 = m.m1; m5 = m.m5; m9 = m.m9;   m13 = m.m13;
                m2 = m.m2; m6 = m.m6; m10 = m.m10; m14 = m.m14;
                m3 = m.m3; m7 = m.m7; m11 = m.m11; m15 = m.m15;
                m4 = m.m4; m8 = m.m8; m12 = m.m12; m16 = m.m16;
            }

            /// <summary>
            /// Returns the transpotition of the Matrix4.
            /// </summary>
            public Matrix4 GetTransposed()
            {
                return new Matrix4(
                    m1,  m2,  m3,  m4,
                    m5,  m6,  m7,  m8,
                    m9,  m10, m11, m12,
                    m13, m14, m15, m16);
            }

            /// <summary>
            /// DEBUG TOOL: For printing out the numbers in the Matrix4.
            /// </summary>
            public void PrintCels()
            {
                Console.WriteLine($"{m1}, {m5}, {m9}, {m13}");
                Console.WriteLine($"{m2}, {m6}, {m10}, {m14}");
                Console.WriteLine($"{m3}, {m7}, {m11}, {m15}");
                Console.WriteLine($"{m4}, {m8}, {m12}, {m16}");
            }

            // Scaling -----------------------------------
            public void SetScaled(float x, float y, float z)
            {
                m1 = x;  m2 = 0;  m3 = 0;  m4 = 0;
                m5 = 0;  m6 = y;  m7 = 0;  m8 = 0;
                m9 = 0;  m10 = 0; m11 = z; m12 = 0;
                m13 = 0; m14 = 0; m15 = 0; m16 = 1;
            }
            public void SetScaled(Vector3 v)
            {
                m1 = v.x; m2 = 0;   m3 = 0;    m4 = 0;
                m5 = 0;   m6 = v.y; m7 = 0;    m8 = 0;
                m9 = 0;   m10 = 0;  m11 = v.z; m12 = 0;
                m13 = 0;  m14 = 0;  m15 = 0;   m16 = 1;
            }

            public void Scale(float x, float y, float z)
            {
                Matrix4 m = new Matrix4();
                m.SetScaled(x, y, z);

                Set(this * m);
            }
            public void Scale(Vector3 v)
            {
                Matrix4 m = new Matrix4();
                m.SetScaled(v);

                Set(this * m);
            }

            // Rotating ------------------------
            // X
            public void SetRotateX(double radians)
            {
                Matrix4 m = new Matrix4(
                1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1);

                Set(m);
            }
            public void RotateX(double radians)
            {
                Matrix4 m = new Matrix4();
                m.SetRotateX(radians);
                Set(this * m);
            }

            // Y
            public void SetRotateY(double radians)
            {
                Matrix4 m = new Matrix4(
                    (float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
                    0, 1, 0, 0,
                    (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                    0, 0, 0, 1);

                Set(m);
            }
            public void RotateY(double radians)
            {
                Matrix4 m = new Matrix4();
                m.SetRotateY(radians);
                Set(this * m);
            }

            // Z
            public void SetRotateZ(double radians)
            {
                Matrix4 m = new Matrix4(
                    (float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                    (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1);

                Set(m);
            }
            public void RotateZ(double radians)
            {
                Matrix4 m = new Matrix4();
                m.SetRotateZ(radians);
                Set(this * m);
            }

            // Euler Angle Based
            public void SetEuler(float pitch, float yaw, float roll)
            {
                Matrix4 x = new Matrix4();
                Matrix4 y = new Matrix4();
                Matrix4 z = new Matrix4();
                x.SetRotateX(pitch);
                y.SetRotateY(yaw);
                z.SetRotateZ(roll);

                Set(z * y * x);
            }

            // Translating ------------------------
            public void SetTranslate(float x, float y, float z)
            {
                m13 = z; m14 = y; m15 = x; m16 = 1;
            }
            void Translate(float x, float y, float z)
            {
                m13 += z; m14 += y; m15 += x;
            }

            // Multiplication
            public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
            {
                // NOTES: So because of the magic of column/row major stuff we need this transpose at the end.
                // Please just. Don't ask questions. 

                Matrix4 result = new Matrix4(
               rhs.m1 * lhs.m1 + rhs.m2 * lhs.m5 + rhs.m3 * lhs.m9  + rhs.m4 * lhs.m13,
               rhs.m1 * lhs.m2 + rhs.m2 * lhs.m6 + rhs.m3 * lhs.m10 + rhs.m4 * lhs.m14,
               rhs.m1 * lhs.m3 + rhs.m2 * lhs.m7 + rhs.m3 * lhs.m11 + rhs.m4 * lhs.m15,
               rhs.m1 * lhs.m4 + rhs.m2 * lhs.m8 + rhs.m3 * lhs.m12 + rhs.m4 * lhs.m16,

               rhs.m5 * lhs.m1 + rhs.m6 * lhs.m5 + rhs.m7 * lhs.m9  + rhs.m8 * lhs.m13,
               rhs.m5 * lhs.m2 + rhs.m6 * lhs.m6 + rhs.m7 * lhs.m10 + rhs.m8 * lhs.m14,
               rhs.m5 * lhs.m3 + rhs.m6 * lhs.m7 + rhs.m7 * lhs.m11 + rhs.m8 * lhs.m15,
               rhs.m5 * lhs.m4 + rhs.m6 * lhs.m8 + rhs.m7 * lhs.m12 + rhs.m8 * lhs.m16,

               rhs.m9 * lhs.m1 + rhs.m10 * lhs.m5 + rhs.m11 * lhs.m9  + rhs.m12 * lhs.m13,
               rhs.m9 * lhs.m2 + rhs.m10 * lhs.m6 + rhs.m11 * lhs.m10 + rhs.m12 * lhs.m14,
               rhs.m9 * lhs.m3 + rhs.m10 * lhs.m7 + rhs.m11 * lhs.m11 + rhs.m12 * lhs.m15,
               rhs.m9 * lhs.m4 + rhs.m10 * lhs.m8 + rhs.m11 * lhs.m12 + rhs.m12 * lhs.m16,

               rhs.m13 * lhs.m1 + rhs.m14 * lhs.m5 + rhs.m15 * lhs.m9  + rhs.m16 * lhs.m13,
               rhs.m13 * lhs.m2 + rhs.m14 * lhs.m6 + rhs.m15 * lhs.m10 + rhs.m16 * lhs.m14,
               rhs.m13 * lhs.m3 + rhs.m14 * lhs.m7 + rhs.m15 * lhs.m11 + rhs.m16 * lhs.m15,
               rhs.m13 * lhs.m4 + rhs.m14 * lhs.m8 + rhs.m15 * lhs.m12 + rhs.m16 * lhs.m16);

                return result.GetTransposed();
            }

            public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
            {
                return new Vector4(
               (lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z)  + (lhs.m13 * rhs.w),
               (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w),
               (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w),
               (lhs.m4 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w));
            }
        }

        static void Main(string[] args)
        {
            Matrix3 TestA = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3 TestB = new Matrix3(2, 2, 2, 2, 2, 2, 2, 2, 2);

            Matrix3 TestC = new Matrix3(90, 54, 18, 114, 69, 24, 138, 84, 30);
            Vector3 TestD = new Vector3(2, 4, 6);

            Matrix3 TestResult = TestA * TestB;
            TestResult.PrintCels(); 

            Console.WriteLine("\n");

            Vector3 TestResultB = TestC * TestD;
            //TestResultB.PrintValues("Final Result"); 
            // Final result: 504, 648, 792

            Console.WriteLine("\n");

            Matrix4 TestE = new Matrix4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4 TestF = Matrix4.identity;

            TestE.PrintCels();

            Console.WriteLine("AFTER MULTIPLYING BY IDENTITY");

            Matrix4 TestResultC = TestE * TestF;
            TestResultC.PrintCels();

            Console.WriteLine("AFTER MULTIPLYING BY MATRIX CONSISITING OF 2s");
            Matrix4 TestG = new Matrix4(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2);
            TestResultC = TestE * TestG;
            TestResultC.PrintCels();

            //Matrix3 TestTranspose = TestResult.GetTransposed();
            //TestTranspose.PrintCels();

            Console.WriteLine("\nEnd of program. Press any key to continue.");
            Console.ReadKey();
        }
    }
}
