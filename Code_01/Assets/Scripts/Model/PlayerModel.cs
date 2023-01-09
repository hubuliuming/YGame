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
        private PlayerData _playerData;

        protected override void OnInit()
        {
            _playerData = YJsonUtility.ReadFromJson<PlayerData>(Msg.Paths.Config.PlayerData);
        }
        public bool IsDied { get; private set; }
        public bool IsEmptyPower { get; private set; }
        public string Name
        {
            get => _playerData.property.Name; 
            set
            {
                _playerData.property.Name = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData,Msg.Paths.Config.PlayerData);
            }
        }
        public int Level
        {
            get => _playerData.property.Level;
            set
            {
                _playerData.property.Level = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public long Exp
        {
            get => _playerData.property.Exp;
            set
            {
                _playerData.property.Exp = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int Power
        {
            get => _playerData.property.Power;
            set
            {
                if (value < 0)
                {
                    //todo 体力不够
                    IsEmptyPower = true;
                    value = 0;
                    LogUtility.Log("体力不足!");
                    return;
                }
                //恢复的体力不可以超过体力上限
                else if (value >= UpperPower)
                {
                    value = UpperPower;
                }
                IsEmptyPower = false;
                _playerData.property.Power = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int Hp
        {
            get => _playerData.property.Hp; 
            set
            {
                if (CheckChangeDied(value)) return;
                //恢复的血量不可以超过血量上限
                if (value >= UpperHp)
                {
                    value = UpperHp;
                }
                IsDied = false;
                _playerData.property.Hp = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int Attack
        {
            get => _playerData.property.Attack; 
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
                _playerData.property.Attack = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int Defence
        {
            get => _playerData.property.Defence;
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
                _playerData.property.Defence = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int Speed
        {
            get => _playerData.property.Speed;
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
                _playerData.property.Speed = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int Coin
        {
            get => _playerData.goodsDict["Coin"];
            set
            {
                if (value < 0)
                    value = 0;
                //_playerData.goodsDict["Coin"] = value;
                this.SendEvent<Msg.Register.UpdateShowData>();
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }

        public int UpperPower
        {
            get => _playerData.property.UpperPower;
            set
            {
                if (value < PlayerData.LimitMinPower)
                {
                    value = PlayerData.LimitMinPower;
                    LogUtility.Log("已经到达最低体力上限值");
                }
                _playerData.property.UpperPower = value;
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int UpperHp
        {
            get => _playerData.property.UpperHp;
            set
            {
                if (value < PlayerData.LimitMinHP)
                {
                    value = PlayerData.LimitMinHP;
                    LogUtility.Log("已经到达最低生命上限值");
                    return;
                }
                _playerData.property.UpperHp = value;
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int UpperAttack
        {
            get => _playerData.property.UpperAttack;
            set
            {
                if (value < PlayerData.LimitMinAttack)
                {
                    value = PlayerData.LimitMinAttack;
                }
                _playerData.property.UpperAttack = value;
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int UpperDefence
        {
            get => _playerData.property.UpperDefence;
            set
            {
                if(value == 0)
                    return;
                if (value < PlayerData.LimitMinDefence)
                {
                    value = PlayerData.LimitMinDefence;
                }

                _playerData.property.UpperDefence = value;
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }
        public int UpperSpeed
        {
            get => _playerData.property.UpperSpeed;
            set
            {
                if (value < PlayerData.LimitMinSpeed)
                {
                    value = PlayerData.LimitMinSpeed;
                }

                _playerData.property.UpperSpeed = value;
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }

        public Dictionary<string,int> GoodsDict
        {
            get => _playerData.goodsDict ;
            set
            {
                _playerData.goodsDict = value;
                // todo 更新背包参数
                YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
            }
        }


        public void UpdateLocalData()
        {
            YJsonUtility.WriteToJson(_playerData, Msg.Paths.Config.PlayerData);
        }
        
        private bool CheckChangeDied(int value)
        {
            var tempHp = _playerData.property.Hp;
            if (tempHp <= 0 || tempHp + value <= 0)
            {
                //todo 玩家死亡
                IsDied = true;
                LogUtility.Log("玩家死亡！");
                _playerData.property.Hp = 0;
                return true;
            }

            return false;
        }   
    }
}