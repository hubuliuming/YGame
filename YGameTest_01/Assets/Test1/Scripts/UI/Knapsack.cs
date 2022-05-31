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
    public RectTransform contextRect;
    private int _row = 6;
    private int _column = 10;
    private int _maxGirdNum = 99;
    private ObjectPool<GameObject> _goodsPool;
    public override void Init()
    {
        base.Init();
        _player = GameManager.Instance.player;
        Debug.Log(Paths.Goods);
        Debug.Log(Paths.ActiveApple);
        _goodsPool = FactoryBase.GetPool("Goods", Paths.Goods);
        int gridNum = 0;
        foreach (var  i in _player.GoodsDic.Keys)
        {
            var num = _player.GoodsDic[i];
            gridNum++;
            //单位格子已满
            while (num > _maxGirdNum)
            {
                gridNum++;
                num -= _maxGirdNum;
            }
        }
        Debug.Log("总计背包有："+gridNum+"格子物品");
        for (int i = 0; i < gridNum; i++)
        {
            _goodsPool.Get().transform.parent = contextRect;
        }
        var needRow = gridNum / _column + 1;
        Debug.Log("需要的行数："+needRow);
        //超过当界面扩展行数
        if (needRow > _row)
        {
            var addRow = needRow - _row;
            contextRect.sizeDelta += new Vector2(addRow * 150, 0);
        }
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