namespace Hadisene.Lib;

public sealed class OO
{
	public int Idx;
	public DateTime? UpdTS;

	public int UsrId;   // Last updated by 

	public int OOId;
	public int ReqId;
	public int SbjId;
	public int TskId;
	public int ActId;

	public string? Inf;

	public DateTime? RSD;
	public DateTime? ASD;
	public DateTime? RFD;
	public DateTime? AFD;

	public string? ReqAd;
	public string? SbjAd;
	public string? TskAd;
	public string? ActAd;

	// Color/Condition
	public string CS = "";	// Start R/B/G
	public string CF = "";  // Finish R/B/G
	
	// Delay Star/Finish Hour (+:Gecikme, -:Erken)
	public string? DSX;
	public string? DFX;

	public string Stu = "";
	public int Pin {
		get => Pinned ? 1 : 0;
		set {
			Pinned = value == 1;
		}
	}
	public bool Pinned = false;

	public int MnVc;	// Msg Not Viewed Count (New) for this Usr

	public string IoC = "I";	// Footer Input or Confirm
	public string SoF = "S";    // Footer Start or Finish

	public bool InfRO = false;
	public bool ReqRO = true;
	public bool SbjRO = false;
	public bool TskRO = false;
	public bool ActRO = false;
	public bool RSDro = false;
	public bool RFDro = false;
	public bool ASDro = false;
	public bool AFDro = false;

	public string? RSDf => RSD?.ToString("dd.MM.yy HH:mm");
	public string? RFDf => RFD?.ToString("dd.MM.yy HH:mm");
	public string? ASDf => ASD?.ToString("dd.MM.yy HH:mm");
	public string? AFDf => AFD?.ToString("dd.MM.yy HH:mm");

	public string MnVcF => MnVc > 99 ? "+99" : MnVc.ToString("#");

	public OO ShallowCopy()
	{
		return (OO)this.MemberwiseClone();
	}
}
