/****************************************************
    文件：PlayerData.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/


public class PlayerData
{
    public string Name;
    public int Power;
    public int HP;
    public int Attack;
    public int Defence;
    public int Speed;
    public int Coin;

    public int UpperPower;
    public int UpperHP;
    public int UpperAttack;
    public int UpperDefence;
    public int UpperSpeed;

    //允许降低上限数值的最小值
    public const int LimitMinPower = 50;
    public const int LimitMinHP = 100;
    public const int LimitMinAttack = 5;
    public const int LimitMinDefence = 4;
    public const int LimitMinSpeed = 5;

    public PlayerData(
        string name,
        int power,
        int hp,
        int attack,
        int defence,
        int speed,
        int coin)
    {
        this.Name = name;
        this.Power = power;
        this.HP = hp;
        this.Attack = attack;
        this.Defence = defence;
        this.Speed = speed;
        this.Coin = coin;
        
        UpperPower = Power;
        UpperHP = HP;
        UpperAttack = Attack;
        UpperDefence = Defence;
        UpperSpeed = Speed;
    }
}