/****************************************************
    文件：AddTime.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class AddTime : Item 
{
    protected override void Start()
    {
        Name = Consts.AddTime;
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(Consts.TagPlayer))
        {
            //todo addTime ，回收
            Pool.Release(gameObject);
            Debug.Log("AddTime");
        }
    }
}