/****************************************************
    文件：PoolManager.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：池管理
*****************************************************/


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoSingeton<PoolManager>
{
    public string PoolDir { get; set; }
    private Dictionary<string, ObjectPool<GameObject>> PoolDict = new Dictionary<string, ObjectPool<GameObject>>();
    private void Start()
    {
        PoolDir = "Prefabs/";
    }

    
    public ObjectPool<GameObject> Get(string name)
    {
        return PoolDict.ContainsKey(name) ? PoolDict[name] : CreateNewPool(name);
    }
    
    private ObjectPool<GameObject> CreateNewPool(string name)
    {
        ObjectPool<GameObject> pool;
        pool = new ObjectPool<GameObject>(() =>
        {
           return Instantiate(Resources.Load<GameObject>( PoolDir+ name));
           
        } ,o =>
        {
            o.SetActive(true);
        }, o =>
        {
            o.SetActive(false);
        });
        PoolDict.Add(name,pool);
        return pool;
    }

  
}