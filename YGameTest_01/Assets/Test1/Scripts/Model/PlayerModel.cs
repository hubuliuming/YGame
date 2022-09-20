/****************************************************
    文件：PlayerModel.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;
using YFramework.Kit.Utility;

public interface IPlayerModel : IModel
{
    BindableProperty<string> Name { get;  set; }
    BindableProperty<int> Level { get; set; }
    BindableProperty<long> Exp { get; set; }
    BindableProperty<int> Power { get; set; }
    BindableProperty<int> HP { get; set; }
    BindableProperty<int> Attack { get; set; }
    BindableProperty<int> Defence { get; set; }
    BindableProperty<int> Speed { get; set; }
    BindableProperty<int> Coin { get; set; }
    
    BindableProperty<int> UpperPower { get; set; }
    BindableProperty<int> UpperHP { get; set; }
    BindableProperty<int> UpperAttack { get; set; }
    BindableProperty<int> UpperDefence { get; set; }
    BindableProperty<int> UpperSpeed { get; set; }
 
}
public class PlayerModel : AbstractModel,IPlayerModel
{
    private PlayerData _data;
    protected override void OnInit()
    { 
        _data = YJsonUtility.ReadFromJson<PlayerData>(Msg.Paths.Config.PlayerData);
        Name.Value = _data.Name;
        Level.Value = _data.Level;
        Exp.Value = _data.Exp;
        Power.Value = _data.Power;
        // Power.RegisterOnValueChange()
        HP.Value = _data.HP;
        Attack.Value = _data.Attack;
        Defence.Value = _data.Defence;
        Speed.Value = _data.Speed;
        Coin.Value = _data.Coin;
        UpperPower.Value = _data.UpperPower;
        UpperHP.Value = _data.UpperHP;
        UpperAttack.Value = _data.UpperAttack;
        UpperDefence.Value = _data.UpperDefence;
        UpperSpeed.Value = _data.UpperSpeed;

        Name.RegisterOnValueChange(val =>
        {
            // todo UpdateShowData
            _data.Name = val;
            YJsonUtility.WriteToJson(_data,Msg.Paths.Config.PlayerData);
        });
    }

    public BindableProperty<string> Name { get; set; }
    public BindableProperty<int> Level { get; set; }
    public BindableProperty<long> Exp { get; set; }
    public BindableProperty<int> Power { get; set; }
    public BindableProperty<int> HP { get; set; }
    public BindableProperty<int> Attack { get; set; }
    public BindableProperty<int> Defence { get; set; }
    public BindableProperty<int> Speed { get; set; }
    public BindableProperty<int> Coin { get; set; }
    public BindableProperty<int> UpperPower { get; set; }
    public BindableProperty<int> UpperHP { get; set; }
    public BindableProperty<int> UpperAttack { get; set; }
    public BindableProperty<int> UpperDefence { get; set; }
    public BindableProperty<int> UpperSpeed { get; set; }
}