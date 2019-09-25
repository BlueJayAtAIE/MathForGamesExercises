using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTutorialAndExercises
{
    class Program
    {
        const byte CHAINSAW = 0x01;
        const byte PISTOL = 0x01 << 1;
        const byte SHOTGUN = 0x01 << 2;
        const byte SUPER_SHOTGUN = 0x01 << 3;
        const byte CHAINGUN = 0x01 << 4;
        const byte ROCKET_LAUNCHER = 0x01 << 5;
        const byte PLASMA_GUN = 0x01 << 6;
        const byte BFG9000 = 0x01 << 7;


        public static readonly string[] weapons =
        {
            "Fists", "Chainsaw", "Pistol", "Shotgun", "Super Shotgun",
            "Chaingun", "Rocket Launcher", "Plasma Gun", "BFG9000"
        };

        static void Main(string[] args)
        {
            byte inventory = 0;

            // Comment and uncomment these to see how PrintBinary changes.
            //AddToInventory(ref inventory, CHAINSAW);
            AddToInventory(ref inventory, PISTOL);
            //AddToInventory(ref inventory, SHOTGUN);
            AddToInventory(ref inventory, SUPER_SHOTGUN);
            AddToInventory(ref inventory, CHAINGUN);
            //AddToInventory(ref inventory, ROCKET_LAUNCHER);
            //AddToInventory(ref inventory, PLASMA_GUN);
            //AddToInventory(ref inventory, BFG9000);

            PrintBinary(inventory);

            Console.WriteLine();
            Console.WriteLine(IsLeftMostBitSet(10101100)); //True
            Console.WriteLine(IsLeftMostBitSet(00000010)); //False
            Console.WriteLine(IsRightMostBitSet(01101001)); //True
            Console.WriteLine(IsRightMostBitSet(10110100)); //False

            Console.WriteLine();
            Console.WriteLine(GetRightMostBitSet(10101000)); //4
            Console.WriteLine(GetRightMostBitSet(00100000)); //6
            Console.WriteLine(GetRightMostBitSet(10000000)); //8
            Console.WriteLine(GetRightMostBitSet(00000000)); //-1

            Console.WriteLine();
            Console.WriteLine(IsBitSet(11111010, 0)); //False
            Console.WriteLine(IsBitSet(00100010, 1)); //True
            Console.WriteLine(IsBitSet(1101011011, 6)); //True
            Console.WriteLine(IsBitSet(0000000000, 6)); //Self Destruct

            Console.ReadKey();
        }

        public static void AddToInventory(ref byte inventory, byte weapon)
        {
            inventory |= weapon;
        }

        public static void DisplayInventory(byte inventory)
        {
            Console.Write($"{weapons[0]} | ");

            for (int i = 1; i < weapons.Length; i++)
            {
                int mask = 0x01 << i - 1;
                if ((inventory & mask) == mask)
                {
                    Console.Write($"{weapons[i]} | ");
                }
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Returns true if the left most (the most significant) bit of value is set and
        /// false otherwise.
        /// </summary>
        /// <param name="value">Binary sequence to check.</param>
        public static bool IsLeftMostBitSet(uint value)
        {
            string temp = value.ToString();
            string final = temp;

            // This if and while loop will add the 0s back on 
            // that are lost when converting to a string.
            if (temp.Length < 8)
            {
                while (final.Length < 8)
                {
                    final = temp.Insert(0, "0");
                    temp = final;
                }
            }

            if (final.First() == '1')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if the right most (the least significant) bit of value is set and
        /// false otherwise.
        /// </summary>
        /// <param name="value">Binary sequence to check.</param>
        public static bool IsRightMostBitSet(uint value)
        {
            string temp = Convert.ToString(value);
            if (temp.Last() == '1')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if the asked for bit is set, and false otherwise. bitToCheck is
        /// zero indexed from the right most bit. i.e 0 is the right most bit and 31 is the
        /// left most.
        /// </summary>
        /// <param name="value">Binary sequence to check.</param>
        /// <param name="bitToCheck">Number in the sequnce to check.</param>
        public static bool IsBitSet(uint value, int bitToCheck)
        {
            string temp = Convert.ToString(value);
            int count = Math.Abs(bitToCheck - temp.Length);
            try
            {
                if (temp[count - 1] == '1')
                {
                    return true;
                }
            }
            catch
            {
                Console.Write("Error! Returning false... > ");
            }
            
            return false;
        }

        /// <summary>
        /// This function returns the index of the right most bit set to 1 in value.
        /// If no bits are set, it returns -1.
        /// </summary>
        /// <param name="value">Binary sequence to check.</param>
        public static int GetRightMostBitSet(uint value)
        {
            string temp = Convert.ToString(value);
            int count = 1;

            for (int i = temp.Length; i > 0; i--)
            {
                if (temp[i- 1] == '1')
                {
                    return count;
                }
                count++;
            }

            // If theres no ones.
            return -1;
        }

        /// <summary>
        /// Prints value to the console as a binary number.
        /// </summary>
        /// <param name="value">Binary sequence to print.</param>
        public static void PrintBinary(byte value)
        {
            string temp = Convert.ToString(value, 2);
            string final = temp;

            // This if and while loop will add the 0s back on 
            // that are lost when converting to a string.
            if (temp.Length < 8)
            {
                while (final.Length < 8)
                {
                    final = temp.Insert(0, "0");
                    temp = final;
                }
            }

            Console.WriteLine(temp);
        }
    }
}