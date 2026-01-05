using URLShortener.API.Application.Interfaces;

namespace URLShortener.API.Application.Utilities;

public class ShortIdGenerator : IShortIdGenerator
{
    private static readonly char[] _characters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

    private readonly Random _random = new Random();

    public string Generate(int length = 8)
    {
        if (length <= 0)
            throw new ArgumentException("Length must be greater than zero.", nameof(length));

        char[] shortId = new char[length];
        for (int i = 0; i < length; i++)
        {
            shortId[i] = _characters[_random.Next(_characters.Length)];
        }
        return new string(shortId);
    }
}