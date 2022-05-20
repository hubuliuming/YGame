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
    // private PlayerData _playerData;
    // public PlayerData PlayerData => _playerData;

    public Player player;
    
    private void OnDestroy()
    {
        MsgDispatcher.UnRegisterAll();
    }

    

   
  

    
    
    
}