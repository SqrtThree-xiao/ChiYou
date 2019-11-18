//xlua管理类
using XLua;

public class LuaEvnManager
{
	private LuaEvnManager(){}
	private static LuaEnv _L;
	private static LuaEvnManager _instance;
	public static LuaEvnManager Instance 
	{
		get
		{
			if (_instance == null)
			{
				_instance = new LuaEvnManager();
				_L = new LuaEnv();
			}
			return _instance;
		}
	}

	public void RunLuaCode(string msg)
	{
		_L.DoString(msg);
		_L.Dispose();
	}
}
