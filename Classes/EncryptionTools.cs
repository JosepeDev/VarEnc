using System;

static class EncryptionTools
{
    /// Not a class you should use. But it is a requirement to have it if you want to use the EncryptedInt class.
    /// Just copy it with EncryptedInt and forget about it.
    /// This is just a static class the EncryptedInt class uses to get a random float.
    /// 
    /// Wiki page: https://github.com/JosepeDev/SimpleEncryptionTools/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/SimpleEncryptionTools/wiki/Examples-&-Tutorial

    #region Methods

    // The Random class for getting the random numbers
    static private Random random = new Random();

    // Returns a random float between 1 and 10
    public static float RandomNumber()
    {
        return (float)(random.NextDouble() * 10);
    }

    #endregion
}