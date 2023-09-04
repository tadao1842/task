using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileSystem
{
class IniFileManager {

	[DllImport("KERNEL32.DLL")]
	private static extern int WritePrivateProfileString(
		string lpAppName,
		string lpKeyName,
		string lpString,
		string lpFileName
	);

	[DllImport("KERNEL32.DLL")]
	public static extern uint GetPrivateProfileString(
		string lpAppName,
		string lpKeyName,
		string lpDefault,
		StringBuilder lpReturnedString,
		uint nSize,
		string lpFileName
	);

	public static void SetValue(string section, string key, string value, string fileName) {
		WritePrivateProfileString(section, key, value, fileName);
	}

	public static string GetValueString(string section, string key, string fileName) {
		var sb = new StringBuilder(1024);
		GetPrivateProfileString(section, key, "", sb, Convert.ToUInt32(sb.Capacity), fileName);
		return sb.ToString();
	}
}
}
