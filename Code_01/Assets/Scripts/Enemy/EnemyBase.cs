/****************************************************
    文件：EnemyBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using Code_01;
using Code_01.Command;
using Code_01.Enemy;
using Code_01.System;
using UnityEngine;
using UnityEngine.Pool;
using YFramework;
using YFramework.Kit.UI;
using YFramework.Kit.Utility;


public class EnemyBase : UIBase,IController
{
    public enum RareLevel
    {
        White,
        Green,
        Blue,
        Red,
        Gold
    }
    
    public EnemyModel.EnemyData data;
    protected EnemyModel.EnemyData initData;
    // todo level
    //protected RareLevel level;
    private ObjectPool<GameObject> _enemyPool;

    private Player _player;
    private PlayerEventSystem _playerEventSystem;
    public void Init(string enemyName)
    {
        var datas = YJsonUtility.ReadFromJson<Dictionary<string, EnemyModel.EnemyData>>(Msg.Paths.Config.Enemy);
       
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
    private void ChangeHP(ref int hpSelf,int defenceSelf,bool isDebug = true)
    {
        var attackValue = AttackMath.AttackValue(_player.Attack,defenceSelf,isDebug);
        hpSelf -= attackValue;
        if(isDebug)
            Debug.Log("cur enemyHP:"+ hpSelf);
    }
    
    public IArchitecture GetArchitecture()
    {
        return Game.Interface;
    }
}