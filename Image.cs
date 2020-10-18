namespace Engine
{
	public class Image
	{
		public readonly int Width;

		public readonly int Height;

		public int Count;

		//public readonly Color[] Pixels;

		public Image(int width, int height)
		{
			Width = width;
			Height = height;
			//Pixels = new Color[width * height];
		}

		public static int Max(int x1, int x2)
		{
			if (x1 <= x2)
			{
				return x2;
			}
			return x1;
		}
	}
}
