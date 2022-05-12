/****************************************************
    文件：AttackMath.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class AttackMath
{
    private static Lazy<PlayerData> _playerData = new Lazy<PlayerData>(GameManager.Instance.PlayerData);

    public static bool AttackOrder(int speedSelf)
    {
        if (_playerData.Value.Speed >= speedSelf)
            return true;
        return false;
    }
    public static int AttackValue(int attackValue,int targetDefence)
    {
        var value = attackValue - targetDefence;
        if (value <= 0)
            value = 1;
        Debug.Log("造成的伤害为：" + value);
        return value;
    }
}