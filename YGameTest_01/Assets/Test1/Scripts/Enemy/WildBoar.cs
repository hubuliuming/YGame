/****************************************************
    文件：WildBoar.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：野猪
*****************************************************/

using UnityEngine;
using YFramework;
using YFramework.UI;

public class WildBoar : EnemyBase
{
    private EnmeyData _data = new EnmeyData()
    {
        HP = 100,
        Attack = 5,
        Defence = 2,
        awrd = new EnmeyData.Award()
        {
            Coin = 3
        }  
    };
    private void Start()
    {
        UiUtility.Get("Btn").AddListener(()=>
        {
            //todo 战斗计算
            //玩家先手
            if (AttackMath.AttackOrder(_data.Attack))
            {
                
            }
            else
            {
                
            }
          
            ChangeHP(ref _data.HP,_data.Defence);
            //PlayerUtility.ChangeHP(-AttackMath.AttackValue(_data.Attack));
        });
    }
}