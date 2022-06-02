/****************************************************
    文件：Knapsack.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using YFramework.UI;

public class Knapsack : UIBase
{
    private Player _player;
    public RectTransform contextRect;
    private ObjectPool<GameObject> _goodsPool;
    
    private const int Row = 6;
    private const int Column = 10;
    private const int MaxGirdNum = 99;

    public override void Init()
    {
        base.Init();
        _player = GameManager.Instance.player;
        _goodsPool = FactoryBase.GetPool("Goods", Paths.Goods);
        int gridNum = 0;
        foreach (var  i in _player.GoodsDic.Keys)
        {
            var kindNum = _player.GoodsDic[i];
            //单位格子已满
            while (kindNum > MaxGirdNum)
            {
                gridNum++;
                CreateGrid(i,MaxGirdNum);
                kindNum -= MaxGirdNum;
            }
            gridNum++;
            CreateGrid(i,kindNum);
        }
        Debug.Log("总计背包有："+gridNum+"格子物品");
        var needRow = gridNum / Column + 1;
        Debug.Log("需要的行数："+needRow);
        //超过当界面扩展行数
        if (needRow > Row)
        {
            var addRow = needRow - Row;
            Debug.Log("拓展的行数："+addRow);
            contextRect.sizeDelta += new Vector2(0, addRow * 150);
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

    private void CreateGrid(string goodName,int num)
    {
        var go = _goodsPool.Get();
        go.transform.SetParent(contextRect,false);
        go.transform.Find("TxtNum").GetComponent<Text>().text = num.ToString() ;
        go.transform.Find("TxtName").GetComponent<Text>().text = goodName;
    }
}