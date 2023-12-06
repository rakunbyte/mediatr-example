namespace Models;

public class Product
{
    public long Id { get; } = new Random().NextInt64();
    public required string Name { get; set; }
}