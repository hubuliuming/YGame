/****************************************************
    文件：RoadManager.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RoadManager : MonoSingeton<RoadManager>
{
    private GameObject lastGo;
    private ObjectPool<GameObject> lastPool;
    private ObjectPool<GameObject> curPool;
    private ObjectPool<GameObject> nextPool;
    private List<string> m_RoadNames = new List<string>();
    
    private void Start()
    {
        m_RoadNames.Add(Consts.Pattern1);
        m_RoadNames.Add(Consts.Pattern2);
        m_RoadNames.Add(Consts.Pattern3);
        m_RoadNames.Add(Consts.Pattern4);
        
        curPool = PoolFactory.Get(Consts.Pattern1, Consts.PathPattern); 
        curPool.Get();
    }

    public void NextRoad(GameObject curGo)
    {
        nextPool = PoolFactory.Get(GetRandomRoad(curGo.name),Consts.PathPattern);
        var z = curGo.transform.position.z + 160;
        var go = nextPool.Get();
        var position = go.transform.position;
        go.transform.position = new Vector3(position.x, position.y, z);
        //开局第一次触发没有后面的路所以加个判空
        if (lastPool != null)
        {
            lastPool.Release(lastGo);
        }
        lastPool = curPool;
        curPool = nextPool;
        lastGo = curGo;
    }
    /// <summary>
    /// 获取除当前道路名字的随机道路的名字
    /// </summary>
    /// <param name="curName">除去当前的名字</param>
    /// <returns></returns>
    private string GetRandomRoad(string curName)
    {
        List<string> temps = new List<string>();
        foreach (var roadName in m_RoadNames)
        {
            if (roadName != curName)
            {
                temps.Add(roadName);
            }
        }
        
        return temps[Random.Range(0, temps.Count)];
    }
}