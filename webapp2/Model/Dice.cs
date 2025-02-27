using System;
namespace webapp2.Model
{
    public class Dice
    {
        private int eyes;

        private int size;

        Random r;

        public Dice(int size = 6)
        {
            this.size = size;
            r = new();
        }

        public virtual void Roll() {
            eyes = r.Next(size)+1;
        }

        public int GetEyes() {
            return eyes;
        }
    }
}

