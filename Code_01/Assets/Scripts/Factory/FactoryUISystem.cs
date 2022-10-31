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
using Object = UnityEngine.Object;

namespace Code_01
{
    public class FactoryUISystem : AbstractSystem 
    {
        private static Dictionary<string, ObjectPool<GameObject>> _pools = new Dictionary<string, ObjectPool<GameObject>>();
    
        protected override void OnInit()
        {
            var itemParent = GameObject.Find("ItemParent").transform;
            CreatePool(Msg.Prefab.活力苹果,Msg.ItemName.活力苹果,itemParent);
            CreateEnemyPool(Msg.Prefab.野猪, Msg.EnemyName.野猪, itemParent);
            CreatePool(Msg.Prefab.Goods,Msg.ItemName.Goods,itemParent);
        }
    
        public static GameObject Get(string name)
        {
            // todo 
            foreach (var objName in _pools.Keys)
            {
                if (objName.Equals(name))
                {
                    return _pools[objName].Get();
                }
            }
            LogUtility.LogWarning("工厂未生产该游戏物体："+ name);
            return null;
        }

        public static void Release(GameObject go)
        {
            foreach (var objName in _pools.Keys)
            {
                if (objName.Equals(go.name))
                {
                    _pools[objName].Release(go);
                    break;
                }
            }
            LogUtility.LogWarning("工厂对象池中不存在该物体:"+go.name);
        }


        public static ObjectPool<GameObject> GetPool(string poolName)
        {
            if (!_pools.TryGetValue(poolName,out var itemPool))
            {
                LogUtility.LogError("想要获取的对象池未注册，name："+poolName);
                return null;
            }

            return itemPool;
        }
        private void CreateEnemyPool(string path, string objName, Transform parent = null, Action<GameObject> onCreated = null)
        {
            if (!_pools.ContainsKey(objName))
            {
                ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                    () =>
                    {
                        var go = OnCreate(path, objName, parent);
                        go.GetComponent<EnemyBase>().Init(objName);
                        return go;
                    },
                    go =>
                    {
                        go.SetActive(true);
                        go.GetComponent<EnemyBase>().InitData();
                    },
                    OnRelease);
            
                _pools.Add(objName,pool);
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

    public static class FactoryExtensive
    {
        public static void Release(this GameObject go) => FactoryUISystem.Release(go);
    }
}