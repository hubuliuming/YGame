/****************************************************
    文件：GameManager.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Diagnostics;
using YFramework;
using Debug = UnityEngine.Debug;

public class GameManager : MonoSingleton<GameManager>
{
    private Stopwatch t = new Stopwatch();
    private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;

    private void Start()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        //ReloadJsonData();
        _playerData = YJsonUtility.Load<PlayerData>(Paths.PlayerData);
    }

    private void ReloadJsonData()
    {
        _playerData = new PlayerData();
        _playerData.Power = 100;
        _playerData.HP = 200;
        _playerData.Attack = 10;
        _playerData.Defence = 8;
        _playerData.Speed = 10;
        _playerData.Coin = 1000;
        YJsonUtility.Save(_playerData,Paths.PlayerData);
    }

    public void UpdateLocalPlayerData()
    {
        t.Start();
        YJsonUtility.Save(_playerData,Paths.PlayerData);
        t.Stop();
        Debug.Log("花费的时间为：" +t.ElapsedMilliseconds);
    }
    
    public void ChangePower(int value)
    {
        _playerData.Power += value;
        Debug.Log("PlayerPower:"+_playerData.Power);
    }
    public void ChangeHP(int value)
    {
        _playerData.HP += value;
        Debug.Log("PlayerHP:"+_playerData.HP);
    }
    public void ChangeAttack(int value)
    {
        _playerData.Attack += value;
        Debug.Log("PlayerAttack:"+_playerData.Attack);
    }
    
    public void ChangeDefence(int value)
    {
        _playerData.Defence += value;
        Debug.Log("PlayerDefence:"+_playerData.Defence);
    }
    public void ChangeSpeed(int value)
    {
        _playerData.Speed += value;
        Debug.Log("PlayerSpeed:"+_playerData.Speed);
    }
    public void ChangeCoin(int value)
    {
        _playerData.Coin += value;
        Debug.Log("PlayerCoin:"+_playerData.Coin);
    }
    
}