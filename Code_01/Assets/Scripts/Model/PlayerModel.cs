/****************************************************
    文件：PlayerModel.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using YFramework;
using YFramework.Kit.Utility;

namespace Code_01.Mode
{
    public class PlayerModel : AbstractModel
    {
        private PlayerData _data;
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
                _data.Name = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_data,Msg.Paths.Config.PlayerData);
            }
        }
        public int Level
        {
            get => _data.Level;
            set
            {
                _data.Level = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
            }
        }
        public long Exp
        {
            get => _data.Exp;
            set
            {
                _data.Exp = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
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
                _data.Power = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
            }
        }
        public int Hp
        {
            get => _data.Hp; 
            set
            {
                if(CheckChangeDied(value))
                    return;
                //恢复的血量不可以超过血量上限
                if (value >= UpperHp)
                {
                    value = UpperHp;
                }
                IsDied = false;
                _data.Hp = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
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
                _data.Attack = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
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
                _data.Defence = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
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
                _data.Speed = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
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
                _data.Coin = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
            }
        }

        public Dictionary<string,int> GoodsDict
        {
            get => _data.goodsDict ;
            set
            {
                _data.goodsDict = value;
                // todo 更新背包参数
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
        public int UpperHp
        {
            get => _data.UpperHp;
            set
            {
                if (value < PlayerData.LimitMinHP)
                {
                    value = PlayerData.LimitMinHP;
                    _logUtility.Log("已经到达最低生命上限值");
                    return;
                }
                _data.UpperHp = value;
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

        public Dictionary<string, int> goodsDict;

        public void UpdateLocalData()
        {
            YJsonUtility.WriteToJson(_data, Msg.Paths.Config.PlayerData);
        }


        private bool CheckChangeDied(int value)
        {
            if (Hp <= 0 || Hp + value <= 0)
            {
                //todo 玩家死亡
                IsDied = true;
                _logUtility.Log("玩家死亡！");
                Hp = 0;
                return true;
            }

            return false;
        }   
    }
}