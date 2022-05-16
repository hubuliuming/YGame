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
    private PlayerData _playerData;
    private Text _showText;
    public override void Init()
    {
        _playerData = GameManager.Instance.PlayerData;
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
        _showText.text = ("昵称：" + _playerData.Name + 
         "\n\n生命："+_playerData.HP +
         "\n\n体力："+_playerData.Power+
         "\n\n攻击力："+_playerData.Attack+
         "\n\n防御力："+_playerData.Defence+
         "\n\n速度："+_playerData.Speed+
         "\n\n金币："+_playerData.Coin);
    }
}