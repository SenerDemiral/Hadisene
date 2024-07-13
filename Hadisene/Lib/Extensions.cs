namespace Hadisene.Lib;

using Microsoft.AspNetCore.Components.Forms;
using Sqids;
using System.Runtime.CompilerServices;
using System.Text;

public static class Extensions
{
	//public static StringBuilder sb = new(64);

	private static SqidsEncoder<int> sqids = new SqidsEncoder<int>(new()
	{
		Alphabet = "pxPibcHdV90nTha5A6JegkGN4o7FQlyuCrS1EXvDBRj2zYIUmLOtfqKM38wWsZ",
		//MinLength = 4,
	});
	public static string toSqid(this int inp)
	{
		return sqids.Encode(inp);
	}
	public static int frSqid(this string inp)
	{
		return sqids.Decode(inp).Single();
	}
	// Use Extensions.ChangeToUpper(ref INP);

	public static bool IsAny<T>(this T self, params T[] items)
	{
		//foreach (var itm in items)
		//	if (itm!.Equals(self)) return true;
		//return false;

		// veya
		return items.Contains(self);

		// if (ival.IsAny(1, 2, 3)) {}
		// if (sval.IsAny("OR", "AND", "XOR")) { ... }
	}

	public static string Coalesce(this string? inp)
	{
		return inp ?? "??";
	}

	public static void ChangeToUpper(ref string? inp)
	{
		inp = inp.ToUpper();
	}
	// Use Rf1.RefIncrement(ref ABC)
	public static void RefIncrement(this string src, ref string abc)
	{
		abc = src.ToUpper();
	}
	public static string? toASCII(this string? inp)
	{
		// string is immutable(readonly) so do not change itself
		if (string.IsNullOrEmpty(inp))
			return inp;

		char d;
		StringBuilder sb = new(32);

		foreach (char c in inp)
		{
			d = c switch
			{
				'Ç' => 'C',
				'ç' => 'C',
				'ı' => 'I',
				'İ' => 'I',
				'i' => 'I',
				'Ğ' => 'G',
				'ğ' => 'G',
				'Ş' => 'S',
				'ş' => 'S',
				'Ö' => 'O',
				'ö' => 'O',
				'Ü' => 'U',
				'ü' => 'U',
				',' => '.',
				';' => ':',

				'=' => ' ', // query de kullanıyor, burda izin verme
				'_' => ' ', // like single char
				'%' => ' ', // like string

				'"' => ' ',
				'`' => ' ',
				'\'' => ' ',
				'^' => ' ',

				_ => Char.IsAscii(c) ? Char.ToUpper(c) : ' ',
			};
			if (d != ' ')
			{
				sb.Append(d);
			}
		}
		return sb.ToString();

		//Encoding ascii = Encoding.ASCII;
		//byte[] encodedBytes = ascii.GetBytes(rfs);
		//rf = ascii.GetString(encodedBytes);
	}
	public static string? toASCIIqry(this string? inp)
	{
		if (string.IsNullOrEmpty(inp))
			return inp;

		char d;
		StringBuilder sb = new(32);

		foreach (char c in inp)
		{
			d = c switch
			{
				'Ç' => 'C',
				'ç' => 'C',
				'ı' => 'I',
				'İ' => 'I',
				'i' => 'I',
				'Ğ' => 'G',
				'ğ' => 'G',
				'Ş' => 'S',
				'ş' => 'S',
				'Ö' => 'O',
				'ö' => 'O',
				'Ü' => 'U',
				'ü' => 'U',
				',' => '.',
				';' => ':',

				'=' => ' ', // query de kullanıyor, burda izin verme
				'"' => ' ',
				'`' => ' ',
				'\'' => ' ',
				'^' => ' ',
				' ' => ' ',

				_ => Char.IsAscii(c) ? Char.ToUpper(c) : ' ',
			};
			if (d != ' ')
			{
				sb.Append(d);
			}
		}
		return sb.ToString();
	}

	public static string ToS(this int input)
	{
		return input.ToString("#");
	}

	public static string? ToS(this DateTime? input, bool hasEmoji = false)
	{
		if (!input.HasValue)
		{
			return hasEmoji ? "⚠️" : "";
		}
		DateTime dt = input.Value;
		string result;

		//result = $"Bugün/{dt.ToString("ddd")}";

		if (DateTime.Today == dt.Date)
			result = "Bugün";
		else if (DateTime.Today.AddDays(-1) == dt.Date)
			result = "Dün";
		else if (DateTime.Today.AddDays(1) == dt.Date)
			result = "Yarın";
		else
		{
			if (dt.Year == DateTime.Today.Year)
				result = dt.ToString("dd.MMM.ddd");
			else
				result = dt.ToString("dd.MM.yy");
		}
		if (dt.TimeOfDay != TimeSpan.Zero)
		{
			result = result + " " + dt.ToString("HH:mm");
		}

		return result;

		//if (DateTime.Today == dt.Date)
		//	result = "Bugün" + (hasTime ? dt.TimeOfDay.ToString("hh:mm") : "");
		//return input?.TimeOfDay != TimeSpan.Zero
		//	? input?.ToString("dd.MM.yy hh:mm")
		//	: input?.ToString("dd.MM.yy");
	}
}
