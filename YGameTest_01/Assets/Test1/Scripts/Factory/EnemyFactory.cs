/****************************************************
    文件：EnemyFactory.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.Pool;

public class EnemyFactory : FactoryBase
{
    public static ObjectPool<GameObject> wildBoardPool = Get(EnemyName.WildBoar,Paths.WildBoar);
    
}