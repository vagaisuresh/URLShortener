namespace URLShortener.API.Interfaces
{
    public interface IShortIdGenerator
    {
        string Generate(int length = 8);
    }
}