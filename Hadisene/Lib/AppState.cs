namespace Hadisene.Lib;

public sealed class AppState
{
	public string? UsrTkn = null;
	public int UEXId;
	public int UsrFrmId;
	public int UsrId;
	public int OOId;
	public string? UsrAd = null;
	public string? UsrFrmAd = null;
	public int UsrYtk = 0;  // 1:Admn, 2:ServisYetkilisi, 3:Actor, 4:Requester
	private string? _UsrSrvStr;
	public string? UsrSrvStr {  
		get => _UsrSrvStr; 
		set {
			_UsrSrvStr = value;
			UsrSrv.Clear();
			var sa = value?.Split(',', StringSplitOptions.RemoveEmptyEntries);
			if (sa != null)
			{
				foreach (var s in sa)
				{
					if (int.TryParse(s, out int r))
					{
						UsrSrv.Add(r);
					}
				}
			}
		}
	}
	public HashSet<int> UsrSrv = new HashSet<int>();

	private void Init()
	{
		//if(UsrSrv.Contains(55))
			
		//foreach (var s in UsrSrv) { 
			
		//}
	}
}
