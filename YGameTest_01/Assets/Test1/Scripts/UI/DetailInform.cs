/****************************************************
    文件：DetailInform.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;
using YFramework.UI;

public class DetailInform : UIBase
{
    public string Inform;
    public override void Init()
    {
        base.Init();
        var player = GameManager.Instance.player;
        UiUtility.Get("Text").SetText(Inform);
        UiUtility.Get("BtnUse").AddListener(()=>MsgDispatcher.Register(MsgRegister.UseGoods, o =>
        {
            var itemData = o is ItemBase.ItemData ? (ItemBase.ItemData) o : default;
            //player.ChangeAll(itemData);
        }));
    }
}