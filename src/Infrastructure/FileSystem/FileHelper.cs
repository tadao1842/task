using System;
using System.IO;

namespace Infrastructure.FileSystem
{
static class FileHelper
{
	public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
	{
		if (source.FullName.ToLower() == target.FullName.ToLower())
		{
			return;
		}

		if (Directory.Exists(target.FullName) == false)
		{
			Directory.CreateDirectory(target.FullName);
		}

		foreach (FileInfo fi in source.GetFiles())
		{
			fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
		}

		foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		{
			DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
			CopyAll(diSourceSubDir, nextTargetSubDir);
		}
	}
}
}
