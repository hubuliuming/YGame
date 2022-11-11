/****************************************************
    文件：StartGame.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using Code_01.Enemy;
using UnityEngine;
using YFramework;
using YFramework.Kit.Utility;

namespace Code_01.Controller
{
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

            if (Input.GetKeyDown(KeyCode.I))
            {
                CreateItem();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                _knapsack.SetActive(!_knapsack.activeSelf);
            }
        }

        #region TestMeoth

        private void CreateEnemy()
        {
            var go = FactoryUISystem.Get(Msg.EnemyName.野猪);
            go.transform.localPosition =Vector3.zero;
        }

        private void CreateItem()
        {
            var go =FactoryUISystem.Get(Msg.ItemName.活力苹果);
            go.transform.localPosition = new Vector3(300, 0, 0);
        }

        #endregion

        public IArchitecture GetArchitecture()
        {
            return Game.Interface;
        }
    }
}