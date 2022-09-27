/****************************************************
    文件：LogUtility.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using YFramework;

public class LogUtility : IUtility
{
    public void Log(object message)
    {
        Debug.Log(message);
        
    }
    public void LogWarning(object message)
    {
        Debug.LogWarning(message);
    }

    public void LogError(object message)
    {
        Debug.LogError(message);
    }
}