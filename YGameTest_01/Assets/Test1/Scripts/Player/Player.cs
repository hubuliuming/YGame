/****************************************************
    文件：Player.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class Player
{
    private static PlayerData _playerData = GameManager.Instance.PlayerData;
    
    public static void ChangePower(int value,bool isDebug = true)
    {
        _playerData.Power += value;
        if(isDebug)
            Debug.Log("PlayerPower:"+_playerData.Power);
    }
    public static void ChangeHP(int value,bool isDebug = true)
    {
        _playerData.HP += value;
        if(isDebug)
            Debug.Log("PlayerHP:"+_playerData.HP);
    }
    public static void ChangeHPAttack(int attack,bool isDebug = true)
    {
        var value = AttackMath.AttackValue(attack, _playerData.Defence,isDebug);
        ChangeHP(-value,isDebug);
    }
    
    public static void ChangeAttack(int value,bool isDebug = true)
    {
        _playerData.Attack += value;
        if(isDebug)
            Debug.Log("PlayerAttack:"+_playerData.Attack);
    }
    public static void ChangeDefence(int value,bool isDebug = true)
    {
        _playerData.Defence += value;
        if(isDebug)
            Debug.Log("PlayerDefence:"+_playerData.Defence);
    }
    public static void ChangeSpeed(int value,bool isDebug = true)
    {
        _playerData.Speed += value;
        if(isDebug)
            Debug.Log("PlayerSpeed:"+_playerData.Speed);
    }
    public static void ChangeCoin(int value,bool isDebug = true)
    {
        _playerData.Coin += value;
        if(isDebug)
            Debug.Log("PlayerCoin:"+_playerData.Coin);
    }

}