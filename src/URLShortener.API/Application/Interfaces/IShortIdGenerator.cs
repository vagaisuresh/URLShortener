namespace URLShortener.API.Application.Interfaces;

public interface IShortIdGenerator
{
    string Generate(int length = 8);
}