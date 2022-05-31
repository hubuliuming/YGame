/****************************************************
    文件：ItemFactory.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/


using UnityEngine;
using UnityEngine.Pool;

public class ItemFactory : FactoryBase
{
    public static ObjectPool<GameObject> activeAppPool = GetPool(ItemName.ActiveApple,Paths.ActiveApple);
    //public static ObjectPool<GameObject> littleMeat = Get(ItemName.ActiveApple,Paths.ActiveApple);
}