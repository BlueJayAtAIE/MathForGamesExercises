﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    public struct Vector2
    {
        public float x, y;

        /// <summary>
        /// Creates a new Vector 3 with the specified values.
        /// </summary>
        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }

        /// <summary>
        /// Returns the Magnitude of the Vector2.
        /// </summary>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Returns the Magnitude squared of the Vector2.
        /// This calculation is faster but also less accurate.
        /// </summary>
        public float MagnitudeSqr()
        {
            return x * x + y * y;
        }

        /// <summary>
        /// Gets the distance between two Points (represented by Vector2s).
        /// </summary>
        public float Distance(Vector2 compareTo)
        {
            float diffX = x - compareTo.x;
            float diffY = y - compareTo.y;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        /// <summary>
        /// Changes the Vector2 into a Normalized (Unit) Vector version of itself.
        /// </summary>
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
        }

        /// <summary>
        /// Returns the Normalized (Unit) Vector version of itself without changing the Vector2 into it.
        /// </summary>
        public Vector2 GetNormalized()
        {
            return (this / Magnitude());
        }

        /// <summary>
        /// Returns a perpendicular Vector2 facing Right relitive to the original Vector2.
        /// </summary>
        public Vector2 GetPerpendicular()
        {
            return new Vector2(-y, x);
        }

        /// <summary>
        /// Returns a perpendicular Vector2 facing Left relitive to the original Vector2.
        /// </summary>
        /// <param name="isFacingLeft">If true, returns a left facing perpendicular Vector2.</param>
        public Vector2 GetPerpendicular(bool isFacingLeft)
        {
            if (isFacingLeft)
            {
                return new Vector2(y, -x);
            }
            return GetPerpendicular();
        }

        /// <summary>
        /// Finds the angle in radians between the Vector2 and specified other Vector2.
        /// </summary>
        /// <param name="compareTo">Other Vector2 to compare to for angle calculation.</param>
        public float AngleBetween(Vector2 compareTo)
        {
            // Normalize both Vector3s
            Vector2 a = GetNormalized();
            Vector2 b = compareTo.GetNormalized();

            return (float)Math.Acos(a.DotProduct(b));
        }

        /// <summary>
        /// DEBUG TOOL: prints the values of the Vector2 to the console.
        /// </summary>
        public void PrintValues(string name)
        {
            Console.WriteLine($"Hello, I am Vector2 {name}. I am defined by ({x}, {y}).");
        }

        /// <summary>
        /// DEBUG TOOL: prints the Magnitude of the Vector2 to the console.
        /// </summary>
        public void PrintMagnitude(string name)
        {
            Console.WriteLine($"Hello, I am Vector2 {name}. My magnitude is {Magnitude()}");
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

        // Dot Product
        public float DotProduct(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }
    }




    public struct Vector3
    {
        public float x, y, z;

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
        /// Returns the Magnitude of the Vector3.
        /// </summary>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Returns the Magnitude squared of the Vector3.
        /// This calculation is faster but also less accurate.
        /// </summary>
        public float MagnitudeSqr()
        {
            return x * x + y * y + z * z;
        }

        /// <summary>
        /// Gets the distance between two Points (represented by Vector3s).
        /// </summary>
        public float Distance(Vector3 compareTo)
        {
            float diffX = x - compareTo.x;
            float diffY = y - compareTo.y;
            float diffZ = z - compareTo.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        /// <summary>
        /// Changes the Vector3 into a Normalized (Unit) Vector version of itself.
        /// </summary>
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
        }

        /// <summary>
        /// Returns the Normalized (Unit) Vector version of itself without changing the Vector3 into it.
        /// </summary>
        public Vector3 GetNormalized()
        {
            return (this / Magnitude());
        }

        /// <summary>
        /// Finds the angle in radians between the Vector3 and specified other Vector3.
        /// </summary>
        /// <param name="compareTo">Other Vector3 to compare to for angle calculation.</param>
        public float AngleBetween(Vector3 compareTo)
        {
            // Normalize both Vector3s
            Vector3 a = GetNormalized();
            Vector3 b = compareTo.GetNormalized();

            return (float)Math.Acos(a.DotProduct(b));
        }

        /// <summary>
        /// DEBUG TOOL: prints the values of the Vector3 to the console.
        /// </summary>
        public void PrintValues(string name)
        {
            Console.WriteLine($"Hello, I am Vector3 {name}. I am defined by ({x}, {y}, {z}).");
        }

        /// <summary>
        /// DEBUG TOOL: prints the Magnitude of the Vector3 to the console.
        /// </summary>
        public void PrintMagnitude(string name)
        {
            Console.WriteLine($"Hello, I am Vector3 {name}. My magnitude is {Magnitude()}.");
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

        // Dot Product
        public float DotProduct(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }

        // Cross Product
        public Vector3 CrossProduct(Vector3 rhs)
        {
            return new Vector3(
           y * rhs.z - z * rhs.y,
           z * rhs.x - x * rhs.z,
           x * rhs.y - y * rhs.x);
        }
    }
}
