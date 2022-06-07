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

public abstract class EnemyBase : UIBase
{
    public enum RareLevel
    {
        White,
        Green,
        Blue,
        Red,
        Gold
    }
    
    [Serializable]
    public struct EnemyData
    {
        public int HP;
        public int Attack;
        public int Defence;
        public int Speed;

        public int CostPower;
        public Award award;

        //奖励
        [Serializable]
        public struct Award
        {
            public int Exp;
            public int Coin;
            public string GoodsName;
        }
  
    }

    public EnemyData data;
    protected EnemyData initData;
    // todo level
    //protected RareLevel level;
    private ObjectPool<GameObject> _enemyPool;

    private Player _player;

    public void Init(string enemyName)
    {
        _player = GameManager.Instance.player;
        var datas = YJsonUtility.ReadFromJson<Dictionary<string, EnemyData>>(Paths.Config.Enemy);
        foreach (var key in datas.Keys)
        {
            if (key == enemyName)
            {
                data = datas[enemyName];
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
                        WinAward();
                    }
                    EnemyFactory.Release(enemyName,gameObject);
                    MsgDispatcher.Send(MsgRegister.UpdateShowData);
                });
                break;
            }
        }
    }

    public void InitData()
    {
        data = initData;
    }

    private void WinAward()
    {
        Dictionary<string, int> goodsDic= new Dictionary<string, int>();
        _player.ChangeExp(data.award.Exp);
        _player.ChangeCoin(data.award.Coin);
        //todo 数值要优化为配置
        goodsDic = DropSystem.GetRangeGoods(data.award.GoodsName,1,3);
        foreach (var i in goodsDic)
        {
            _player.ChangeGoodsDic(i.Key,i.Value);
            Debug.Log("战利品为经验值:"+data.award.Exp+",金币:"+data.award.Coin+",物品为:"+i.Value+"个"+i.Key);
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

    // private Dictionary<string,int> GetRangeGoods(string goodsName,int min,int max)
    // {
    //     Dictionary<string, int> dic = new Dictionary<string, int>();
    //     var num = Random.Range(min, max);
    //     dic.Add(goodsName,num);
    //     return dic;
    // }
}