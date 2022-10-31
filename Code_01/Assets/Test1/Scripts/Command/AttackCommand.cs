/****************************************************
    文件：AttackCommand.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using YFramework;

public class AttackCommand : AbstractCommand
{
    private PlayerModel _playerModel;
    private PlayerEventSystem _playerEventSystem;
    private FactoryUISystem _factoryUISystem;
    private EnemyModel.EnemyData _data;
    public AttackCommand(EnemyModel.EnemyData data)
    {
        this._playerModel = this.GetModel<PlayerModel>();
        this._playerEventSystem = this.GetSystem<PlayerEventSystem>();
        this._factoryUISystem = this.GetSystem<FactoryUISystem>();
        this._data = data;
    }

    public AttackCommand()
    {
        
    }

    protected override void OnExecute()
    {
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
            //Player.ChangeCoin(data.awrd.Coin,false);
            WinAward();
        }
        //_factoryUISystem.GetPool(_data.Name).Release(gameObject);
        //MsgDispatcher.Send(Msg.MsgRegister.UpdateShowData);
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
        int playerHP = _playerModel.HP;
        while (_data.HP > 0 && playerHP > 0)
        {
            //玩家先手
            if (_playerModel.Speed >= _data.Speed)
            {
                _data.HP -= AttackMath.AttackValue(_playerModel.Attack, _data.Defence); 
                playerHP -= AttackMath.AttackValue(_data.Attack, _playerModel.Defence);
            }
            else
            {
                playerHP -= AttackMath.AttackValue(_data.Attack, _playerModel.Defence);
                _data.HP -= AttackMath.AttackValue(_playerModel.Attack, _data.Defence);
            }
        }
        //当前的HP - 计算战斗后剩余的playerHP，得到改变的HP
        _playerEventSystem.ChangeHP(-(_playerModel.HP - playerHP));
    }
    private bool AttackResult()
    {
        if (_data.HP <= 0)
            return true;
        return false;
    }
}