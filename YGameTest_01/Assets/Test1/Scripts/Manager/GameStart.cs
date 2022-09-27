/****************************************************
    文件：StartGame.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using YFramework;
using YFramework.Kit.Utility;

public class GameStart : MonoBehaviour,IController
{
    private GameObject _knapsack;
    public Transform UIShow;
    private void Start()
    {
        //WriteItemJson();
        //WriteEnemyJson();
        
        UIShow.Find("PlayerDetails").GetComponent<PlayerDetails>().Init();
        _knapsack = UIShow.Find("Knapsack").gameObject;
        _knapsack.GetComponent<Knapsack>().Init();
    }

    private void Update()
    {
        // test
        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateEnemy();
        }
        if(Input.GetKeyDown(KeyCode.I))
            CreateItem();
        if (Input.GetKeyDown(KeyCode.B))
        {
            _knapsack.SetActive(!_knapsack.activeSelf);
        }
    }

    #region TestMeoth

    private void WriteItemJson()
    {
        Dictionary<string,ItemBase.ItemData> datas = new Dictionary<string,ItemBase.ItemData>
        {
            {Msg.ItemName.馒头,new ItemBase.ItemData()
            {
                addAttack = 0,
                addCoin = 0,
                addDefence = 0,
                addHp = 5,
                addPower = 20,
                addSpeed = 0
            }},
            {Msg.ItemName.活力苹果,new ItemBase.ItemData()
            {
                addAttack = 0,
                addCoin = 0,
                addDefence = 0,
                addHp = 10,
                addPower = 10,
                addSpeed = 0
            }}
        };
        YJsonUtility.WriteToJson(datas,Msg.Paths.Config.RecoverItem);
    }

    private void WriteEnemyJson()
    {
        Dictionary<string, EnemyBase.EnemyData> datas = new Dictionary<string, EnemyBase.EnemyData>()
        {
            {
                Msg.EnemyName.野猪, new EnemyBase.EnemyData()
                {
                    HP = 100,
                    Attack = 10,
                    Defence = 3,
                    Speed = 5,
                    CostPower = 10,
                    award = new EnemyBase.EnemyData.Award()
                    {
                        Exp = 10,
                        Coin = 20,
                        GoodsName = Msg.ItemName.小块肉
                    }
                }
            }
        };
        YJsonUtility.WriteToJson(datas,Msg.Paths.Config.Enemy);
    }

    private void CreateEnemy()
    {
        var wildBoarPool = this.GetSystem<FactoryUISystem>().GetPool(Msg.EnemyName.野猪);
        var go = wildBoarPool.Get();
        go.transform.SetParent(transform,false);
        go.transform.localPosition =Vector3.zero;
    }

    private void CreateItem()
    {
        var pool = this.GetSystem<FactoryUISystem>().GetPool(Msg.ItemName.活力苹果);
        var go = pool.Get();
        go.transform.SetParent(transform,false);
        go.transform.localPosition = new Vector3(300, 0, 0);
    }

    #endregion

    public IArchitecture GetArchitecture()
    {
        return Game.Interface;
    }
}