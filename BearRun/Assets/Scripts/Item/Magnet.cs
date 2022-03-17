/****************************************************
    文件：Magnet.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class Magnet : Item 
{
    protected override void Start()
    {
        Name = Consts.Magnet;
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(Consts.TagPlayer))
        {
           Pool.Release(gameObject);
        }
    }
}