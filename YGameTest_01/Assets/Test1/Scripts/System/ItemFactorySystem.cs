/****************************************************
    文件：FactorySystem.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using YFramework;

public interface IFactorySystem : ISystem
{
    ObjectPool<GameObject> GetPool(string poolName);
}

public class ItemFactorySystem : AbstractSystem,IFactorySystem
{
    private Dictionary<string, ObjectPool<GameObject>> _pools = new Dictionary<string, ObjectPool<GameObject>>();
    
    public ObjectPool<GameObject> GetPool(string poolName)
    {
        if (!_pools.TryGetValue(poolName,out var itemPool))
        {
            this.GetUtility<LogUtility>().LogError("想要获取的对象池未注册，name："+poolName);
            return null;
        }

        return itemPool;
    }
    private void CreatePool(string path,string poolName,Transform parent = null)
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
    protected override void OnInit()
    {
        CreatePool(Msg.ItemName.ActiveApple,Msg.Prefab.RecoverItem,null);
    }
}