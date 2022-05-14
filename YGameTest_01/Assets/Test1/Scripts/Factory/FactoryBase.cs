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

public interface IInit
{
    void Init();
}
public class FactoryBase
{
    protected static Dictionary<string, ObjectPool<GameObject>> pools = new Dictionary<string, ObjectPool<GameObject>>();
    protected static ObjectPool<GameObject> Get(string poolName,string path)
    {
        if (!pools.TryGetValue(poolName,out var data))
        {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                ()=> OnCreate(path), 
                go =>OnGet(go),
                OnRelease);
            pools.Add(poolName,pool);
            return pools[poolName];
        }

        return data;
    }
    private static GameObject OnCreate(string path)
    {
        //Debug.Log("CreatePool");
        var prefab = Resources.Load<GameObject>(path);
        var go = Object.Instantiate(prefab);
        go.GetComponent<IInit>().Init();
        return go;
    }

    private static void OnGet(GameObject go)
    {
        //go.GetComponent<IInit>()?.Init();
        go.SetActive(true);
    }
    private static void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }
}