using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Avarage
        {
            get { return sum / Count; }
        }

        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Avarage)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';


                    default:
                        return 'F';

                }
            }
        }
        public double sum;
        public int Count;
        public void Add(double num)
        {
            sum += num;
            Count += 1;
            Low = Math.Min(num, Low);
            High = Math.Max(num, High);

        }
        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}