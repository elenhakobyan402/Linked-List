namespace MyHashTableProj;

public class MyHashTable
{


    #region Additive Hash
    public static int AdditiveHash(string input)
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
    #endregion Additive Hash

    #region Folding Hash
    public static int FoldingHash(string input)
    {
        int HashValue = 0;
        int startIndex = 0;
        int currentFourBytes;

        do
        {
            currentFourBytes = GetNextBytes(startIndex, input);

            unchecked
            {
                HashValue += currentFourBytes;
            }
            startIndex += 4;
        }
        while (currentFourBytes != 0);
        return HashValue;
    }

    #endregion Folding Hash

    #region Folding Helpers
    public static int GetNextBytes(int startIndex, string str)
    {
        int currentFourBytes = 0;

        currentFourBytes += GetByte(str, startIndex);
        currentFourBytes += GetByte(str, startIndex + 1) << 8;
        currentFourBytes += GetByte(str, startIndex + 2) << 16;
        currentFourBytes += GetByte(str, startIndex + 3) << 24;

        return currentFourBytes;
    }

    public static int GetByte(string str, int index)
    {
        if (index < str.Length)
        {
            return (int)str[index];
        }
        return 0;
    }

    #endregion Folding Helpers
}

