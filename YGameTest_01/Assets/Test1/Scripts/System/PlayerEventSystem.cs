/****************************************************
    文件：PlayerEvent.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;

public interface IPlayerEventSystem : ISystem
{
    void LevelUp();
}
public class PlayerEventSystem : AbstractSystem,IPlayerEventSystem
{
    private IPlayerModel _playerModel;
    private ILogSystem _logSystem;
    protected override void OnInit()
    {
        _playerModel = this.GetModel<IPlayerModel>();
        _logSystem = this.GetSystem<ILogSystem>();
    }

    public void LevelUp()
    {
        var needExp = _playerModel.Level * 100 + 100;
        if (_playerModel.Exp >= needExp)
        {
            _playerModel.Level++;
            _playerModel.Exp -= needExp;
            //ChangeExp(-needExp);
        }
        else
        {
            _logSystem.Log("经验不足升级");
        }
    }
}