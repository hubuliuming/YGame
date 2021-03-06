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

    private static Dictionary<string, ObjectPool<GameObject>> _pools = new Dictionary<string, ObjectPool<GameObject>>();
    public static ObjectPool<GameObject> GetPool(string poolName,string path,string enemyName)
    {
        if (!_pools.TryGetValue(poolName,out var data))
        {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                ()=> OnCreate(path,enemyName), 
                go =>OnGet(go),
                OnRelease);
            _pools.Add(poolName,pool);
            return _pools[poolName];
        }

        return data;
    }
    
    public static void Release(string name,GameObject go)
    {
        _pools[name].Release(go);
    }
    
    private static GameObject OnCreate(string path,string itemName)
    {
        var prefab = Resources.Load<GameObject>(path);
        var go = Object.Instantiate(prefab);
        go.GetComponent<EnemyBase>().Init(itemName);
        return go;
    }

    private static void OnGet(GameObject go)
    {
        go.SetActive(true);
        go.GetComponent<EnemyBase>().InitData();
    }
    private static void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }
}