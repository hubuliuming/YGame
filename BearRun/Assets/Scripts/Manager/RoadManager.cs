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
using YFramework;

public class RoadManager : MonoSingeton<RoadManager>
{
    private GameObject lastGo;
    private ObjectPool<GameObject> lastPool;
    private ObjectPool<GameObject> curPool;
    private ObjectPool<GameObject> nextPool;
    private List<string> m_RoadNames = new List<string>();

    private ObjectPool<GameObject> coinPool;

    private void Start()
    {
        m_RoadNames.Add(Consts.Pattern1);
        m_RoadNames.Add(Consts.Pattern2);
        m_RoadNames.Add(Consts.Pattern3);
        m_RoadNames.Add(Consts.Pattern4);

        curPool = PoolFactory.Get(Consts.Pattern1, Consts.PathPattern);
        curPool.Get();

        coinPool = PoolFactory.Get(Consts.Coin, Consts.PathItem);
        // todo 做道具的方案
        // for (int i = 0; i < 4; i++)
        // {
        //     var go = coinPool.Get();
        //     go.transform.SetLocalPosZ(20 + i * 10);
        // }
    }

    public void NextRoad(GameObject curGo)
    {
        nextPool = PoolFactory.Get(GetRandomStr(m_RoadNames,curGo.name),Consts.PathPattern);
        var go = nextPool.Get();
        var z = curGo.transform.position.z + 160;
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
    /// 获取名字列表中的的随机的名字
    /// </summary>
    /// <returns></returns>
    private string GetRandomStr(List<string> nameList,string curName)
    {
        List<string> temps = new List<string>();
        foreach (var roadName in nameList)
        {
            if (roadName != curName)
            {
                temps.Add(roadName);
            }
        }
        
        return temps[Random.Range(0, temps.Count)];
    }
    
}