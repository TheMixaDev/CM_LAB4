namespace Lab2.Calculation
{
    public class OutputRow
    {
        double y;
        double phi;
        double epsilon;

        public OutputRow(double y, double phi, double epsilon)
        {
            Y = y;
            Phi = phi;
            Epsilon = epsilon;
        }

        public double Y { get => y; set => y = value; }
        public double Phi { get => phi; set => phi = value; }
        public double Epsilon { get => epsilon; set => epsilon = value; }
    }
}
