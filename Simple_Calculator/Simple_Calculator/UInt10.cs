//Aurimas Šernas

using System;
using System.Collections;

namespace Simple_Calculator
{
    class UInt10
    {
        // An array where a number will be stored.
        private readonly BitArray number;
        
        /// <summary>
        /// Constructor without any additional inputs.
        /// </summary>
        public UInt10()
        {
            number = new BitArray(10);
            number.SetAll(false);
        }

        /// <summary>
        /// Constructor with an Int32 as an input.
        /// </summary>
        /// <param name="add">A number that will be converted and added to the BitArray</param>
        public UInt10(int add)
        {
            number = new BitArray(10);
            number.SetAll(false);
            ToUInt10(add);
        }

        /// <summary>
        /// Converts an UInt10 integer to Int32 integer.
        /// </summary>
        /// <returns>A UInt10 converted into a Int32 number.</returns>
        public int ToInt32()
        {
            int toReturn = 0; // total sum of all UInt10 values.
            for (int i = 0; i < 10; i++)
            {
                if (number[i]) // we are checking every 'number' value to see if it's true.
                {
                    toReturn += 1 * (int)Math.Pow(2,9-i); //if it's true, we are raising a number 2 by the position of the bit 
                }                                         //(the first bit is 9, second is 8, etc.).
            }
            return toReturn;
        }

        /// <summary>
        /// Converts a Int32 integer to a UInt10 integer.
        /// </summary>
        /// <param name="from">An integer that will be converted to UInt10</param>
        public void ToUInt10(int from)
        {
            BitArray temp = new BitArray(10); // temporary array to store bits.
            int iteration = 0; // how many times we divided integer 'from'.
            temp.SetAll(false); // setting value 'temp' to 0.

            while (from > 0)                    // We are dividing integer 'from' until it reaches 0.
            {
                if (from % 2 == 1)              // In case after division the remainder is 1,
                {                               // we set 'temp' at 'iteration' to 1.
                    temp.Set(iteration, true);  // Afterwards we divide 'from' by 2 and
                }                               // increase 'iteration'.
                from /= 2;
                iteration++;
            }

            for (int i = 0; i < 10; i++) // we are storing a reversed 'temp' to 'number' value.
            {
                number.Set(i, temp.Get(9-i));
            }
        }

        /// <summary>
        /// Returns a bit at specified location.
        /// </summary>
        /// <param name="i">The location of a bit</param>
        /// <returns>A bit at a specified location</returns>
        public bool Get(int i)
        {
            return number[i];
        }

        /// <summary>
        /// Sets a new value of a bit at specified location.
        /// </summary>
        /// <param name="to">To what value the bit will be changed</param>
        /// <param name="i">The location of the value</param>
        public void Set(bool to, int i)
        {
            number[i] = to;
        }

        /// <summary>
        /// Converts a UInt10 integer to a string.
        /// </summary>
        /// <returns>A string represting UInt10 value</returns>
        public override string ToString()
        {
            return this.ToInt32()+"";
        }
    }
}
