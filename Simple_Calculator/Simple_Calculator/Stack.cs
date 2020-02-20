using System;

namespace Simple_Calculator
{
    internal class Stack
    {
        private readonly static int MAX = 5; // Maximum length of 'stack'

        private readonly UInt10[] stack;     // An array where all the values will be stored
        public int Top { get; private set; } // The location of the last added element in the array.

        /// <summary>
        /// Constructot of a Stack object.
        /// </summary>
        public Stack()
        {
            stack = new UInt10[MAX];
            Top = -1;
        }

        /// <summary>
        /// Function that adds 'add' to a UInt10 array.
        /// </summary>
        /// <param name="add">Integer we want to add</param>
        /// <returns>If addition of a new element was successful</returns>
        internal bool Push(int add)
        {
            if (Top >= MAX-1) // If we are over the maximum amount we return false.
            {
                return false;
            }
            else
            {
                stack[++Top] = new UInt10(add); // Otherwise we add the integer to the array and return true.
                return true;
            }
        }

        /// <summary>
        /// If possible returns the topmost value from the stack.
        /// </summary>
        /// <returns>Last value from the stack</returns>
        internal UInt10 Pop()
        {
            if (Top < 0) // If stack is empty returns a 0.
            {
                return new UInt10();
            }
            else
            {
                UInt10 value = stack[Top--]; // Otherwise reduces the stack by 1 and returns the value.
                return value;
            }
        }

        /// <summary>
        /// Adds the two topmost values together and adds it to the stack.
        /// </summary>
        /// <returns>The sum of two values.</returns>
        internal UInt10 Add()
        {
            UInt10 value1 = this.Pop(); // We pop out the two top most values from the stack. 
            UInt10 value2 = this.Pop();

            UInt10 value = new UInt10();
            bool memory = false;        // An extra bit that will be carried over to the next iteration.

            for (int i = 9; i >= 0; i--)
            {
                if (memory && (value1.Get(i) && value2.Get(i))) // Case 1 + 1 + 1.
                {
                    value.Set(true, i);
                    memory = true;
                }
                else if (memory && (value1.Get(i) || value2.Get(i))) // Case 1 + 1 + 0.
                {
                    memory = true;
                    value.Set(false, i);
                }
                else if ((value1.Get(i) && !value2.Get(i)) || (!value1.Get(i) && value2.Get(i))) // Case 1 + 0 or 0 + 1 .
                {
                    value.Set(true, i);
                }
                else if (value1.Get(i) && value2.Get(i)) // Case 1 + 1.
                {
                    memory = true;
                    value.Set(false, i);
                }
                else if (memory) // Case 1 + 0 + 0
                {
                    value.Set(true, i);
                    memory = false;
                }
            }
            this.Push(value.ToInt32()); // We add the sum of two values to the stack.
            return value;
        }

        /// <summary>
        /// Subtracts the second topmost value from the topmost and adds it to the stack.
        /// </summary>
        /// <returns>Subtraction of the two values</returns>
        internal UInt10 Sub()
        {
            UInt10 value = new UInt10();

            UInt10 value1 = this.Pop(); // We pop the two topmost values out of the stack.
            UInt10 value2 = this.Pop();

            for (int i = 9; i >= 0; i--)
            {
                if (value1.Get(i) && !value2.Get(i)) // Case 1 - 0
                {
                    value.Set(true, i);
                }
                else if (!value1.Get(i) && !value2.Get(i)) // Case 0 - 0
                {
                    value.Set(false, i);
                }
                else if (value1.Get(i) && value2.Get(i)) // Case 1 - 1
                {
                    value.Set(false, i);
                }
                else if (!value1.Get(i) && value2.Get(i)) // Case 0 - 1
                {
                    int next = FindNextBit(value1, i); // We find the next 1 in the array
                    UpdateBits(value1, i, next);       // and update the bit values from that bit
                                                       // to the current iteration.
                    value.Set(true, i);
                }
            }

            this.Push(value.ToInt32()); // We add the subtracted number to the stack.
            return value;
        }

        /// <summary>
        /// Finds the next 1 in a BitArray from a specified location.
        /// If a location was not found, returns -1.
        /// </summary>
        /// <param name="number">BitArray where we need to find the next 1</param>
        /// <param name="i">Current iteration</param>
        /// <returns>The location of the next 1</returns>
        private int FindNextBit(UInt10 number, int i)
        {
            for (int j = i; j >= 0; j--)
            {
                if (number.Get(j))
                {
                    return j;
                }
            }

            return -1;
        }

        /// <summary>
        /// Changes the values of a 'number' from 'i' to 'j' to 1's.
        /// </summary>
        /// <param name="number">The number we want to update</param>
        /// <param name="i">the starting point</param>
        /// <param name="j">the end point</param>
        /// <returns>A new UInt10 value</returns>
        private UInt10 UpdateBits(UInt10 number, int i, int j)
        {
            if (j > 0)                          // If the location was found we want to
            {                                   // set all the bits from i to j - 1 to 1
                for (int k = i; k > j; k--)     // and set j to false.
                {
                    number.Set(true, k);
                }
                number.Set(false, j);

                return number;
            }
            else                                // If the location was not found we want to
            {                                   // set all the bits from i to 0 to 1
                for (int k = i; k >= 0; k--)    // in doing so inverting the rest of the number.
                {                               // We need to do this to reduce the number modulo
                    number.Set(true, k);        // from the largest value that can be represented.
                }

                return number;
            }
        }

        /// <summary>
        /// Converts the entire stack to a string value.
        /// </summary>
        /// <returns>'stack' array elements converted to a string</returns>
        public override string ToString()
        {
            if (Top > 0)
            {
                string value = "stack is: ";
                for (int i = 0; i < Top; i++)
                {
                    value += stack[i].ToString() + ", ";
                }
                return value + stack[Top].ToString();
            }
            else if (Top == 0)
            {
                return "stack is: " + stack[0].ToString();
            }
            else
            {
                return "stack is empty";
            }
        }
    }
}
