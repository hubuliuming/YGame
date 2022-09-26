/****************************************************
    文件：ItemFactory.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ItemFactory
{
    private static Dictionary<string, ObjectPool<GameObject>> _pools = new Dictionary<string, ObjectPool<GameObject>>();
    public static ObjectPool<GameObject> GetPool(string poolName,string path,Transform parent)
    {
        if (!_pools.TryGetValue(poolName,out var data))
        {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                ()=> OnCreate(path,poolName,parent), 
                go =>OnGet(go),
                OnRelease);
            _pools.Add(poolName,pool);
            return _pools[poolName];
        }
    
        return data;
    }

    public static void Get(string itemName)
    {
        //_pools[itemName]
    }
    
    public static void Release(string name,GameObject go)
    {
        _pools[name].Release(go);
    }
    
    private static GameObject OnCreate(string path,string itemName,Transform parent)
    {
        var prefab = Resources.Load<GameObject>(path);
        var go = Object.Instantiate(prefab,parent);
        go.GetComponent<IItem>().Init(itemName);
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