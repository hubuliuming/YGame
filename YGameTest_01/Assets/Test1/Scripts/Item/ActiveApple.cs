/****************************************************
    文件：ActiveApple.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/


using System;
using YFramework;
[Obsolete]
public class ActiveApple : ItemBase 
{
    private int _addPower;
    public override void InitOnce()
    {
        base.InitOnce();
        UiUtility.Get("Btn").AddListener(()=>
       {
          Player.ChangePower(_addPower);
          MsgDispatcher.Send(RegisterMsg.UpdateShowData,null);
          FactoryBase.Release(ItemName.ActiveApple,gameObject);
       });
    }

    // public override void InitData()
    // {
    //     _addPower = 10;
    // }
}