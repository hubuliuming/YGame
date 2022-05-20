/****************************************************
    文件：PlayerDataUI.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine.UI;
using YFramework;
using YFramework.UI;

public class PlayerDataUI : UIBase
{
    private Text _showText;
    private Player _player;
    public override void Init()
    {
        _player = GameManager.Instance.player;
        _showText = UiUtility.Get("Text").Text;
        UpdateShow();
        MsgDispatcher.Register(RegisterMsg.UpdateShowData,o=>UpdateShow());
    }

    private void OnDestroy()
    {
        MsgDispatcher.UnRegister(RegisterMsg.UpdateShowData);
    }

    public void UpdateShow()
    {
        _showText.text = ("昵称：" + _player.Name + 
         "\n\n生命："+_player.HP +
         "\n\n体力："+_player.Power+
         "\n\n攻击力："+_player.Attack+
         "\n\n防御力："+_player.Defence+
         "\n\n速度："+_player.Speed+
         "\n\n金币："+_player.Coin);
    }
}