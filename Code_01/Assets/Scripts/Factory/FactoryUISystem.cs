/****************************************************
    文件：FactoryBaseSystem.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using Code_01.Enemy;
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
            CreateItemPool(Msg.Prefab.活力苹果, Msg.ItemName.活力苹果, itemParent);
            CreateEnemyPool(Msg.Prefab.野猪, Msg.EnemyName.野猪, itemParent);
            CreatePool(Msg.Prefab.Goods, Msg.ItemName.Goods, itemParent);
        }
        public static GameObject Get(string name)
        {
            foreach (var objName in _pools.Keys)
            {
                if (objName.Equals(name))
                {
                    return _pools[objName].Get();
                }
            }

            LogUtility.LogWarning("工厂未生产该游戏物体：" + name);
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

            LogUtility.LogWarning("工厂对象池中不存在该物体:" + go.name);
        }

        private void CreateEnemyPool(string path, string objName, Transform parent = null, Action<GameObject> onCreated = null)
        {
            if (!_pools.ContainsKey(objName))
            {
                ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                    () =>
                    {
                        var go = OnCreate(path, objName, parent);
                        go.GetComponent<IInit>().Init(objName);
                        return go;
                    },
                    go =>
                    {
                        go.SetActive(true);
                        go.GetComponent<EnemyBase>().InitData();
                    },
                    OnRelease);
                _pools.Add(objName, pool);
            }
        }

        private void CreateItemPool(string path, string objName, Transform parent = null)
        {
            if (!_pools.ContainsKey(objName))
            {
                ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                    () =>
                    {
                        var go = OnCreate(path, objName, parent);
                        go.GetComponent<IInit>().Init(objName);
                        return go;
                    },
                    go => OnGet(go),
                    OnRelease);
                _pools.Add(objName, pool);
            }
        }

        private void CreatePool(string path, string objName, Transform parent = null)
        {
            if (!_pools.ContainsKey(objName))
            {
                ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                    () =>
                        OnCreate(path, objName, parent),
                    go => OnGet(go),
                    OnRelease);
                _pools.Add(objName, pool);
            }
        }

        private GameObject OnCreate(string path, string itemName, Transform parent)
        {
            var prefab = Resources.Load<GameObject>(path);
            var go = Object.Instantiate(prefab, parent);
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