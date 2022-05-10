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

public class PoolFactory 
{
    private static Dictionary<string, ObjectPool<GameObject>> m_PoolDict = new Dictionary<string, ObjectPool<GameObject>>();
    
    /// <summary>
    ///  默认Resources根目录下
    /// </summary>
    /// <param name="dir">文件夹目录</param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static ObjectPool<GameObject> Get(string name,string dir = null)
    {
        dir = "Prefabs/" + dir;
        if(!m_PoolDict.TryGetValue(name,out var pool))
        {
          pool = CreateNewPool(name,dir);
        }

        return pool;
    }
    private static ObjectPool<GameObject> CreateNewPool(string _name, string dir = null)
    {
        ObjectPool<GameObject> pool;
        pool = new ObjectPool<GameObject>(() =>
        {
            var go = Object.Instantiate(Resources.Load<GameObject>(dir + _name));
            var replace = go.name.Replace("(Clone)", "");
            go.name = replace;
            return go;
        } ,o =>
        {
            o.SetActive(true);
        }, o =>
        {
            o.SetActive(false);
        });
        m_PoolDict.Add(_name,pool);
        return pool;
    }
    
}