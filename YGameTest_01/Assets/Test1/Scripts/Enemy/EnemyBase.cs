/****************************************************
    文件：EnemyBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.Pool;
using YFramework;
using YFramework.UI;

[Serializable]
public class EnemyData
{
    public EnemyBase.Names Name;
    public int HP;
    public int Attack;
    public int Defence;
    public int Speed;

    public int CostPower;

    public Award awrd;
    
    //奖励
    [Serializable]
    public class Award
    {
        public int Coin;
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
    private PlayerData _playerData;
    // todo level
    //protected RareLevel level;
    private ObjectPool<GameObject> _enemyPool;

    public void InitOnce()
    {
        initData = data;
        InitData();
        _playerData = GameManager.Instance.PlayerData;
        UiUtility.Get("Btn").AddListener(()=>
        {
            if (!Player.EnableAttack())
            {
                Debug.Log("玩家已经死亡或者体力不足");
                return;
            }
              
            Player.ChangePower(-data.CostPower,false);
            AttackPlayer();
            Debug.Log("战斗结果:" + AttackResult());
            //todo 以后正式时候打开更新本地数据
            //GameManager.Instance.UpdateLocalPlayerData();
           
            //死亡奖励
            if (AttackResult())
            {
                Player.ChangeCoin(data.awrd.Coin,false);
                MsgDispatcher.Send(RegisterMsg.UpdateShowData,null);
            }
            EnemyFactory.Release(data.Name.ToString(),gameObject);
        });
    }

    private void AttackPlayer()
    {
        while (data.HP > 0 && _playerData.HP > 0)
        {
            //玩家先手
            if (_playerData.Speed >= data.Speed)
            {
                ChangeHP(ref data.HP,_playerData.Defence,false);
                Player.ChangeHPAttack(data.Attack,false);
            }
            else
            {
                Player.ChangeHPAttack(data.Attack,false);
                ChangeHP(ref data.HP,_playerData.Defence,false);
            }
        }
    }
    private bool AttackResult()
    {
        if (data.HP <= 0)
            return true;
        return false;
    }

    public abstract void InitData();

    protected void ChangeHP(ref int hpSelf,int defenceSelf,bool isDebug = true)
    {
        var attackValue = AttackMath.AttackValue(GameManager.Instance.PlayerData.Attack,defenceSelf,isDebug);
        hpSelf -= attackValue;
        if(isDebug)
            Debug.Log("cur enemyHP:"+ hpSelf);
    }
}