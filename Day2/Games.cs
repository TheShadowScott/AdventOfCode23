public class Game
{
    public class Trick
    {
        public int Red { get;set; }
        public int Blue { get;set; }
        public int Green { get;set; }
        public static bool operator >>(Trick a, Trick b)
        {
            return a.Red > b.Red || a.Blue > b.Blue || a.Green > b.Green;
        }
        public static bool operator <<(Trick a, Trick b)
        {
            return a.Red < b.Red || a.Blue < b.Blue || a.Green < b.Green;
        }
        public static Trick SelectGreatest(params Trick[] tricks)
        {
            Trick greatest = new() { Red = 0, Blue = 0, Green = 0 };
            foreach (Trick trick in tricks)
            {
                if (trick.Green > greatest.Green)
                    greatest.Green = trick.Green;
                if (trick.Blue > greatest.Blue)
                    greatest.Blue = trick.Blue;
                if (trick.Red > greatest.Red)
                    greatest.Red = trick.Red;
            }
            return greatest;
        }
        public long Pow()
        {
            return Red * Green * Blue;
        }
    }

    public List<Trick>? Tricks { get; set; }

    public Game(List<Trick> tricks)
    {
        Tricks = tricks;
    }
}