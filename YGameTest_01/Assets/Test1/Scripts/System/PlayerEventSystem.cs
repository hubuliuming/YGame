/****************************************************
    文件：PlayerEvent.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;

public class PlayerEventSystem : AbstractSystem
{
    private TypeEventSystem _typeEventSystem;
    private IPlayerModel _playerModel;
    protected override void OnInit()
    {
        _typeEventSystem = new TypeEventSystem();
        _playerModel = this.GetModel<IPlayerModel>();
        this.RegisterEvent<string>(ChangeName);

        // _typeEventSystem.Register(ChangeName())
    }
    public void ChangeName(string nameStr)
    {
        _playerModel.Name.Value = nameStr;
        //MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
        //UpdateLocalPlayerData();
    }

  
}