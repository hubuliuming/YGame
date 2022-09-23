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
    void ChangeName(string newName);
    void ChangeExp(long value);
    void ChangePower(int value);
    void ChangeHP(int value);
    void ChangeAttack(int value);
    void ChangeDefence(int value);
    void ChangeSpeed(int value);
    void ChangeCoin(int value);
    void ChangeAll();

    void LevelUp();
    void ChangeUpperPower(int value);
    void ChangeUpperHP(int value);
    void ChangeUpperAttack(int value);
    void ChangeUpperDefence(int value);
    
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

    public void ChangeName(string newName)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeExp(long value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangePower(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeHP(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeAttack(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeDefence(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeSpeed(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeCoin(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeAll()
    {
        throw new System.NotImplementedException();
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

    public void ChangeUpperPower(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeUpperHP(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeUpperAttack(int value)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeUpperDefence(int value)
    {
        throw new System.NotImplementedException();
    }
}