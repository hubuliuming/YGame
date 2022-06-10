/****************************************************
    文件：FactoryBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class FactoryUIBase
{
    protected  Dictionary<string, ObjectPool<GameObject>> pools = new Dictionary<string, ObjectPool<GameObject>>();
    public ObjectPool<GameObject> GetPool(string poolName,string path,Transform parent)
    {
        if (!pools.TryGetValue(poolName,out var data))
        {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                ()=> OnCreate(path,parent), 
                go =>OnGet(go),
                OnRelease);
            pools.Add(poolName,pool);
            return pools[poolName];
        }

        return data;
    }
    
    protected void Release(string name,GameObject go)
    {
        pools[name].Release(go);
    }
    
    protected virtual GameObject OnCreate(string path,Transform parent = null)
    {
        var prefab = Resources.Load<GameObject>(path);
        var go = Object.Instantiate(prefab,parent);
        return go;
    }

    protected virtual void OnGet(GameObject go)
    {
        go.SetActive(true);
    }
    protected virtual void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }
}