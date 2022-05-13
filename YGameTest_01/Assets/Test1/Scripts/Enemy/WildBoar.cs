/****************************************************
    文件：WildBoar.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：野猪
*****************************************************/

using UnityEngine;

public class WildBoar : EnemyBase
{
    protected override void InitEnemyData()
    {
        data = new EnemyData()
        {
            HP = 100,
            Attack = 5,
            Defence = 2,
            Speed = 5,
            awrd = new EnemyData.Award()
            {
                Coin = 3
            }
        };
    }
    private void Start()
    {
       Init();
    }

}