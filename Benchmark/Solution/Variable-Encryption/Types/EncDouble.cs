﻿using System;

public struct EncDouble
{
    /// A struct for storing a Double while efficiently keeping it encrypted in the memory.
    /// Instead of encrypting and decrypting yourself, you can just use the encrypted type (EncType) of the variable you want to be encrypted
    /// The encryption will happen in the background without you worrying about it
    /// In the memory it is saved as a an array of weird bytes that are affected by random values { encryptionKeys array }
    /// Every time the value changes, the encryption keys change too. And it works exactly as a double.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables And Properties

    // The encryption values
    private readonly byte[] encryptionKeys;

    // The encrypted value stored in memory
    private readonly byte[] encryptedValue;

    // The decrypted value
    public double Value
    {
        get => Decrypt();
    }

    public static Double Epsilon { get => Double.Epsilon; }
    public static Double MaxValue { get => Double.MaxValue; }
    public static Double MinValue { get => Double.MinValue; }
    public static Double NaN { get => Double.NaN; }
    public static Double NegativeInfinity { get => Double.NegativeInfinity; }
    public static Double PositiveInfinity { get => Double.PositiveInfinity; }

    #endregion

    #region Methods And Constructors

    private EncDouble(double value)
    {
        encryptionKeys = new byte[8];
        encryptedValue = Encrypt(value, encryptionKeys);
    }

    // Encryption key generator
    static private Random random = new Random();

    // Takes a given value and returns it encrypted
    private static byte[] Encrypt(double value, byte[] keys)
    {
        random.NextBytes(keys);
        var valueBytes = BitConverter.GetBytes(value);
        for (int i = 0; i < 8; i++)
        {
            valueBytes[i] ^= keys[i];
        }
        return valueBytes;
    }

    // Takes an encrypted value and returns it decrypted
    private double Decrypt()
    {
        var valueBytes = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            valueBytes[i] = (byte)(encryptedValue[i] ^ encryptionKeys[i]);
        }
        return BitConverter.ToDouble(valueBytes);
    }

    // Overrides
    public int CompareTo(object value) => Value.CompareTo(value);
    public int CompareTo(Double value) => Value.CompareTo(value);
    public bool Equals(Double obj) => Value.Equals(obj);
    public override bool Equals(object obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
    public TypeCode GetTypeCode() => Value.GetTypeCode();
    public override string ToString() => Value.ToString();
    public string ToString(IFormatProvider provider) => Value.ToString(provider);
    public string ToString(string format) => Value.ToString(format);
    public string ToString(string format, IFormatProvider provider) => Value.ToString(format, provider);

    #endregion

    #region Operators Overloading

    /// + - * / %
    public static EncDouble operator +(EncDouble eint1, EncDouble eint2) => new EncDouble(eint1.Value + eint2.Value);
    public static EncDouble operator -(EncDouble eint1, EncDouble eint2) => new EncDouble(eint1.Value - eint2.Value);
    public static EncDouble operator *(EncDouble eint1, EncDouble eint2) => new EncDouble(eint1.Value * eint2.Value);
    public static EncDouble operator /(EncDouble eint1, EncDouble eint2) => new EncDouble(eint1.Value / eint2.Value);
    public static EncDouble operator %(EncDouble eint1, EncDouble eint2) => new EncDouble(eint1.Value % eint2.Value);

    public static double operator +(EncDouble edouble1, ulong edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, ulong edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, ulong edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, ulong edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, ulong edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, long edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, long edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, long edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, long edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, long edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, uint edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, uint edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, uint edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, uint edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, uint edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, int edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, int edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, int edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, int edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, int edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, ushort edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, ushort edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, ushort edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, ushort edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, ushort edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, short edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, short edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, short edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, short edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, short edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, byte edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, byte edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, byte edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, byte edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, byte edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, sbyte edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, sbyte edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, sbyte edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, sbyte edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, sbyte edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, double edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, double edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, double edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, double edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, double edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, float edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, float edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, float edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, float edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, float edouble2) => edouble1.Value % edouble2;

    /// == != < >

    public static bool operator ==(EncDouble eint1, EncDouble eint2) => eint1.Value == eint2.Value;
    public static bool operator !=(EncDouble eint1, EncDouble eint2) => eint1.Value != eint2.Value;
    public static bool operator <(EncDouble eint1, EncDouble eint2) => eint1.Value < eint2.Value;
    public static bool operator >(EncDouble eint1, EncDouble eint2) => eint1.Value > eint2.Value;

    public static bool operator ==(EncDouble eint1, ulong eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, ulong eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, ulong eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, ulong eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, long eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, long eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, long eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, long eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, uint eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, uint eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, uint eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, uint eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, int eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, int eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, int eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, int eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, ushort eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, ushort eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, ushort eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, ushort eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, short eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, short eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, short eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, short eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, byte eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, byte eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, byte eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, byte eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, sbyte eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, sbyte eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, sbyte eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, sbyte eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, decimal eint2) => (decimal)eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, decimal eint2) => (decimal)eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, decimal eint2) => (decimal)eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, decimal eint2) => (decimal)eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, double eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, double eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, double eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, double eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, float eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, float eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, float eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, float eint2) => eint1.Value < eint2;

    /// assign
    public static implicit operator EncDouble(ulong value) => new EncDouble(value);
    public static implicit operator EncDouble(long value) => new EncDouble(value);
    public static implicit operator EncDouble(uint value) => new EncDouble(value);
    public static implicit operator EncDouble(int value) => new EncDouble(value);
    public static implicit operator EncDouble(ushort value) => new EncDouble(value);
    public static implicit operator EncDouble(short value) => new EncDouble(value);
    public static implicit operator EncDouble(byte value) => new EncDouble(value);
    public static implicit operator EncDouble(sbyte value) => new EncDouble(value);
    public static explicit operator EncDouble(decimal value) => new EncDouble((double)value);
    public static implicit operator EncDouble(double value) => new EncDouble(value);
    public static implicit operator EncDouble(float value) => new EncDouble(value);

    public static explicit operator decimal(EncDouble eint1) => (decimal)eint1.Value;
    public static implicit operator double(EncDouble eint1) => eint1.Value;
    public static explicit operator float(EncDouble eint1) => (float)eint1.Value;
    public static explicit operator ulong(EncDouble eint1) => (ulong)eint1.Value;
    public static explicit operator long(EncDouble eint1) => (long)eint1.Value;
    public static explicit operator uint(EncDouble eint1) => (uint)eint1.Value;
    public static explicit operator int(EncDouble eint1) => (int)eint1.Value;
    public static explicit operator ushort(EncDouble eint1) => (ushort)eint1.Value;
    public static explicit operator short(EncDouble eint1) => (short)eint1.Value;
    public static explicit operator byte(EncDouble eint1) => (byte)eint1.Value;
    public static explicit operator sbyte(EncDouble eint1) => (sbyte)eint1.Value;

    #endregion
}