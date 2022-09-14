/****************************************************
    文件：ItemBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using YFramework.Kit.UI;
using YFramework.Kit.Utility;

public interface IItem
{
    void Init(string itemName);
}
public abstract class ItemBase : UIBase,IItem
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

    public void Init(string itemName)
    {
         var _player = PlayerManager.Instance.player;
         var datas = YJsonUtility.ReadFromJson<Dictionary<string,ItemData>>(Msg.Paths.Config.RecoverItem);
         foreach (var item in datas.Keys)
         {
             if (item == itemName)
             {
                 var data = datas[itemName];
                 UiUtility.Get("Btn").AddListener(() =>
                 {
                     _player.ChangeAll(data);
                     //MsgDispatcher.Send(MsgRegister.UpdateShowData,null);
                     ItemFactory.Release(itemName,gameObject);
                 });
                 break;
             }
         }
    }
}