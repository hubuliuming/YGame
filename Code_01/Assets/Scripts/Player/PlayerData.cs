/****************************************************
    文件：PlayerData.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;

namespace Code_01.Mode
{
    internal class PlayerData  
    {
        public string Name;
        public int Level;
        public long Exp;
        public int Power;
        public int Hp;
        public int Attack;
        public int Defence;
        public int Speed;

        public int UpperPower;
        public int UpperHp;
        public int UpperAttack;
        public int UpperDefence;
        public int UpperSpeed;
 
        public int Coin;

        /// <summary>
        /// 物品名字 key is 物品名字，value 是数量
        /// </summary>
        public Dictionary<string, int> goodsDict;
        //允许降低上限数值的最小值
        public const int LimitMinPower = 50;
        public const int LimitMinHP = 100;
        public const int LimitMinAttack = 5;
        public const int LimitMinDefence = 4;
        public const int LimitMinSpeed = 5;

        public const int MaxLevel = 100;
    
    
    }
}