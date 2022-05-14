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
    
    public static bool IsDied { get; private set; }
    public static bool IsEmptyPower { get; private set; }

    public static void ChangeName(string nameStr)
    {
        _playerData.Name = nameStr;
    }
    public static void ChangePower(int value,bool isDebug = true)
    {
        if (_playerData.Power + value < 0)
        {
            //todo 体力不够
            IsEmptyPower = true;
            Debug.Log("体力不足！");
            return;
        }
        _playerData.Power += value;
        IsEmptyPower = false;
        if(isDebug)
            Debug.Log("PlayerPower:"+_playerData.Power);
    }
    public static void ChangeHP(int value,bool isDebug = true)
    {
        if (_playerData.HP <=0 ||_playerData.HP + value <= 0)
        {
            //todo 玩家死亡
            IsDied = true;
            Debug.Log("玩家死亡！");
            return;
        }

        IsDied = false;
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

    public static bool EnableAttack()
    {
        if (!IsDied || !IsEmptyPower)
            return true;
        return false;
    }

}