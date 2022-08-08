public struct Coordinate
{
    public int x;
    public int y;
    public static Coordinate Zero => new(0, 0);
    public Coordinate(int x = 0, int y = 0)
    {
        this.x = x;
        this.y = y;
    }
}