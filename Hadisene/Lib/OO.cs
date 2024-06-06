﻿namespace Hadisene.Lib;

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

	public int MnVc;	// Msg Not Viewed Count (New) for this Usr

	public string IoC = "I";	// Footer Input or Confirm
	public string SoF = "S";    // Footer Start or Finish

	public bool InfRO = true;
	public bool ReqRO = true;
	public bool SbjRO = true;
	public bool TskRO = true;
	public bool ActRO = true;
	public bool RSDro = true;
	public bool RFDro = true;
	public bool ASDro = true;
	public bool AFDro = true;

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
