/****************************************************
    文件：AttackMath.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class AttackMath
{
    public static int AttackValue(int attackValue,int targetDefence,bool isDebug = false)
    {
        var value = attackValue - targetDefence;
        if (value <= 0)
            value = 1;
        if(isDebug)
            Debug.Log("造成的伤害为：" + value);
        return value;
    }

    public static void Attack(Player player, EnemyData enemy)
    {
        // int playerHP = player.HP;
        // while (playerHP > 0 && enemy.HP > 0)
        // {
        //     //player先手
        //     if (player.Speed >= enemy.Speed)
        //     {
        //         enemy.HP -= AttackValue(player.Attack, enemy.Defence);
        //         playerHP -= AttackValue(enemy.Attack, player.Defence);
        //     }
        //     else
        //     {
        //         playerHP -= AttackValue(enemy.Attack, player.Defence);
        //         enemy.HP -= AttackValue(player.Attack, enemy.Defence);
        //     }
        // }
        // //暂定返回两者剩余血量的字典，后面有加功能可以返回一个类
        // Dictionary<int, int> dic = new Dictionary<int, int>();
        // dic.Add(playerHP,enemy.HP);
        
    }
}