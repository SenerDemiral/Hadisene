namespace Hadisene.Lib;

public sealed class OO
{
	public int Idx;
	public DateTime? UpdTS;
	public string? UpdFlg;

	public int UsrId;   // Last updated by 

	public int OOId;
	public string? Stu = "A";
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

	public int Pin {
		get => Pinned ? 1 : 0;
		set {
			Pinned = value == 1;
		}
	}
	public bool Pinned = false;
	public int CId; // ChainId, Sıfırdan farklıysa Chained
	public bool Chain;

	public int MnVc;	// Msg Not Viewed Count (New) for this Usr

	public string IoC = "I";	// Footer Input or Confirm
	public string SoF = "S";    // Footer Start or Finish

	public bool StuROa = true;
	public bool StuROx = true;
	public bool StuROz = true;
	public bool InfRO = true;
	public bool ReqRO = true;
	public bool SbjRO = true;
	public bool TskRO = true;
	public bool ActRO = true;
	public bool RSDro = true;
	public bool RFDro = true;
	public bool ASDro = true;
	public bool AFDro = true;
	public bool ChainRO = true;

	public string MnVcF => MnVc > 99 ? "+99" : MnVc.ToString("#");

	public OO ShallowCopy()
	{
		return (OO)this.MemberwiseClone();
	}

	public string? OrdUsrs
	{
		set
		{
			var sa = value?.Split(',', StringSplitOptions.RemoveEmptyEntries);
			if (sa != null)
			{
				foreach (var s in sa)
				{
					if (int.TryParse(s, out int r))
					{
						OrdUsrSet.Add(r);
					}
				}
			}
		}
	}
	public HashSet<int> OrdUsrSet = new();
}
