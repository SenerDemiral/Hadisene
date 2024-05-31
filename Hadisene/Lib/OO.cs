namespace Hadisene.Lib;

public sealed class OO
{
	public int Idx;
    public DateTime? UpdTS;

    public int UsrId;	// Last updated by 
    
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

	public string CS = "";
	public string CF = "";
	public int DSH;
	public int DFH;


	public string Stu = "";
	public int Pin { 
		get => Pinned ? 1 : 0;
		set {
			Pinned = value == 1;
		}
	}
	public bool Pinned = false;

	public int MnVc;
	public string IoC = "I";
	public string SoF = "S";

	public string ConfirmTyp = "S";

	public string? RSDf => RSD?.ToString("dd.MM.yy HH:mm");
	public string? RFDf => RFD?.ToString("dd.MM.yy HH:mm");
	public string? ASDf => ASD?.ToString("dd.MM.yy HH:mm");
	public string? AFDf => AFD?.ToString("dd.MM.yy HH:mm");
}
