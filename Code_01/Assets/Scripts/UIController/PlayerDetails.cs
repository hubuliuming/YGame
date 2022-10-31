/****************************************************
    文件：PlayerDataUI.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using Code_01.Mode;
using UnityEngine.UI;
using YFramework;
using YFramework.Kit.UI;

namespace Code_01.Controller
{
    public class PlayerDetails : UIBase,IController
    {
        private Text _showText;
        private PlayerModel _playerModel;
    
        public void Init()
        {
            _showText = UiUtility.Get("Text").Text;
            _playerModel = this.GetModel<PlayerModel>();
            this.RegisterEvent<Msg.Register.UpdateShowData>(o => UpdateShow());
            UpdateShow();
        }
    
    
        public void UpdateShow()
        {
            _showText.text = ("昵称：" + _playerModel.Name + 
                              "\n\n等级："+_playerModel.Level +
                              "\n\n经验："+_playerModel.Exp +
                              "\n\n生命："+_playerModel.Hp +
                              "\n\n体力："+_playerModel.Power+
                              "\n\n攻击力："+_playerModel.Attack+
                              "\n\n防御力："+_playerModel.Defence+
                              "\n\n速度："+_playerModel.Speed+
                              "\n\n金币："+_playerModel.Coin);
        }

        public IArchitecture GetArchitecture()
        {
            return Game.Interface;
        }
    }
}