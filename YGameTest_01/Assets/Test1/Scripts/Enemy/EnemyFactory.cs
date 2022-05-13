/****************************************************
    文件：EnemyFactory.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyFactory
{
    private static ObjectPool<GameObject> _pool = new ObjectPool<GameObject>(
        OnCreate, 
        go =>OnGet(go),
        OnRelease);
    private static Dictionary<string, ObjectPool<GameObject>> pools = new Dictionary<string, ObjectPool<GameObject>>();
    
    public static ObjectPool<GameObject> Get(string poolName)
    {
        if (!pools.TryGetValue(poolName,out var data))
        {
            pools.Add(poolName,_pool);
            return pools[poolName];
        }

        return data;
    }
    private static GameObject OnCreate()
    {
        var prefab = Resources.Load<GameObject>(Paths.WildBoar);
        var go = Object.Instantiate(prefab);
        return go;
    }

    private static void OnGet(GameObject go)
    {
        go.SetActive(true);
    }
    private static void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }
}