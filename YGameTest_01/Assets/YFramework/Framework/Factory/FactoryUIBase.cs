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

public class FactoryUIBase
{
    private static Dictionary<string, ObjectPool<GameObject>> m_pool = new Dictionary<string, ObjectPool<GameObject>>();
    public static ObjectPool<GameObject> GetPool(string poolName,string path,Transform parent)
    {
        if (!m_pool.TryGetValue(poolName,out var data))
        {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                ()=> OnCreate(path,parent), 
                go =>OnGet(go),
                OnRelease);
            m_pool.Add(poolName,pool);
            return m_pool[poolName];
        }

        return data;
    }

    public static void Release(string poolName,GameObject go)
    {
        m_pool[poolName].Release(go);
    }
    
    private static GameObject OnCreate(string path,Transform parent)
    {
        var prefab = Resources.Load<GameObject>(path);
        var go = Object.Instantiate(prefab,parent);
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