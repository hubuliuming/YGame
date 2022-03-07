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
    private Dictionary<string, ObjectPool<GameObject>> PoolDict = new Dictionary<string, ObjectPool<GameObject>>();
    
    /// <summary>
    ///  默认Resources根目录下
    /// </summary>
    /// <param name="dir">文件夹目录</param>
    /// <param name="_name"></param>
    /// <returns></returns>
    public ObjectPool<GameObject> Get(string _name,string dir = null)
    {
        if(!PoolDict.TryGetValue(_name,out var pool))
        {
          pool = CreateNewPool(_name,dir);
        }

        return pool;
        //return PoolDict.ContainsKey(_name) ? PoolDict[_name] : CreateNewPool(_name,dir);
    }
    private ObjectPool<GameObject> CreateNewPool(string _name, string dir = null)
    {
        ObjectPool<GameObject> pool;
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(Resources.Load<GameObject>( dir+ _name));
           
        } ,o =>
        {
            o.SetActive(true);
        }, o =>
        {
            o.SetActive(false);
        });
        PoolDict.Add(dir+ _name,pool);
        return pool;
    }
}