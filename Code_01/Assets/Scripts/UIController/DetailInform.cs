/****************************************************
    文件：DetailInform.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework.Kit;
using YFramework.Kit.UI;

namespace Code_01.Controller
{
    public class DetailInform : UIBase
    {
        public string Inform;
        public void Init()
        {
            UiUtility.Get("Text").SetText(Inform);
            UiUtility.Get("BtnUse").AddListener(()=>MsgDispatcher.Register(Msg.Register.UseGoods, o =>
            {
                var itemData = o is ItemBase.ItemData ? (ItemBase.ItemData) o : default;
                //player.ChangeAll(itemData);
            }));
        }
    }
}