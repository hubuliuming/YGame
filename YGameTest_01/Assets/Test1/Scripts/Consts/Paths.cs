/****************************************************
    文件：Paths.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
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
        public static readonly string WildBoar = "Prefabs/Enemy/"+EnemyName.WildBoar;
        public static readonly string RecoverItem = "Prefabs/Item/RecoverItem";
        public static readonly string Enemy = "Prefabs/Enemy";
        public static readonly string Goods = "Prefabs/Goods";
    }

}