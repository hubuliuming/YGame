/****************************************************
    文件：Knapsack.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
using YFramework.UI;


public class Knapsack : UIBase
{
    private Player _player;
    private int _rowNum = 10;
    private ObjectPool<GameObject> _goodsPool;
    public override void Init()
    {
        base.Init();
        _player = GameManager.Instance.player;
        _goodsPool = FactoryBase.Get("Goods", Paths.Goods);
    }


    public void UpdateGoods()
    {
        var count = _player.GoodsDic.Keys.Count;
        //todo 背包        
        foreach (var i in _player.GoodsDic)
        {
            
        }
    }
}