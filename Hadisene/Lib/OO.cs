namespace Hadisene.Lib;

public sealed class OO
{
    public int Idx;
    public DateTime? InsTS;
    public DateTime? Trh;
    public DateTime? UpdTS;
    public string? UpdFlg;

	//public int UsrId;   // Last updated by 

	public int OOId;
	public int pOOId;
    public string? Stu = "A";
    public int ReqId;
    public int SrvId;
    public int TskId;
    public int ActId;

    public string? Inf;
    public string? Rf1;
    public string? Rf2;

    public DateTime? RSD;
    public DateTime? ASD;
    public DateTime? RFD;
    public DateTime? AFD;

    public string? ReqAd;
    public string? SrvAd;
    public string? TskAd;
    public string? ActAd;

    // Color/Condition
    public string CS = "";  // Start R/B/G
    public string CF = "";  // Finish R/B/G

    // Delay/Sapma Star/Finish Hour (+:Gecikme, -:Erken)
    public string? DSX;
    public string? DFX;

    public bool noInf => Inf is null && Rf1 is null && Rf2 is null;
    public int Pin
    {
        get => Pinned ? 1 : 0;
        set
        {
            Pinned = value == 1;
        }
    }
    public bool Pinned = false;

    public int is_Mbr;
    public bool isMbr => is_Mbr == 1 ? true : false;

    public int is_Edt;
    public bool isEdt => is_Edt == 1 ? true : false;

    public int is_Act;
    public bool isAct => is_Act == 1 ? true : false;

    public int is_SF;
    public bool isSF => is_SF == 1 ? true : false;

    public int CId; // ChainId, Sıfırdan farklıysa Chained
    public bool Chain;

    public int MnVc;    // Msg Not Viewed Count (New) for this Usr

    public string IoC = "I";    // Footer Input or Confirm
    public string SoF = "S";    // Footer Start or Finish

    public bool StuROa = true;
    public bool StuROx = true;
    public bool StuROz = true;
    public bool InfRO = true;
    public bool ReqRO = true;
    public bool SrvRO = true;
    public bool TskRO = true;
    public bool ActRO = true;
    public bool RSDro = true;
    public bool RFDro = true;
    public bool ASDro = true;
    public bool AFDro = true;
    public bool ChainRO = true;
    public bool Rf1RO = true;
    public bool Rf2RO = true;

    public string MnVcF => MnVc > 99 ? "+99" : MnVc.ToString("#");

    public OO ShallowCopy()
    {
        return (OO)this.MemberwiseClone();
    }

    //public string? OrdUsrs
    //{
    //    set
    //    {
    //        var sa = value?.Split(',', StringSplitOptions.RemoveEmptyEntries);
    //        if (sa != null)
    //        {
    //            foreach (var s in sa)
    //            {
    //                var xa = s.Split(':', StringSplitOptions.RemoveEmptyEntries);
    //                var k = int.Parse(xa[0]);
    //                var v = int.Parse(xa[1]);
    //                OrdUsrMap.Add(k, v);
    //            }
    //        }
    //    }
    //}
    //public Dictionary<int, int> OrdUsrMap = new();	// Usr,Rol
}
