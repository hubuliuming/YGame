/****************************************************
    文件：PlayerEvent.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;
using YFramework.Kit.Utility;

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
    
    void LevelUp();
    void ChangeUpperPower(int value);
    void ChangeUpperHP(int value);
    void ChangeUpperAttack(int value);
    void ChangeUpperDefence(int value);
    
}
public class PlayerEventSystem : AbstractSystem,IPlayerEventSystem
{
    private IPlayerModel _playerModel;
    private LogUtility _logUtility;
    protected override void OnInit()
    {
        _playerModel = this.GetModel<IPlayerModel>();
        _logUtility = this.GetUtility<LogUtility>();
    }
    
    public void ChangeName(string newName)
    {
        _playerModel.Name = newName;
    }
    public void ChangeExp(long value)
    {
        _playerModel.Exp += value;
    }
    public void ChangePower(int value)
    {
        _playerModel.Power += value;
    }
    public void ChangeHP(int value)
    {
        _playerModel.HP += value;
    }
    public void ChangeAttack(int value)
    {
        _playerModel.Attack += value;
    }
    public void ChangeDefence(int value)
    {
        _playerModel.Defence += value;
    }
    public void ChangeSpeed(int value)
    {
        _playerModel.Speed += value;
    }
    public void ChangeCoin(int value)
    {
        _playerModel.Coin += value;
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
            _logUtility.Log("经验不足升级");
        }
    }

    public void ChangeUpperPower(int value)
    {
        _playerModel.UpperPower += value;
    }
    public void ChangeUpperHP(int value)
    {
        _playerModel.UpperHP += value;
    }
    public void ChangeUpperAttack(int value)
    {
        _playerModel.UpperAttack += value;
    }
    public void ChangeUpperDefence(int value)
    {
        _playerModel.UpperDefence += value;
    }
}