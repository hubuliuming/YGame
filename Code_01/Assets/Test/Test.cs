/****************************************************
    文件：Test.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using Code_01;
using Code_01.Mode;
using UnityEngine;
using YFramework;

public class Test : MonoBehaviour,IController
{
    private void Start()
    {
        
    }

    public IArchitecture GetArchitecture()
    {
        return Game.Interface;
    }
}