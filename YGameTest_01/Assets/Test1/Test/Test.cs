/****************************************************
    文件：Test.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using YFramework;

public class Test : MonoBehaviour,IController
{
    private void Start()
    {
        var playerModel = this.GetModel<IPlayerModel>();
        Debug.Log(playerModel.HP);
    }

    public IArchitecture GetArchitecture()
    {
        return Game.Interface;
    }
}