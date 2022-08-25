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

public class GameStart : MonoBehaviour
{
    private GameObject _knapsack;
    public PlayerManager playerManager;
    public ItemManager itemManager;
    private void Start()
    {
        
        playerManager.Init();
        PlayerManager.Instance.player = new Player();
        itemManager.Init();
        //GameManager.Instance.player.ReLoadJsonData(); 
        //WriteItemJson();
        //WriteEnemyJson();
        
        transform.Find("PlayerData").GetComponent<PlayerDetails>().Init();
        _knapsack = transform.Find("Knapsack").gameObject;
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
            {Msg.ItemName.SteamedBun,new ItemBase.ItemData()
            {
                addAttack = 0,
                addCoin = 0,
                addDefence = 0,
                addHp = 5,
                addPower = 20,
                addSpeed = 0
            }},
            {Msg.ItemName.ActiveApple,new ItemBase.ItemData()
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
                Msg.EnemyName.WildBoar, new EnemyBase.EnemyData()
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
                        GoodsName = Msg.ItemName.LittleMeat
                    }
                }
            }
        };
        YJsonUtility.WriteToJson(datas,Msg.Paths.Config.Enemy);
    }

    private void CreateEnemy()
    {
        var wildBoarPool = ItemFactory.GetPool(Msg.EnemyName.WildBoar,Msg.Paths.Prefab.Enemy,transform);
        var go = wildBoarPool.Get();
        go.transform.localPosition =Vector3.zero;
    }

    private void CreateItem()
    {
        var pool = ItemFactory.GetPool(Msg.ItemName.ActiveApple, Msg.Paths.Prefab.RecoverItem,transform);
        var go = pool.Get();
        go.transform.localPosition = new Vector3(300, 0, 0);
    }

    #endregion
}