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
    public  void InitOnce()
    {
        //base.InitOnce();
        UiUtility.Get("Btn").AddListener(()=>
        {
            // _player.ChangeAll(_data,true);
            // MsgDispatcher.Send(MsgRegister.UpdateShowData,null);
            // FactoryBase.Release(_data.name,gameObject);
        });
    }
    
    
}