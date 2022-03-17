/****************************************************
    文件：Coin.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class Coin : Item 
{
    protected override void Start()
    {
        Name = Consts.Coin;
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(Consts.TagPlayer))
        {
            // RoadManager.Instance.CoinRelease(gameObject);
            Pool.Release(gameObject);
        }
        else if (other.tag.Contains(Consts.Magnet))
        {
            var isLoop = true;
            var playerPos = other.transform.parent.position;
            while (isLoop)
            {
                transform.position = Vector3.Lerp(transform.position, playerPos,Time.deltaTime);
                if (Vector3.Distance(transform.position,playerPos) < 0.5f)
                {
                    isLoop = false;
                }
            }

        }
    }
}   