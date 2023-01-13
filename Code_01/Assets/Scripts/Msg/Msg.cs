/****************************************************
    文件：Msg.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

namespace Code_01
{
    public class Msg 
    {
        public struct EnemyName
        {
            public static readonly string 野猪 = "野猪";
        }
        public struct ItemName
        {
            public static readonly string 活力苹果 = "活力苹果";
            public static readonly string 馒头 = "馒头";
            public static readonly string 小块肉 = "小块肉";
            public static readonly string Goods = "Goods";
        }
        public struct Register
        {
            public struct UpdateShowData
            {
            
            }
            public const string PlayerAttack = "PlayerAttack";
            public const string UseGoods = "UseGoods";
        }
    
        public class Paths
        {
            public struct Config
            {
                public static readonly string PlayerData = Application.dataPath + "/Data/Player";
                public static readonly string RecoverItem = Application.streamingAssetsPath + "/Data/RecoverItem";
                public static readonly string Enemy = Application.streamingAssetsPath + "/Data/Enemy";
            }
        

        }
        public struct Prefab
        {
            public static readonly string 野猪 = "Prefabs/Enemy/"+ EnemyName.野猪;
            public static readonly string 活力苹果 = "Prefabs/Item/"+ItemName.活力苹果;
            public static readonly string Enemy = "Prefabs/Enemy";
            public static readonly string Goods = "Prefabs/Goods";
        }
    
    }
}