﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleHoraceGrasshopper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare constants
            const Int32 XLIMIT = 8;
            const Int32 YLIMIT = 8;

            //Declare and initialize variables
            Int32 iOldX = 0;
            Int32 iOldY = 0;
            Int32 iNewX = 0;
            Int32 iNewY = 0;
            Int32 iZeroCount = 0;

            Random rnd = new Random();
            Boolean bAllTilesCovered = false;

            //Make the floor
            Int32[,] iFloor = new Int32[XLIMIT, YLIMIT];

            //Randomly generate a starting point
            //iStart = rnd.Next(XLIMIT, YLIMIT);

            //Set the values to zero
            for (Int32 j = 0; j < YLIMIT; j++)
            {
                for (Int32 i = 0; i < XLIMIT; i++)
                {
                    iFloor[j, i] = 0;
                }
            }

            //Randomly select a tile
            iNewX = rnd.Next(0, XLIMIT);
            iNewY = rnd.Next(0, YLIMIT);

            //Increment that tile's count
            iFloor[iNewX, iNewY]++;

            while (!bAllTilesCovered)
            {
                

                //Randomly select new title coordinates that are adjacent to but not the same as
                iOldX = iNewX;
                iOldY = iNewY;

                while ((iOldX == iNewX) && (iOldY == iNewY))
                {
                    iNewX = rnd.Next(0, XLIMIT);
                    iNewY = rnd.Next(0, YLIMIT);
                }

                //Move Gregor to the new tile(increment that tile's value)
                iFloor[iNewX, iNewY]++;
                iZeroCount = 0;

                //Traverse the array to determine if any value is still 0
                for (Int32 j = 0; j < YLIMIT; j++)
                {
                    for (Int32 i = 0; i < XLIMIT; i++)
                    {
                        if (iFloor[j, i] == 0)
                        {
                        iZeroCount++;
                        }
                    }
                }

                if (iZeroCount == 0)
                {
                    bAllTilesCovered = true;
                }
            } //End of the while loop that generates moves

            //If no more moves, end the program
            Console.Clear();
            Console.WriteLine("\nHorace the Grasshopper is hopping around the kitchen floor!\n"
                + "Here is the matrix of how many times he visited each tile on the floor!\n");
            for (Int32 j = 0; j < XLIMIT; j++)
            {
                for (Int32 i = 0; i < YLIMIT; i++)
                {
                    Console.Write(iFloor[j, i].ToString() + "\t");
                }
                Console.WriteLine("\n");
            }

            Pause("Horace has explored the entire kitchen!\nGame Over!");
        }

        static void Pause(String s)
        {
            Console.WriteLine("\n" + s);
            Console.WriteLine("Press <enter> to continue.");
            Console.ReadLine();
        }
    }
}
