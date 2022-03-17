/****************************************************
    文件：Multiply.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class Multiply : Item 
{
    protected override void Start()
    {
        Name = Consts.Multiply;
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(Consts.TagPlayer))
        {
            //todo 双倍金币
            Pool.Release(gameObject);
        }
    }
}