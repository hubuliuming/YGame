/****************************************************
    文件：AttackCommand.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using YFramework;

public class AttackCommand : AbstractCommand
{
    private PlayerModel _playerModel;
    private PlayerEventSystem _playerEventSystem;
    public AttackCommand(string targetName)
    {
        this.GetModel<PlayerModel>();
        this.GetSystem<PlayerEventSystem>();
    }

    public AttackCommand()
    {
        
    }

    protected override void OnExecute()
    {
       
    }
}