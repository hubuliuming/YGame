/****************************************************
    文件：Player.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using System.Collections.Generic;
using YFramework.Kit.Utility;

public class Player
{
    private  PlayerData _playerData;
    public Player()
    {
        InitPlayer();
    }
    public Player(PlayerData playerData)
    {
        this._playerData = playerData;
    }

    public bool IsDied { get; private set; }
    public bool IsEmptyPower { get; private set; }

    public string Name => _playerData.Name;
    public int Level => _playerData.Level;
    public long Exp => _playerData.Exp;
    public int Power => _playerData.Power;
    public int HP => _playerData.HP;
    public int Attack => _playerData.Attack;
    public int Defence => _playerData.Defence;
    public int Speed => _playerData.Speed;
    public int Coin => _playerData.Coin;
    
    public int UpperPower => _playerData.UpperPower;
    public int UpperHP => _playerData.UpperHP;
    public int UpperAttack => _playerData.UpperAttack;
    public int UpperDefence => _playerData.UpperDefence;
    public int UpperSpeed => _playerData.UpperSpeed;

    public Dictionary<string, int> GoodsDic => _playerData.goodsDict;
    

    
    public void InitPlayer()
    {
        _playerData = YJsonUtility.ReadFromJson<PlayerData>(Msg.Paths.Config.PlayerData);
    }

    private void UpdateLocalPlayerData()
    {
        YJsonUtility.WriteToJson(_playerData,Msg.Paths.Config.PlayerData);
    }
    
    #region ChangePlayerData
    public void ChangeName(string nameStr)
    {
        _playerData.Name = nameStr;
        // MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        UpdateLocalPlayerData();
    }

    public void LevelUp()
    {
        var needExp = _playerData.Level * 100 + 100;
        if (_playerData.Exp >= needExp)
        {
            _playerData.Level++;
            ChangeExp(-needExp);
        }
        else
        {
            Debug.Log("经验不足升级");
        }
    }
    
    public void ChangeExp(long value, bool isDebug = true)
    {
        _playerData.Exp += value;
        if(isDebug)
            Debug.Log("经验值:"+Exp);
        // MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        UpdateLocalPlayerData();
    }
    public void ChangePower(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Power + value < 0)
        {
            //todo 体力不够
            IsEmptyPower = true;
            _playerData.Power = 0;
            Debug.Log("体力不足!");
            return;
        }
        //恢复的体力不可以超过体力上限
        else if (_playerData.Power + value >= _playerData.UpperPower)
        {
            _playerData.Power = _playerData.UpperPower;
        }
        else
        {
            _playerData.Power += value;
        }
        IsEmptyPower = false;
        if(isDebug)
            Debug.Log("PlayerPower:"+_playerData.Power);
        // MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        UpdateLocalPlayerData();
    }
    public void ChangeUpperPower(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.UpperPower + value < PlayerData.LimitMinPower)
        {
            _playerData.UpperPower = PlayerData.LimitMinPower;
            Debug.Log("已经到达最低体力上限值");
            return;
        }

        _playerData.UpperPower += value;
        if(isDebug)
            Debug.Log("当前体力上限值为:"+_playerData.UpperPower);
        UpdateLocalPlayerData();
    }
    public void ChangeHP(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if(CheckChangeDied(value))
            return;
        //恢复的血量不可以超过血量上限
        if (_playerData.HP + value >= _playerData.UpperHP)
        {
            _playerData.HP = _playerData.UpperHP;
        }
        else
        {
            _playerData.HP += value;
        }

        IsDied = false;
        if(isDebug)
            Debug.Log("PlayerHP:"+_playerData.HP);
        // MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        UpdateLocalPlayerData();
    }
    public void ChangeUpperHP(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.UpperHP + value < PlayerData.LimitMinHP)
        {
            _playerData.UpperHP = PlayerData.LimitMinHP;
            Debug.Log("已经到达最低生命上限值");
            return;
        }

        _playerData.UpperHP += value;
        if(isDebug)
            Debug.Log("当前生命上限值为:"+_playerData.UpperHP);
        UpdateLocalPlayerData();
    }
    public void ChangeAttack(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Attack + value < PlayerData.LimitMinAttack)
        {
            _playerData.Attack = PlayerData.LimitMinAttack;
        }
        else if (_playerData.Attack + value > _playerData.UpperAttack)
        {
            _playerData.Attack = _playerData.UpperAttack;
        }
        else
        {
            _playerData.Attack += value;
        }
        if(isDebug)
            Debug.Log("PlayerAttack:"+_playerData.Attack);
        // MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        UpdateLocalPlayerData();
    }
    public void ChangeUpperAttack(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.UpperAttack + value < PlayerData.LimitMinAttack)
        {
            _playerData.UpperAttack = PlayerData.LimitMinAttack;
        }
        else
        {
            _playerData.UpperAttack += value;
        }
        if(isDebug)
            Debug.Log("PlayerUpperAttack:"+_playerData.UpperAttack);
        UpdateLocalPlayerData();
    }
    public void ChangeDefence(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Defence + value < PlayerData.LimitMinDefence)
        {
            _playerData.Defence = PlayerData.LimitMinDefence;
        }
        else if (_playerData.Defence + value > _playerData.Defence)
        {
            _playerData.Defence = _playerData.UpperDefence;
        }
        else
        {
            _playerData.Defence += value;
        }
        if(isDebug)
            Debug.Log("PlayerDefence:"+_playerData.Defence);
        // MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        UpdateLocalPlayerData();
    }
    public void ChangeUpperDefence(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.UpperDefence + value < PlayerData.LimitMinDefence)
        {
            _playerData.UpperDefence = PlayerData.LimitMinDefence;
        }
        else
        {
            _playerData.UpperDefence += value;
        }
        if(isDebug)
            Debug.Log("PlayerUpperDefence:"+_playerData.UpperDefence);
        UpdateLocalPlayerData();
    }
    public void ChangeSpeed(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Speed + value < PlayerData.LimitMinSpeed)
        {
            _playerData.Speed = PlayerData.LimitMinSpeed;
        }
        else if (_playerData.Speed + value > _playerData.UpperSpeed)
        {
            _playerData.Speed = _playerData.UpperSpeed;
        }
        else
        {
            _playerData.Speed += value;
        }
        if(isDebug)
            Debug.Log("PlayerSpeed:"+_playerData.Speed);
        // MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        UpdateLocalPlayerData();
    }
    public void ChangeUpperSpeed(int value, bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.UpperSpeed + value < PlayerData.LimitMinSpeed)
        {
            _playerData.UpperSpeed = PlayerData.LimitMinSpeed;
        }
        else
        {
            _playerData.UpperSpeed += value;
        }
        if(isDebug)
            Debug.Log("PlayerUpperSpeed:"+_playerData.UpperSpeed);
        UpdateLocalPlayerData();
    }
    public void ChangeCoin(int value,bool isDebug = true)
    {
        if(value == 0)
            return;
        if (_playerData.Coin + value < 0)
            _playerData.Coin = 0;
        else
            _playerData.Coin += value;
        if(isDebug)
            Debug.Log("PlayerCoin:"+_playerData.Coin);
        // MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        UpdateLocalPlayerData();
    }
    
    public void ChangeAll(ItemBase.ItemData data,bool isDebug = true)
    {
        ChangePower(data.addPower,isDebug);
        ChangeHP(data.addHp,isDebug);
        ChangeAttack(data.addAttack,isDebug);
        ChangeDefence(data.addDefence,isDebug);
        ChangeSpeed(data.addSpeed,isDebug);
        ChangeCoin(data.addCoin,isDebug);
    }

    public bool EnableAttack()
    {
        if (!IsDied && !IsEmptyPower)
            return true;
        return false;
    }
    
    private bool CheckChangeDied(int value)
    {
        if (_playerData.HP <=0 ||_playerData.HP + value <= 0)
        {
            //todo 玩家死亡
            IsDied = true;
            Debug.Log("玩家死亡！");
            _playerData.HP = 0;
            return true;
        }

        return false;
    }   

    #endregion

    #region ChangeGoodsDic
    public void ChangeGoodsDic(string goodsName,int num)
    {
        if (_playerData.goodsDict.ContainsKey(goodsName))
        {
            _playerData.goodsDict[goodsName] += num;
        }
        else
        {
            //todo bug 可能为负数取出没有的物品
            _playerData.goodsDict.Add(goodsName,num);
        }
        UpdateLocalPlayerData();
    }
    #endregion
}