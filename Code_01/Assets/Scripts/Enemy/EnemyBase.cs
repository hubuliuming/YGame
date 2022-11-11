/****************************************************
    文件：EnemyBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using Code_01.Command;
using Code_01.System;
using UnityEngine;
using UnityEngine.Pool;
using YFramework;
using YFramework.Kit.UI;
using YFramework.Kit.Utility;


namespace Code_01.Enemy
{
    public class EnemyBase : UIBase,IController,IInit
    {
        public enum RareLevel
        {
            White,
            Green,
            Blue,
            Red,
            Gold
        }
    
        [Serializable]
        public struct EnemyData
        {
            public string Name;
            public int HP;
            public int Attack;
            public int Defence;
            public int Speed;

            public int CostPower;
            public Award award;

            //奖励
            [Serializable]
            public struct Award
            {
                public int Exp;
                public int Coin;
                public string GoodsName;
            }
  
        }
    
        public EnemyData data;
        protected EnemyData initData;
        // todo level
        //protected RareLevel level;
        private ObjectPool<GameObject> _enemyPool;

        private PlayerEventSystem _playerEventSystem;
        public void Init(string enemyName)
        {
            var datas = YJsonUtility.ReadFromJson<Dictionary<string, EnemyData>>(Msg.Paths.Config.Enemy);
       
            data = datas[enemyName];
            initData = data;
            InitData();
            UiUtility.Get("BtnAttack").AddListener(()=>
            {
                Debug.Log("Attack");
                this.SendCommand(new AttackCommand(gameObject));
            });
        }

        public void InitData()
        {
            data = initData;
        }
        public IArchitecture GetArchitecture()
        {
            return Game.Interface;
        }
    }
}