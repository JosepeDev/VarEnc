﻿using System;

public class EncString_0_6_0
{
    /// A class for storing a string while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a wierd string that is affected by random very long an wierd key. { encryptionKey }
    /// Every time the value of the string changes, the encryption key changes too. And it works exactly as an string.
    ///
    /// Wiki page: https://github.com/JosepeDev/VarEnc/wiki

    #region Variables And Properties

    private string _encryptionKey;
    private string _encryptedValue;

    private string Value
    {
        get => EncryptorDecryptor(_encryptedValue, _encryptionKey);
        set => _encryptedValue = EncryptorDecryptor(value, _encryptionKey);
    }

    public int Length
    {
        get => Value.Length;
    }

    public static string Empty
    {
        get => string.Empty;
    }

    public char this[int index]
    {
        get
        {
            return Value[index];
        }
    }

    #endregion

    #region Methods

    public static string ReplaceAt(string input, int index, char newChar)
    {
        if (input != null)
        {
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
        else return null;
    }

    public bool Equal(EncString_0_6_0 encString) => encString.Value == this.Value;

    public bool IsNull() => this.Value == null;

    public char[] ToCharArray() => this.Value.ToCharArray();

    public object Clone() => Value.Clone();

    public override string ToString()
    {
        return Value.ToString();
    }

    #endregion

    #region Constructors

    public static EncString_0_6_0 NewEncString(string value)
    {
        EncString_0_6_0 encString = new EncString_0_6_0
        {
            _encryptionKey = RandomString(),
            Value = value
        };
        return encString;
    }

    public static EncString_0_6_0 NewEncString(char[] characters) => NewEncString(new string(characters));

    public static EncString_0_6_0 NewEncString(char c, int count) => NewEncString(new string(c, count));

    public static EncString_0_6_0 NewEncString(char[] value, int startIndex, int length) => NewEncString(new string(value, startIndex, length));

    #endregion

    #region Encryption Decryption

    static Random random = new Random();

    public static char RandomChar() => RandomChar(char.MinValue, char.MaxValue - 1);

    public static char RandomChar(int min, int max)
    {
        return (char)(random.Next(min, max));
    }

    public static char RandomNormalChar() => RandomChar(48, 125);

    public static string RandomString()
    {
        char[] chars = new char[100];
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = RandomChar();
        }
        return new string(chars);
    }

    public static string RandomNormalString()
    {
        char[] chars = new char[25];
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = RandomNormalChar();
        }
        return new string(chars);
    }

    private static string EncryptorDecryptor(string data, string key)
    {
        if (data == null || key == null)
        {
            return null;
        }
        else
        {
            int dataLen = data.Length;
            int keyLen = key.Length;
            char[] output = new char[dataLen];

            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(data[i] ^ key[i % keyLen]);
            }

            return new string(output);
        }
    }

    #endregion

    #region Operators Overloading

    /// == != < >
    public static bool operator ==(EncString_0_6_0 es1, string es2) => es1.Value == es2;
    public static bool operator !=(EncString_0_6_0 es1, string es2) => es1.Value != es2;

    /// assign
    public static implicit operator EncString_0_6_0(string value) => EncString_0_6_0.NewEncString(value);
    public static implicit operator string(EncString_0_6_0 encString) => encString.Value;

    #endregion
}