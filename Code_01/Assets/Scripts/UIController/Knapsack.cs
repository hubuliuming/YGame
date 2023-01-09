/****************************************************
    文件：Knapsack.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using Code_01.Mode;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using YFramework;
using YFramework.Kit;
using YFramework.Kit.UI;

namespace Code_01
{
    public class Knapsack : UIBase,IController
    {
        private PlayerModel _playerModel;
        public RectTransform contextRect;
    
        private const int Row = 6;
        private const int Column = 10;
        private const int MaxGirdNum = 99;

        public void Init()
        {
            _playerModel = this.GetModel<PlayerModel>();
            // todo fix
            int gridNum = 0;
        
            foreach (var i in _playerModel.GoodsDict.Keys)
            {
                //金币不展示背包格子
                if(i.Equals("Coin")) continue;
                var kindNum = _playerModel.GoodsDict[i];
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
            var count = _playerModel.GoodsDict.Keys.Count;
            //todo 更新背包显示       
            foreach (var i in _playerModel.GoodsDict)
            {
            
            }
        }

        private void CreateGrid(string goodName,int num)
        {
            var go = FactoryUISystem.Get(Msg.ItemName.Goods);
            go.transform.SetParent(contextRect,false);
            go.transform.Find("TxtNum").GetComponent<Text>().text = num.ToString();
            go.transform.Find("TxtName").GetComponent<Text>().text = goodName;
            go.GetComponent<Button>().onClick.AddListener(() =>
            {
                // todo 
                MsgDispatcher.Send(Msg.Register.UseGoods,null);
            });
        }

        public IArchitecture GetArchitecture()
        {
            return Game.Interface;
        }
    }
}