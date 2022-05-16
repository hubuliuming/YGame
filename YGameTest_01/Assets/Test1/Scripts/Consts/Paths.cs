/****************************************************
    文件：Paths.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class Paths : MonoBehaviour
{
    public static readonly string PlayerData = Application.dataPath + "/Test1/Data/Player";
    //prefab
    public const string WildBoar = "Prefabs/Enemy/"+EnemyName.WildBoar;
    public const string ActiveApple = "Prefabs/Item/" + ItemName.ActiveApple;
}