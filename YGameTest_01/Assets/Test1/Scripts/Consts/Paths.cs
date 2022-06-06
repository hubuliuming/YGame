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
    public static readonly string PlayerData = Application.dataPath + "/Test1/Data/Player";

    public static readonly string RecoverItemConfig = Application.dataPath + "/Test1/Data/RecoverItem";
    //prefab
    public static readonly string WildBoar = "Prefabs/Enemy/"+EnemyName.WildBoar;
    public static readonly string ActiveApple = "Prefabs/Item/RecoverItem/" + ItemName.ActiveApple;
    public static readonly string Goods = "Prefabs/Goods";
}