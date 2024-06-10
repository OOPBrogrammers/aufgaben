namespace Blatt2A2
{
    class Program
    {
        public class Time
        {
            private int minuten;

            public Time(int stunden, int minuten)
            {
                this.minuten = 60 * stunden + minuten;
            }

            private Time(int minuten)
            {
                this.minuten = minuten;
            }

            public static implicit operator Time(string s)
            {
                string[] stelle = s.Split(":");
                int stunden = int.Parse(stelle[0]);
                int minuten = int.Parse(stelle[1]);

                return new Time(stunden, minuten);
            }

            public static implicit operator Time(int k)
            {
                return new Time(k);
            }

            public static implicit operator bool(Time t)
            {
                return t.minuten < 720;
            }

            public static Time operator +(Time t, string s)
            {
                string[] stelle = s.Split(":");
                int stunden = int.Parse(stelle[0]);
                int minuten = int.Parse(stelle[1]);
                Time ts = new Time(stunden, minuten);

                return new Time(t.minuten + ts.minuten);
            }

            public static Time operator +(Time t, int minuten)
            {
                return new Time(t.minuten + minuten);
            }

            public static bool operator ==(Time t1, Time t2)
            {
                return t1.minuten == t2.minuten;
            }

            public static bool operator !=(Time t1, Time t2)
            {
                return !(t1 == t2);
            }
            
            public static TimeSpan operator -(Time t1, Time t2)
            {
                int diffMin = t1.minuten - t2.minuten;
                return new TimeSpan(diffMin);
            }

            public override string ToString()
            {
                int stu = minuten / 60;
                int min = minuten % 60;
                return $"{stu:D2}:{min:D2} Uhr";
            }
        }

        public class TimeSpan
        {
            private readonly int minuten;

            public TimeSpan(int minuten)
            {
                this.minuten = minuten;
            }

            public int TotalMins => minuten;

            public override string ToString()
            {
                int stunden = minuten / 60;
                int min = minuten % 60;
                return $"{stunden}h{min}min";
            }
        }

        static void Main(string[] args)
        {
            Time t1 = new Time(9, 45);
            Time t2 = t1 + "1:30" + 15;
            Time t3 = "11:30";
            TimeSpan tDiff = t2 - t1;

            Console.WriteLine($"t1: {t1}");
            Console.WriteLine($"t2: {t2}");

            Console.WriteLine($"tDiff: {tDiff}");

            Console.WriteLine($"tDiff in Minuten: {tDiff.TotalMins}");

            if (t2)
            {
                Console.WriteLine("Guten Morgen");
            }
            else
            {
                Console.WriteLine("Guten Tag");
            }

            if (t2 == t3)
            {
                Console.WriteLine("Die Uhrzeiten sind gleich!");
            }
            else
            {
                Console.WriteLine("Die Uhrzeiten stimmen nicht überein!");
            }
        }
    }
}