/****************************************************
    文件：RecoverItem.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;

public class RecoverItem : ItemBase 
{
    public override void InitOnce()
    {
        base.InitOnce();
        UiUtility.Get("Btn").AddListener(()=>
        {
            _player.ChangeAll(data,true);
            MsgDispatcher.Send(RegisterMsg.UpdateShowData,null);
            FactoryBase.Release(data.name.ToString(),gameObject);
        });
    }
}