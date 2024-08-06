namespace Hadisene.Lib;

public sealed class XO
{
	public bool isEdited;
	public bool isDeleted;

	public string Typ = "S";
	public int mXOId { get; set; }
	public int pXOId { get; set; }

	public int XOId { get; set; }
	public int SrvId { get; set; }
	public int TskId { get; set; }
	public int ActId { get; set; }
	public string? SrvAd { get; set; }
	public string? TskAd { get; set; }
	public string? ActAd { get; set; }

	public int dGun { get; set; }        //kaç gün sonra başlayacak +/-Gun
	public DateTime RSD { get; set; } = DateTime.Today;    //Tarihin zmn kısmı RequestStartTime
	public int RPH { get; set; }         //RequestPeriodHour

	public int iRPH
	{
		get => RPH;
		set
		{
			RPH = Math.Abs(value);
		}
	}
	public string? Rf1 { get; set; }
	public string? Rf2 { get; set; }
	public string? Inf { get; set; }

	public bool Del;

	public int Run;
	public bool isRun
	{
		get => Run == 1 ? true : false;
		set
		{
			Run = value ? 1 : 0;
			Run_dGun = dGun;
		}
	}
	public int Run_dGun;

	public XO ShallowCopy()
	{
		return (XO)this.MemberwiseClone();
	}
}
