/****************************************************
    文件：EnemyModel.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using YFramework;

public class EnemyModel : AbstractModel 
{
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
    protected override void OnInit()
    {
        
    }
}