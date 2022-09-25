/****************************************************
    文件：PlayerModel.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using log4net;
using YFramework;
using YFramework.Kit.Utility;

public interface IPlayerModel : IModel
{
   
    bool IsDied { get; }
    bool IsEmptyPower { get; }
    string Name { get; set; }
    int Level { get; set; }
    long Exp { get; set; }
    int Power { get; set; }
    int HP { get; set; }
    int Attack { get; set; }
    int Defence { get; set; }
    int Speed { get; set; }
    int Coin { get; set; }

    int UpperPower { get; set; }
    int UpperHP { get; set; }
    int UpperAttack { get; set; }
    int UpperDefence { get; set; }
    int UpperSpeed { get; set; }
    void UpdateLocalData();

}
public class PlayerModel : AbstractModel,IPlayerModel
{
    private PlayerData _data;
    // todo LogSystem应该分为Utility
    private LogUtility _logUtility;

    protected override void OnInit()
    {
        _logUtility = this.GetUtility<LogUtility>();
        _data = YJsonUtility.ReadFromJson<PlayerData>(Msg.Paths.Config.PlayerData);
    }
    public bool IsDied { get; private set; }
    public bool IsEmptyPower { get; private set; }
    public string Name
    {
        get => _data.Name; 
        set
        {
            // todo UpdateShowData
            _data.Name = value;
            YJsonUtility.WriteToJson(_data,Msg.Paths.Config.PlayerData);
        }
    }
    public int Level
    {
        get => _data.Level;
        set
        {
            // todo UpdateShowData
            _data.Level = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public long Exp
    {
        get => _data.Exp;
        set
        {
            _data.Exp = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public int Power
    {
        get => _data.Power;
        set
        {
            if (value < 0)
            {
                //todo 体力不够
                IsEmptyPower = true;
                value = 0;
                _logUtility.Log("体力不足!");
                return;
            }
            //恢复的体力不可以超过体力上限
            else if (value >= UpperPower)
            {
                value = UpperPower;
            }
            IsEmptyPower = false;
            // todo UpdateShowData
            _data.Power = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public int HP
    {
        get => _data.HP; 
        set
        {
            if(CheckChangeDied(value))
                return;
            //恢复的血量不可以超过血量上限
            if (value >= UpperHP)
            {
                value = UpperHP;
            }
            IsDied = false;
            // todo UpdateShowData
            _data.HP = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public int Attack
    {
        get => _data.Attack; 
        set
        {
            if ( value < PlayerData.LimitMinAttack)
            {
                value = PlayerData.LimitMinAttack;
            }
            else if (value > UpperAttack)
            {
                value = UpperAttack;
            }
            // todo UpdateShowData
            _data.Attack = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public int Defence
    {
        get => _data.Defence;
        set
        {
            if (value < PlayerData.LimitMinDefence)
            {
               value = PlayerData.LimitMinDefence;
            }
            else if (value > UpperDefence)
            {
                value = UpperDefence;
            }
            // todo UpdateShowData
            _data.Defence = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public int Speed
    {
        get => _data.Speed;
        set
        {
            if (value < PlayerData.LimitMinSpeed)
            {
                value = PlayerData.LimitMinSpeed;
            }
            else if (value > UpperSpeed)
            {
                value = UpperSpeed;
            }
            // todo UpdateShowData
            _data.Speed = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public int Coin
    {
        get => _data.Coin;
        set
        {
            if (value < 0)
                value = 0;
            // todo UpdateShowData
            _data.Coin = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }

    public int UpperPower
    {
        get => _data.UpperPower;
        set
        {
            if (value < PlayerData.LimitMinPower)
            {
                value = PlayerData.LimitMinPower;
                _logUtility.Log("已经到达最低体力上限值");
            }
            _data.UpperPower = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public int UpperHP
    {
        get => _data.UpperHP;
        set
        {
            if (value < PlayerData.LimitMinHP)
            {
                value = PlayerData.LimitMinHP;
                _logUtility.Log("已经到达最低生命上限值");
                return;
            }
            _data.UpperHP = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }
    public int UpperAttack
    {
        get => _data.UpperAttack;
        set
        {
            if (value < PlayerData.LimitMinAttack)
            {
                value = PlayerData.LimitMinAttack;
            }
            _data.UpperAttack = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }

    public int UpperDefence
    {
        get => _data.UpperDefence;
        set
        {
            if(value == 0)
                return;
            if (value < PlayerData.LimitMinDefence)
            {
                value = PlayerData.LimitMinDefence;
            }

            _data.UpperDefence = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }

    public int UpperSpeed
    {
        get => _data.UpperSpeed;
        set
        {
            if (value < PlayerData.LimitMinSpeed)
            {
                value = PlayerData.LimitMinSpeed;
            }

            _data.UpperSpeed = value;
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }
    }

    public void UpdateLocalData()
    {
        YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
    }


    private bool CheckChangeDied(int value)
    {
        if (HP <= 0 || HP + value <= 0)
        {
            //todo 玩家死亡
            IsDied = true;
            _logUtility.Log("玩家死亡！");
            HP = 0;
            return true;
        }

        return false;
    }   
}