﻿namespace Hadisene.Lib;

public sealed class AppState
{
	public string? Tkn = null;
	public int UEXId;
	public int Id;
	public string? Ad = null;
	public int FrmId;
	public string? FrmAd = null;
	public int Ytk = 0;  // 1:Admn, 2:ServisYetkilisi, 3:Actor/Görevli, 4:Requester/İsteyen, 8:Pasif, 9:Ayrıldı
	public string YtkAd => Ytk switch
	{
		1 => "[Admn]",
		2 => "[SrvYtk]",
		3 => "[Görevli]",
		4 => "[İsteyen]",
		_ => "[Yetkisiz]"
	};
	public string SrvStr
	{
		set
		{
			var sa = value.Split(',', StringSplitOptions.RemoveEmptyEntries);
			SrvSet = sa.Select(x => Convert.ToInt32(x)).ToHashSet<int>();
		}
	}
	public required HashSet<int> SrvSet;// = new HashSet<int>();
}
