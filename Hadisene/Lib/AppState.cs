﻿namespace Hadisene.Lib;

public sealed class AppState
{
	public string? Tkn = null;
	public int UEXId;
	public int Id;
	public string? Ad = null;
	public bool FPS;        // Flag PrivateServis açabilir
	public bool FPP;        // Flag PrivatePeriyodik açabilir
	public bool FPM;        // Flag PrivateModel açabilir
	public int FrmId;
	public string? FrmAd = null;
	public int Ytk = 0;  // 1:Admn, 2:Sorumlu, 3:Denetci, 4:Actor/Görevli, 4:Requester/İsteyen, 8:Pasif, 9:Ayrıldı
	public string YtkAd => Ytk switch
	{
		1 => "[A]",		// Admn
		2 => "[O]",		// Operatör
		3 => "[D]",		// Denetci
		4 => "[K]",		// Kullanıcı
		8 => "[Pasif]",
		9 => "[Ayrıldı]",
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
