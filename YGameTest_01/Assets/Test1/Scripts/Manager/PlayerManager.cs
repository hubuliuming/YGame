/****************************************************
    文件：GameManager.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using YFramework;

public class PlayerManager :ManagerBase<PlayerManager>
{
    public Player player;
    //private List<IMono> _monoList;
    public override void Init()
    {
        base.Init();
        //_monoList = new List<IMono>();
        
    }
    

    public override void Release()
    {
        base.Release();
    }
}