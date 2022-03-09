/****************************************************
    文件：Test2.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Test2 : MonoBehaviour
{
    private ObjectPool<GameObject> road1Pool;
    private List<GameObject> goList = new List<GameObject>();
    private int index =-1;
    private void Start()
    {
        road1Pool = PoolFactory.Get("road1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            goList.Add(road1Pool.Get());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            road1Pool.Release(goList[index]);
            index--;
        }
        
    }
}