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
    public static int AttackValue(int attackValue,int targetDefence,bool isDebug = false)
    {
        var value = attackValue - targetDefence;
        if (value <= 0)
            value = 1;
        if(isDebug)
            Debug.Log("造成的伤害为：" + value);
        return value;
    }
}