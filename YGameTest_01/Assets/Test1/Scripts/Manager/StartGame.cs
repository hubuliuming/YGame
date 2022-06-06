/****************************************************
    文件：StartGame.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using YFramework;

public class StartGame : MonoBehaviour
{
    private GameObject _knapsack;
    private void Start()
    {
        GameManager.Instance.player = new Player();
        //GameManager.Instance.player.ReLoadJsonData(); 
        
        //write new json 
        ItemData[] datas = new ItemData[]
        {
            new ItemData()
            {
                name = ItemName.SteamedBun,
                addAttack = 0,
                addCoin = 10,
                addDefence = 0,
                addHp = 5,
                addPower = 20,
                addSpeed = 0
            },
            new ItemData()
            {
                name = ItemName.ActiveApple,
                addAttack = 0,
                addCoin = 10,
                addDefence = 0,
                addHp = 10,
                addPower = 10,
                addSpeed = 0
            },
        };
        YJsonUtility.WriteToJson(datas,Paths.RecoverItemConfig);
        
        transform.Find("PlayerData").GetComponent<PlayerDataUI>().Init();
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

    private void CreateEnemy()
    {
        var wildBoarPool = EnemyFactory.wildBoardPool;
        var go = wildBoarPool.Get();
        go.transform.SetParent(transform);
        go.transform.localPosition =Vector3.zero;
    }

    private void CreateItem()
    {
        var apple = ItemFactory.activeAppPool.Get();
        apple.transform.SetParent(transform);
        apple.transform.localPosition = new Vector3(300,0,0);
    }

    #endregion
}