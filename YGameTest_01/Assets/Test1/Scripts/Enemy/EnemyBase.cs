/****************************************************
    文件：EnemyBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using YFramework.UI;

public class EnmeyData
{
    public int HP;
    public int Attack;
    public int Defence;
    public int Speed;

    public Award awrd;
    
    //奖励
    public class Award
    {
        public int Coin;
    }
}

public abstract class EnemyBase : UIBase
{
    protected void ChangeHP(ref int hpSelf,int defenceSelf)
    {
        var attackValue = AttackMath.AttackValue(GameManager.Instance.PlayerData.Attack,defenceSelf);
        hpSelf -= attackValue;
        Debug.Log("cur enemyHP:"+ hpSelf);
    }
}