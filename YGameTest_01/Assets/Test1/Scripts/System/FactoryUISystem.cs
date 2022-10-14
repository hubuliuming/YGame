/****************************************************
    文件：FactoryBaseSystem.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using YFramework;
using YFramework.Kit.UI;
using YFramework.Kit.Utility;
using Object = UnityEngine.Object;


public interface IFactorySystem : ISystem
{
    ObjectPool<GameObject> GetPool(string poolName);
}
public class FactoryUISystem : AbstractSystem,IFactorySystem 
{
    private Dictionary<string, ObjectPool<GameObject>> _pools = new Dictionary<string, ObjectPool<GameObject>>();
    private LogUtility _logUtility;
    
    protected override void OnInit()
    {
        _logUtility = this.GetUtility<LogUtility>();
        var itemParent = GameObject.Find("ItemParent").transform;
        CreatePool(Msg.Prefab.活力苹果,Msg.ItemName.活力苹果,itemParent);
        CreateEnemyPool(Msg.Prefab.野猪, Msg.EnemyName.野猪, itemParent);
        CreatePool(Msg.Prefab.Goods,Msg.ItemName.Goods,itemParent);
    }

   
    public ObjectPool<GameObject> GetPool(string poolName)
    {
        if (!_pools.TryGetValue(poolName,out var itemPool))
        {
            _logUtility.LogError("想要获取的对象池未注册，name："+poolName);
            return null;
        }

        return itemPool;
    }
    private void CreateEnemyPool(string path, string poolName, Transform parent = null, Action<GameObject> onCreated = null)
    {
        if (!_pools.ContainsKey(poolName))
        {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                () =>
                {
                    var go = OnCreate(path, poolName, parent);
                    go.GetComponent<EnemyBase>().Init(poolName);
                    return go;
                },
                go =>
                {
                    go.SetActive(true);
                    go.GetComponent<EnemyBase>().InitData();
                },
                OnRelease);
            
            _pools.Add(poolName,pool);
        }
    }
    

    private void CreatePool(string path, string poolName, Transform parent = null)
    {
        if (!_pools.ContainsKey(poolName))
        {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                ()=> OnCreate(path,poolName,parent), 
                go =>OnGet(go),
                OnRelease);
            _pools.Add(poolName,pool);
        }
    }
    private GameObject OnCreate(string path,string itemName,Transform parent)
    {
        var prefab = Resources.Load<GameObject>(path);
        var go = Object.Instantiate(prefab,parent);
        go.name = itemName;
        return go;
    }
    private void OnGet(GameObject go)
    {
        go.SetActive(true);
    }
    private void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }
   
}