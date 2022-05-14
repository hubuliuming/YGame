/****************************************************
    文件：GameManager.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;

public class GameManager : MonoSingleton<GameManager>
{
    //private Stopwatch t = new Stopwatch();
    private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;

    private void OnDestroy()
    {
        MsgDispatcher.UnRegisterAll();
    }

    public void InitPlayer()
    {
        _playerData = YJsonUtility.Load<PlayerData>(Paths.PlayerData);
    }

    public void ReloadJsonData()
    {
        _playerData = new PlayerData
        {
            Name = "小明",
            Power = 100,
            HP = 200,
            Attack = 10,
            Defence = 8,
            Speed = 10,
            Coin = 1000
        };
        YJsonUtility.Save(_playerData,Paths.PlayerData);
    }

    public void UpdateLocalPlayerData()
    {
        YJsonUtility.Save(_playerData,Paths.PlayerData);
    }
    
    
}