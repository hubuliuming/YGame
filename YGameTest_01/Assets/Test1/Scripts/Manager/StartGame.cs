/****************************************************
    文件：StartGame.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using YFramework;

public class StartGame : MonoBehaviour 
{
    private void Start()
    {
        //GameManager.Instance.ReloadJsonData();
        
        GameManager.Instance.InitPlayer();

        transform.Find("PlayerData").GetComponent<PlayerDataUI>().Init();
    }

    private void Update()
    {
        // test
        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateEnemy();
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
        apple.transform.localPosition = Vector3.one;
    }

    #endregion
}