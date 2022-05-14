/****************************************************
    文件：EnemyBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.Pool;
using YFramework;
using YFramework.UI;

public class EnemyData
{
    public string Name;
    public int HP;
    public int Attack;
    public int Defence;
    public int Speed;

    public int NeedPower;

    public Award awrd;
    
    //奖励
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
    protected EnemyData data;
    private PlayerData _playerData;
    public RareLevel level;
    private ObjectPool<GameObject> _enemyPool;

    public override void Init()
    {
        InitData();
        _playerData = GameManager.Instance.PlayerData;
        UiUtility.Get("Btn").AddListener(()=>
        {
            if(!Player.EnableAttack())
                return;
            Player.ChangePower(data.NeedPower,false);
            AttackPlayer();
            Debug.Log("战斗结果:" + AttackResult());
            //todo 以后正式时候打开更新本地数据
            //GameManager.Instance.UpdateLocalPlayerData();
           
            //死亡奖励
            if (AttackResult())
            {
                Player.ChangeCoin(data.awrd.Coin);
                MsgDispatcher.Send(RegisterMsg.UpdateShowData,null);
            }
            
            EnemyFactory.Release(data.Name,gameObject);
        });
    }

   
    public void AttackPlayer()
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