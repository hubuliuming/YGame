/****************************************************
    文件：Item.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.Pool;

public class Item : MonoBehaviour
{
    protected ObjectPool<GameObject> Pool;
    protected string Name;
    protected virtual void Start()
    {
        Pool = PoolFactory.Get(Name, Consts.PathItem);
    }
}