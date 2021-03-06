﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem.Biotic
{
    class Plant
    {
        public Plant() { }
        public Brush colour;
        public bool isAlive;
        public string name;
        public float nutrients;
        public float speedOfGrowth;
        public int x;
        public int y;
        public int age;
        public int hasSeed;

        virtual public void Grow(World world) { }
        virtual public void Age() { age++;  }

        public bool CheckForSpace(World world, int directionX, int directionY) // true -> can plant a seed
        {
            bool isFree = true;
            int i = 0;
            while (i < world.plants.Count)
            {
                if (this != world.plants[i])
                {
                    if ((x + directionX == world.plants[i].x && y == world.plants[i].y) ||
                        (y + directionY == world.plants[i].y && x == world.plants[i].x) ||
                        (x + directionX == world.plants[i].x && y + directionY == world.plants[i].y))
                    {
                        isFree = false; break;
                    }
                }
                i++;
            }
            if (!isFree) return false;
            else return true;
        }

        public void PaintPlant(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(x, y, 1, 1);
            graphics.DrawRectangle(Pens.Green, rectangle);
            graphics.FillRectangle(Brushes.Green, rectangle);
        }

    }
}
