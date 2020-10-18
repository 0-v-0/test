using System;

namespace Engine
{
	public struct Color : IEquatable<Color>
	{
		public uint PackedValue;

		public byte A
		{
			get
			{
				return (byte)(PackedValue >> 24);
			}
			set
			{
				PackedValue = (uint)((int)(PackedValue & 0xFFFFFF) | (value << 24));
			}
		}

		public byte B
		{
			get
			{
				return (byte)(PackedValue >> 16);
			}
			set
			{
				PackedValue = (uint)(((int)PackedValue & -16711681) | (value << 16));
			}
		}

		public byte G
		{
			get
			{
				return (byte)(PackedValue >> 8);
			}
			set
			{
				PackedValue = (uint)(((int)PackedValue & -65281) | (value << 8));
			}
		}

		public byte R
		{
			get
			{
				return (byte)PackedValue;
			}
			set
			{
				PackedValue = (uint)(((int)PackedValue & -256) | value);
			}
		}

		public Color(byte r, byte g, byte b, byte a)
		{
			PackedValue = (uint)((a << 24) | (b << 16) | (g << 8) | r);
		}

		public Color(byte r, byte g, byte b)
		{
			PackedValue = (uint)(-16777216 | (b << 16) | (g << 8) | r);
		}

		public Color(uint packedValue)
		{
			PackedValue = packedValue;
		}

		public override bool Equals(object obj)
		{
			if (obj is Color)
			{
				return Equals((Color)obj);
			}
			return false;
		}

		public bool Equals(Color other)
		{
			return PackedValue == other.PackedValue;
		}

		public override int GetHashCode()
		{
			return (int)PackedValue;
		}

		public override string ToString()
		{
			return $"{R}, {G}, {B}, {A}";
		}
	}
}
