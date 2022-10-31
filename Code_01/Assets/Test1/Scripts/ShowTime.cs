/****************************************************
    文件：ShowTime.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine.UI;
using YFramework.Kit;

public class ShowTime : YMonoBehaviour
{
    public Text text;

    private void Update()
    {
        text.text = DateTime.Now.ToString("hh:HH:mm:ss");
    }
}