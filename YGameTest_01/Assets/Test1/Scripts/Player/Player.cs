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

    // private static int Power
    // {
    //     get => _playerData.Value.Power;
    //     set
    //     {
    //         if (value < 0)
    //         {
    //             IsEmptyPower = true;
    //             _playerData.Value.UpperPower = 0;
    //             Debug.Log("体力不足!");
    //         }
    //         else if (value > _playerData.Value.UpperPower)
    //         {
    //             _playerData.Value.Power = _playerData.Value.UpperPower;
    //         }
    //         else
    //         {
    //             _playerData.Value.Power = value;
    //         }
    //     }
    // }
    
    public static void ChangeName(string nameStr)
    {
        _playerData.Value.Name = nameStr;
    }

    public static void ChangePower(int value,bool isDebug = true)
    {
        //Power += value;
        if(value == 0)
            return;
        if (_playerData.Value.Power + value < 0)
        {
            //todo 体力不够
            IsEmptyPower = true;
            _playerData.Value.Power = 0;
            Debug.Log("体力不足!");
            return;
        }
        //恢复的体力不可以超过体力上限
        else if (_playerData.Value.Power + value >= _playerData.Value.UpperPower)
        {
            _playerData.Value.Power = _playerData.Value.UpperPower;
        }
        else
        {
            _playerData.Value.Power += value;
        }
        IsEmptyPower = false;
        if(isDebug)
            Debug.Log("PlayerPower:"+_playerData.Value.Power);
    }
    public static void ChangeUpperPower(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.UpperPower + value < PlayerData.LimitMinPower)
        {
            _playerData.Value.UpperPower = PlayerData.LimitMinPower;
            Debug.Log("已经到达最低体力上限值");
            return;
        }

        _playerData.Value.UpperPower += value;
        if(isDebug)
            Debug.Log("当前体力上限值为:"+_playerData.Value.UpperPower);
    }
    public static void ChangeHP(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if(CheckChangeDied(value))
            return;
        //恢复的血量不可以超过血量上限
        if (_playerData.Value.HP + value >= _playerData.Value.UpperHP)
        {
            _playerData.Value.HP = _playerData.Value.UpperHP;
        }
        else
        {
            _playerData.Value.HP += value;
        }

        IsDied = false;
        if(isDebug)
            Debug.Log("PlayerHP:"+_playerData.Value.HP);
    }
  
    public static void ChangeHPAttack(int attack,bool isDebug = true)
    {
        var value = AttackMath.AttackValue(attack, _playerData.Value.Defence,isDebug);
        ChangeHP(-value,isDebug);
    }
    public static void ChangeUpperHP(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.UpperHP + value < PlayerData.LimitMinHP)
        {
            _playerData.Value.UpperHP = PlayerData.LimitMinHP;
            Debug.Log("已经到达最低生命上限值");
            return;
        }

        _playerData.Value.UpperHP += value;
        if(isDebug)
            Debug.Log("当前生命上限值为:"+_playerData.Value.UpperHP);
    }
    public static void ChangeAttack(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.Attack + value < PlayerData.LimitMinAttack)
        {
            _playerData.Value.Attack = PlayerData.LimitMinAttack;
        }
        else if (_playerData.Value.Attack + value > _playerData.Value.UpperAttack)
        {
            _playerData.Value.Attack = _playerData.Value.UpperAttack;
        }
        else
        {
            _playerData.Value.Attack += value;
        }
        if(isDebug)
            Debug.Log("PlayerAttack:"+_playerData.Value.Attack);
    }
    public static void ChangeUpperAttack(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.UpperAttack + value < PlayerData.LimitMinAttack)
        {
            _playerData.Value.UpperAttack = PlayerData.LimitMinAttack;
        }
        else
        {
            _playerData.Value.UpperAttack += value;
        }
        if(isDebug)
            Debug.Log("PlayerUpperAttack:"+_playerData.Value.UpperAttack);
    }
    public static void ChangeDefence(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.Defence + value < PlayerData.LimitMinDefence)
        {
            _playerData.Value.Defence = PlayerData.LimitMinDefence;
        }
        else if (_playerData.Value.Defence + value > _playerData.Value.Defence)
        {
            _playerData.Value.Defence = _playerData.Value.UpperDefence;
        }
        else
        {
            _playerData.Value.Defence += value;
        }
        if(isDebug)
            Debug.Log("PlayerDefence:"+_playerData.Value.Defence);
    }
    public static void ChangeUpperDefence(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.UpperDefence + value < PlayerData.LimitMinDefence)
        {
            _playerData.Value.UpperDefence = PlayerData.LimitMinDefence;
        }
        else
        {
            _playerData.Value.UpperDefence += value;
        }
        if(isDebug)
            Debug.Log("PlayerUpperDefence:"+_playerData.Value.UpperDefence);
    }
    public static void ChangeSpeed(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.Speed + value < PlayerData.LimitMinSpeed)
        {
            _playerData.Value.Speed = PlayerData.LimitMinSpeed;
        }
        else if (_playerData.Value.Speed + value > _playerData.Value.UpperSpeed)
        {
            _playerData.Value.Speed = _playerData.Value.UpperSpeed;
        }
        else
        {
            _playerData.Value.Speed += value;
        }
        if(isDebug)
            Debug.Log("PlayerSpeed:"+_playerData.Value.Speed);
    }
    public static void ChangeUpperSpeed(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.UpperSpeed + value < PlayerData.LimitMinSpeed)
        {
            _playerData.Value.UpperSpeed = PlayerData.LimitMinSpeed;
        }
        else
        {
            _playerData.Value.UpperSpeed += value;
        }
        if(isDebug)
            Debug.Log("PlayerUpperSpeed:"+_playerData.Value.UpperSpeed);
    }
    public static void ChangeCoin(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Value.Coin + value < 0)
            _playerData.Value.Coin = 0;
        else
            _playerData.Value.Coin += value;
        if(isDebug)
            Debug.Log("PlayerCoin:"+_playerData.Value.Coin);
    }

    public static void ChangeAll(ItemData data,bool isDebug = true)
    {
        ChangePower(data.addPower,isDebug);
        ChangeHP(data.addHp,isDebug);
        ChangeAttack(data.addAttack,isDebug);
        ChangeDefence(data.addDefence,isDebug);
        ChangeSpeed(data.addSpeed,isDebug);
        ChangeCoin(data.addCoin,isDebug);
    }

    public static bool EnableAttack()
    {
        if (!IsDied && !IsEmptyPower)
            return true;
        return false;
    }
    
    
    
    private static bool CheckChangeDied(int value)
    {
        if (_playerData.Value.HP <=0 ||_playerData.Value.HP + value <= 0)
        {
            //todo 玩家死亡
            IsDied = true;
            Debug.Log("玩家死亡！");
            _playerData.Value.HP = 0;
            return true;
        }

        return false;
    }   

}