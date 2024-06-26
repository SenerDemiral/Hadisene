namespace Hadisene.Lib;
using Sqids;

public static class Extensions
{
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

	public static string? ToS(this DateTime? input)
	{
		if (!input.HasValue)
			return "⚠️";

		DateTime dt = input.Value;
		string result;

		if (DateTime.Today == dt.Date)
			result = "Bugün";
		else if (DateTime.Today.AddDays(-1) == dt.Date)
			result = "Dün";
		else if (DateTime.Today.AddDays(1) == dt.Date)
			result = "Yarın";
		else
		{
			if (dt.Year == DateTime.Today.Year)
				result = dt.ToString("dd-MMM");
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
