namespace Hadisene.Lib;

public class NotifierService
{
	public async Task Invoke(string key, NotifyArgs value)
	{
		if (Notify is not null)
			await Notify.Invoke(key, value);
	}
	public async Task InvokeIO(string key, int value)
	{
		if (NotifyIO is not null)
			await NotifyIO.Invoke(key, value);
	}

	public event Func<string, NotifyArgs, Task>? Notify;
	public event Func<string, int, Task>? NotifyIO;	// Deneme

	public bool UsrExists(int[] usrs, int id)
	{
		return Array.IndexOf(usrs, id) != -1;
	}
}

public sealed class NotifyArgs
{
	public int UsrId;
	public int FFId;
	public int OOId;
	public int OMId;

	public int[] OrdUsrs = [];
}