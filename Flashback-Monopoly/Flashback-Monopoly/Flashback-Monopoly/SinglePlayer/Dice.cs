using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flashback_Monopoly
{
    class Dice
    {
        Random roll;

        public List<int>[] previousRoll = new List<int>[3];

        public Dice()
        {
            roll = new Random();
        }

        public List<int> Roll(int i)
        {

            List<int> dice = new List<int>();

            for (int j = 0; j < i; j++)
            {
                dice.Add(roll.Next(1, 7));
            }

            previousRoll[2] = previousRoll[1];
            previousRoll[1] = previousRoll[0];
            previousRoll[0] = dice;

            return dice;
        }

        public int Sum(List<int> dices)
        {
            int sum = 0;

            foreach(int dice in dices)
            {
                sum += dice;
            }


            return sum;
        }
    }
}
