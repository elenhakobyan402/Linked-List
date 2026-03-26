namespace HashTableProject;

internal class Program
{
    private static int startIndex;

    private static void Main()
    {

    }

    private static int AdditiveHash(string input)
    {
        int currentHashValue = 0;
        foreach (char c in input)
        {
            unchecked
            {
                currentHashValue += (int)c;
            }
        }
        return currentHashValue;
    }

    private static int FoldingHash(string input)
    {
        int HashValue = 0;
        int startdex = 0;
        int currentFourBytes;

        do
        {
            currentFourBytes = GetNextBytes(startIndex,input);

            unchecked
            {
                HashValue += currentFourBytes;
            }
            startIndex += 4;
        }
        while (currentFourBytes != 0);
        return HashValue;
    }

    private static int GetNextBytes(int startIndex,string str)
    {
        int currentFourBytes = 0;

        currentFourBytes += GetByte(str, startIndex);
        currentFourBytes += GetByte(str, startIndex + 1) << 8;
        currentFourBytes += GetByte(str, startIndex + 1) << 16;
        currentFourBytes += GetByte(str, startIndex + 1) << 24;

        return currentFourBytes;
    }

    private static int GetByte(string str, int index)
    {
        if (index < str.Length)
        {
            return (int)str[index];
        }
        return 0;
    }
}