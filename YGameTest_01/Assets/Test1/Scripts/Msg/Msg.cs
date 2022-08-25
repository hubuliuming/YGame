/****************************************************
    文件：Msg.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class Msg 
{
    public struct EnemyName
    {
        public static readonly string WildBoar = "野猪";
    }
    public struct ItemName
    {
        public static readonly string ActiveApple = "活力苹果";
        public static readonly string SteamedBun = "馒头";
        public static readonly string LittleMeat = "小块肉";
        public static readonly string Goods = "Goods";
    }
    public struct MsgRegister
    {
        public const string PlayerAttack = "PlayerAttack";
        public const string UpdateShowData = "UpdateShowData";
        public const string UseGoods = "UseGoods";
    }
    
    public class Paths
    {
        public struct Config
        {
            public static readonly string PlayerData = Application.dataPath + "/Test1/Data/Player";
            public static readonly string RecoverItem = Application.dataPath + "/Test1/Data/RecoverItem";
            public static readonly string Enemy = Application.dataPath + "/Test1/Data/Enemy";
        }
        public struct Prefab
        {
            public static readonly string WildBoar = "Prefabs/Enemy/"+Msg.EnemyName.WildBoar;
            public static readonly string RecoverItem = "Prefabs/Item/RecoverItem";
            public static readonly string Enemy = "Prefabs/Enemy";
            public static readonly string Goods = "Prefabs/Goods";
        }

    }
    
}