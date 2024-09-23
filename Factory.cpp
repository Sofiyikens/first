public class Factory
{
    public int Id{ get; set; }
    public double P{ get; set; }
    public double F{ get; set; }
    public double O1 = > P - F;
    public double O2 = > O1 * 100 / P;

    public Factory(int id, double p, double f)
    {
        Id = id;
        P = p;
        F = f;
    }
}