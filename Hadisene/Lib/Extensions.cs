namespace Hadisene.Lib;

public static class Extensions
{
	public static string? ToS(this DateTime? input)
	{
		if (input != null)
		{
			return input?.TimeOfDay != TimeSpan.Zero
				? input?.ToString("dd.MM.yy hh:mm")
				: input?.ToString("dd.MM.yy");
		}
		return "⚠️";
	}
}
