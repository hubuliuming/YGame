/****************************************************
    文件：PlayerDataUI.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine.UI;
using YFramework;
using YFramework.Kit;
using YFramework.Kit.UI;

public class PlayerDetails : UIBase,IController
{
    private Text _showText;
    private Player _player;
    
    public  void Init()
    {
        _showText = UiUtility.Get("Text").Text;
        UpdateShow();
        Register();
    }
    
    public void Register()
    {
        MsgDispatcher.Register(Msg.MsgRegister.UpdateShowData,o=>UpdateShow());
    }

    public void UnRegister()
    {
        MsgDispatcher.UnRegister(Msg.MsgRegister.UpdateShowData);
    }
    
    public void UpdateShow()
    {
        _showText.text = ("昵称：" + _player.Name + 
         "\n\n等级："+_player.Level +
         "\n\n经验："+_player.Exp +
         "\n\n生命："+_player.HP +
         "\n\n体力："+_player.Power+
         "\n\n攻击力："+_player.Attack+
         "\n\n防御力："+_player.Defence+
         "\n\n速度："+_player.Speed+
         "\n\n金币："+_player.Coin);
    }

    public IArchitecture GetArchitecture()
    {
        return Game.Interface;
    }
}