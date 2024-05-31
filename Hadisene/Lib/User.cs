using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hadisene.Lib;

public class User : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;
	int clicks;

	public int Clicks
	{
		get => clicks;
		set
		{
			if (clicks != value)
			{
				clicks = value;
				OnPropertyChanged();
			}
		}
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = default)
	   => PropertyChanged?.Invoke(this, new(propertyName));
}
