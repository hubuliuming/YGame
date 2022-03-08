/****************************************************
    文件：Road.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{
    public string Name;
    private List<string> m_RoadNames = new List<string>();
    private void Start()
    {
        m_RoadNames.Add(Consts.Pattern1);
        m_RoadNames.Add(Consts.Pattern2);
        m_RoadNames.Add(Consts.Pattern3);
        m_RoadNames.Add(Consts.Pattern4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var parrent = transform.parent.gameObject;
            var lastPool = PoolManager.Instance.Get(Name,Consts.PathPattern);
            var position1 = parrent.transform.position;
            var curZ = position1.z;
            
            var pool = PoolManager.Instance.Get(GetRandomRoad(Name),Consts.PathPattern);
            var z = curZ + 160;
            var go = pool.Get();
            var position = position1;
            go.transform.position = new Vector3(position.x, position.y, z);
        }
    }

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