using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheMouse
{
    class Mouse
    {
        Random random = new Random();
        bool alive = false;
        int location = 0;
        int minutes = 0;
        int dir = 0;
        int numCages; //en lista med antal burar


        public Mouse(int n)
        {
            this.numCages = n; // antal burar skapas i en lista
        }

        public int Minutes() 
        {

            minutes = 0;
            location = (numCages - 1) / 2;
            alive = true;

            while (alive == true)
            {
                minutes++;
                dir = random.Next(2);

                if (dir == 0) //flytta vänster
                {
                    location--;
                }
                else if (dir == 1) //flytta höger
                {
                    location++;
                }

                if ((location == numCages - 1) || (location == 0))
                {
                    alive = false;
                }
            }

            return minutes;
        }
    }
}
