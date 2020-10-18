using System;
using System.IO;
using LibPixz;

namespace Sorter
{
	class Program
	{
		static void Main(string[] args)
		{
			//Environment.CurrentDirectory = @"D:\Documents\Tencent Files\1347360374\Image\Group\Image4\新建文件夹";
			string path = args.Length > 2 ? args[1] : Environment.CurrentDirectory;
			var e = Directory.EnumerateFiles(path, "*.jpg").GetEnumerator();
			while (e.MoveNext())
			{
				var c = e.Current;
				var s = File.OpenRead(c);
				try
				{
					int count = Pixz.Decode(s)[0].Count;
					count = (int)Math.Log(count, 1.33);
					Directory.CreateDirectory(count.ToString());
					s.Close();
					s = null;
					File.Move(c, Path.Combine(count.ToString(), Path.GetFileName(c)));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
				finally
				{
					s?.Close();
				}
			}
		}
	}
}
