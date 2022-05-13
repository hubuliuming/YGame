/****************************************************
    文件：AttackMath.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class AttackMath
{
    public static int AttackValue(int attackValue,int targetDefence,bool isDebug = true)
    {
        var value = attackValue - targetDefence;
        if (value <= 0)
            value = 1;
        if(isDebug)
            Debug.Log("造成的伤害为：" + value);
        return value;
    }

    /// <summary>
    /// 敌人和玩家战斗
    /// </summary>
    /// <returns>true 为玩家胜利，false为敌人胜利</returns>
    // public static bool EnemyAndPlayerAttack(ref EnemyData enemyData, ref PlayerData playerData)
    // {
    //     //玩家先手
    //     while (enemyData.HP > 0 && playerData.HP >0)
    //     {
    //         if (playerData.Speed >= enemyData.Speed)
    //         {
    //             enemyData.HP -= AttackValue(playerData.Attack, enemyData.Defence);
    //             Player.ChangeHP(-AttackValue(enemyData.Attack, playerData.Defence));
    //         }
    //         else
    //         {
    //             Player.ChangeHP(-AttackValue(enemyData.Attack, playerData.Defence));
    //             enemyData.HP -= AttackValue(playerData.Attack, enemyData.Defence);
    //         }
    //         Debug.Log("enemyHP:"+enemyData.HP);
    //     }
    //
    //     if (enemyData.HP <= 0)
    //         return true;
    //     else if(playerData.HP <=0)
    //         return false;
    //     return true;
    // }
}