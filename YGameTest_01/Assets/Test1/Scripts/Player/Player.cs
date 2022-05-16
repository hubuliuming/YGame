/****************************************************
    文件：Player.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using System;

public class Player
{
    private static Lazy<PlayerData> _playerData = new Lazy<PlayerData>(GameManager.Instance.PlayerData);
    public static bool IsDied { get; private set; }
    public static bool IsEmptyPower { get; private set; }
    public static void ChangeName(string nameStr)
    {
        _playerData.Value.Name = nameStr;
    }
    public static void ChangePower(int value,bool isDebug = true)
    {
        if (_playerData.Value.Power + value < 0)
        {
            //todo 体力不够
            IsEmptyPower = true;
            Debug.Log("体力不足！");
            return;
        }
        _playerData.Value.Power += value;
        IsEmptyPower = false;
        if(isDebug)
            Debug.Log("PlayerPower:"+_playerData.Value.Power);
    }
    public static void ChangeHP(int value,bool isDebug = true)
    {
        if (_playerData.Value.HP <=0 ||_playerData.Value.HP + value <= 0)
        {
            //todo 玩家死亡
            IsDied = true;
            Debug.Log("玩家死亡！");
            _playerData.Value.HP = 0;
            return;
        }

        IsDied = false;
        _playerData.Value.HP += value;
        if(isDebug)
            Debug.Log("PlayerHP:"+_playerData.Value.HP);
    }
    public static void ChangeHPAttack(int attack,bool isDebug = true)
    {
        var value = AttackMath.AttackValue(attack, _playerData.Value.Defence,isDebug);
        ChangeHP(-value,isDebug);
    }
    public static void ChangeAttack(int value,bool isDebug = true)
    {
        _playerData.Value.Attack += value;
        if(isDebug)
            Debug.Log("PlayerAttack:"+_playerData.Value.Attack);
    }
    public static void ChangeDefence(int value,bool isDebug = true)
    {
        _playerData.Value.Defence += value;
        if(isDebug)
            Debug.Log("PlayerDefence:"+_playerData.Value.Defence);
    }
    public static void ChangeSpeed(int value,bool isDebug = true)
    {
        _playerData.Value.Speed += value;
        if(isDebug)
            Debug.Log("PlayerSpeed:"+_playerData.Value.Speed);
    }
    public static void ChangeCoin(int value,bool isDebug = true)
    {
        _playerData.Value.Coin += value;
        if(isDebug)
            Debug.Log("PlayerCoin:"+_playerData.Value.Coin);
    }

    public static bool EnableAttack()
    {
        if (!IsDied && !IsEmptyPower)
            return true;
        return false;
    }

}