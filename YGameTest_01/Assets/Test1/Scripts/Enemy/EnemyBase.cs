/****************************************************
    文件：EnemyBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using YFramework;
using YFramework.UI;
using Random = UnityEngine.Random;

[Serializable]
public struct EnemyData
{
    public EnemyBase.Names Name;
    public int HP;
    public int Attack;
    public int Defence;
    public int Speed;

    public int CostPower;

    //奖励
    public struct Award
    {
        public int Exp;
        public int Coin;
        public Dictionary<string, int> goodsDict;
    }
  
}


public enum RareLevel
{
    White,
    Green,
    Blue,
    Red,
    Gold
}

public abstract class EnemyBase : UIBase,IEnemy
{
    public enum Names
    {
        WildBoar,
    }
    
    public EnemyData data;
    protected EnemyData initData;
    //private PlayerData _playerData;
    // todo level
    //protected RareLevel level;
    private ObjectPool<GameObject> _enemyPool;

    private Player _player;

    public void InitOnce()
    {
        _player = GameManager.Instance.player;
        initData = data;
        InitData();
        UiUtility.Get("Btn").AddListener(()=>
        {
            if (!_player.EnableAttack())
            {
                Debug.Log("玩家已经死亡或者体力不足");
                return;
            }
              
            _player.ChangePower(-data.CostPower,false);
            AttackPlayer();
            Debug.Log("战斗结果:" + AttackResult());
            //死亡奖励
            if (AttackResult())
            {
                //Player.ChangeCoin(data.awrd.Coin,false);
                WinAward(data.Name);
                MsgDispatcher.Send(RegisterMsg.UpdateShowData,null);
            }
            //Player.UpdateLocalPlayerData();
            EnemyFactory.Release(data.Name.ToString(),gameObject);
        });
    }

    public abstract void InitData();

    private void WinAward(Names names)
    {
        Dictionary<string, int> goodsDic;
        switch (names)
        {
            case Names.WildBoar:
                _player.ChangeExp(EnemyAwardConfigs.WildBoar.Exp);
                _player.ChangeCoin(EnemyAwardConfigs.WildBoar.Coin);
                goodsDic = GetRangeGoods(EnemyAwardConfigs.WildBoar.GoodsName,EnemyAwardConfigs.WildBoar.MinGoodsNum,EnemyAwardConfigs.WildBoar.MaxGoodsNum);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(names), names, null);
        }
        foreach (var i in goodsDic)
        {
            _player.ChangeGoodsDic(i.Key,i.Value);
            Debug.Log("战利品为经验值:"+EnemyAwardConfigs.WildBoar.Exp+",金币:"
                      +EnemyAwardConfigs.WildBoar.Coin+",物品为:"+i.Value+"个"+i.Key);
        }
    }


    private void AttackPlayer()
    {
        int playerHP = _player.HP;
        while (data.HP > 0 && playerHP > 0)
        {
            //玩家先手
            if (_player.Speed >= data.Speed)
            {
                data.HP -= AttackMath.AttackValue(_player.Attack, data.Defence); 
                playerHP -= AttackMath.AttackValue(data.Attack, _player.Defence);
            }
            else
            {
                playerHP -= AttackMath.AttackValue(data.Attack, _player.Defence);
                data.HP -= AttackMath.AttackValue(_player.Attack, data.Defence);
            }
        }
        //当前的HP - 计算战斗后剩余的playerHP，得到改变的HP
        _player.ChangeHP(-(_player.HP - playerHP));
    }

    private bool AttackResult()
    {
        if (data.HP <= 0)
            return true;
        return false;
    }

    private void ChangeHP(ref int hpSelf,int defenceSelf,bool isDebug = true)
    {
        var attackValue = AttackMath.AttackValue(_player.Attack,defenceSelf,isDebug);
        hpSelf -= attackValue;
        if(isDebug)
            Debug.Log("cur enemyHP:"+ hpSelf);
    }

   
    private Dictionary<string,int> GetRangeGoods(string goodsName,int min,int max)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        var num = Random.Range(min, max);
        dic.Add(goodsName,num);
        return dic;
    }
}