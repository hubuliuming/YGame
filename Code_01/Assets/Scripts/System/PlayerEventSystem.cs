/****************************************************
    文件：PlayerEvent.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using Code_01.Enemy;
using Code_01.Mode;
using YFramework;

namespace Code_01.System
{
    public class PlayerEventSystem : AbstractSystem
    {
        private PlayerModel _playerModel;
        protected override void OnInit()
        {
            _playerModel = this.GetModel<PlayerModel>();
        }
    
        public void ChangeName(string newName)
        {
            if (newName == "") return;
            _playerModel.Name = newName;
        }
        public void ChangeExp(long value)
        {
            if (value == 0) return;
            _playerModel.Exp += value;
        }
        public void ChangePower(int value)
        {
            if (value == 0) return;
            _playerModel.Power += value;
        }
        public void ChangeHp(int value)
        {
            if (value == 0) return;
            _playerModel.Hp += value;
        }
        public void ChangeAttack(int value)
        {
            if (value == 0) return;
            _playerModel.Attack += value;
        }
        public void ChangeDefence(int value)
        {
            if (value == 0) return;
            _playerModel.Defence += value;
        }
        public void ChangeSpeed(int value)
        {
            if (value == 0) return;
            _playerModel.Speed += value;
        }
        public void ChangeCoin(int value)
        {
            if (value == 0) return;
            _playerModel.Coin += value;
        }
    
        public void ChangeGoodsDic(string goodsName,int num)
        {
            if (_playerModel.goodsDict.ContainsKey(goodsName))
            {
                _playerModel.goodsDict[goodsName] += num;
            }
            else
            {
                //todo bug 可能为负数取出没有的物品
                _playerModel.goodsDict.Add(goodsName,num);
            }
            _playerModel.UpdateLocalData();
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
                LogUtility.Log("经验不足升级");
            }
        }

        public void ChangeUpperPower(int value)
        {
            if (value == 0) return;
            _playerModel.UpperPower += value;
        }
        public void ChangeUpperHP(int value)
        {
            if (value == 0) return;
            _playerModel.UpperHp += value;
        }
        public void ChangeUpperAttack(int value)
        {
            if (value == 0) return;
            _playerModel.UpperAttack += value;
        }
        public void ChangeUpperDefence(int value)
        {
            if (value == 0) return;
            _playerModel.UpperDefence += value;
        }

        public void ChangeAll(ItemBase.ItemData data)
        {
            ChangePower(data.addPower);
            ChangeHp(data.addHp);
            ChangeAttack(data.addAttack);
            ChangeDefence(data.addDefence);
            ChangeSpeed(data.addSpeed);
            ChangeCoin(data.addCoin);
        }
    
        public bool EnableAttack()
        {
            if (!_playerModel.IsDied && !_playerModel.IsEmptyPower)
                return true;
            return false;
        }
    }
}