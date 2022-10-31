/****************************************************
    文件：ItemBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using Code_01;
using Code_01.System;
using YFramework;
using YFramework.Kit.UI;
using YFramework.Kit.Utility;

public interface IItem
{
    void Init(string itemName);
}
public class ItemBase : UIBase,IController,IInit
{
    [Serializable]
    public struct ItemData
    {
        public int addHp;
        public int addPower;
        public int addAttack;
        public int addDefence;
        public int addSpeed;
        public int addCoin;
    }

    private PlayerEventSystem _playerEventSystem;

    public void Init(string itemName)
    {
         var datas = YJsonUtility.ReadFromJson<Dictionary<string,ItemData>>(Msg.Paths.Config.RecoverItem);
         var data = datas[itemName];
         _playerEventSystem = this.GetSystem<PlayerEventSystem>();
         UiUtility.Get("Btn").AddListener(() =>
         {
             _playerEventSystem.ChangeAll(data);
             gameObject.Release();
         });
     
    }

    public IArchitecture GetArchitecture()
    {
        return Game.Interface;
    }
}