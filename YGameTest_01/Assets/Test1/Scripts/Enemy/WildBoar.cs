/****************************************************
    文件：WildBoar.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：野猪
*****************************************************/


public class WildBoar : EnemyBase
{
    public override void InitData()
    {
        data = new EnemyData()
        {
            Name = EnemyName.WildBoar,
            HP = 100,
            Attack = 5,
            Defence = 2,
            Speed = 5,
            NeedPower = 10,
            awrd = new EnemyData.Award()
            {
                Coin = 3
            }
        };
    }

    public override void Init()
    {
        base.Init();
    }
}