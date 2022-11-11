/****************************************************
    文件：AttackCommand.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using Code_01.Enemy;
using Code_01.Mode;
using Code_01.System;
using UnityEngine;
using YFramework;

namespace Code_01.Command
{
    public class AttackCommand : AbstractCommand
    {
        private PlayerModel _playerModel;
        private PlayerEventSystem _playerEventSystem;
        private EnemyBase.EnemyData _data;
        private GameObject _curObj;
        public AttackCommand(){}

        public AttackCommand(GameObject obj)
        {
            this._curObj = obj;
            this._data = obj.GetComponent<EnemyBase>().data;
        }

        protected override void OnExecute()
        {
            _playerModel = this.GetModel<PlayerModel>();
            _playerEventSystem = this.GetSystem<PlayerEventSystem>();
            if (!_playerEventSystem.EnableAttack())
            {
                Debug.Log("玩家已经死亡或者体力不足");
                return;
            }
            _playerEventSystem.ChangePower(-_data.CostPower);
            AttackPlayer();
            Debug.Log("战斗结果:" + AttackResult());
            //死亡奖励
            if (AttackResult())
            {
                WinAward();
                _curObj.Release();
            }
        }
    
        private void WinAward()
        {
            Dictionary<string, int> goodsDic= new Dictionary<string, int>();
            _playerEventSystem.ChangeExp(_data.award.Exp);
            _playerEventSystem.ChangeCoin(_data.award.Coin);
            //todo 数值要优化为配置
            goodsDic = DropSystem.GetRangeGoods(_data.award.GoodsName,1,3);
            foreach (var i in goodsDic)
            {
                _playerEventSystem.ChangeGoodsDic(i.Key,i.Value);
                Debug.Log("战利品为经验值:"+_data.award.Exp+",金币:"+_data.award.Coin+",物品为:"+i.Value+"个"+i.Key);
            }
        }
    
        private void AttackPlayer()
        {
            int playerHp = _playerModel.Hp;
            while (_data.HP > 0 && playerHp > 0)
            {
                //玩家先手
                if (_playerModel.Speed >= _data.Speed)
                {
                    _data.HP -= AttackMath.AttackValue(_playerModel.Attack, _data.Defence); 
                    playerHp -= AttackMath.AttackValue(_data.Attack, _playerModel.Defence);
                }
                else
                {
                    playerHp -= AttackMath.AttackValue(_data.Attack, _playerModel.Defence);
                    _data.HP -= AttackMath.AttackValue(_playerModel.Attack, _data.Defence);
                }
            }
            //当前的HP - 计算战斗后剩余的playerHP，得到改变的HP
            _playerEventSystem.ChangeHp(-(_playerModel.Hp - playerHp));
        }
        private bool AttackResult()
        {
            if (_data.HP <= 0)
                return true;
            return false;
        }
    }
}