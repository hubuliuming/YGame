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
    public static void Log(object message)
    {
        Debug.Log(message);
        
    }
    public static void LogWarning(object message)
    {
        Debug.LogWarning(message);
    }

    public static void LogError(object message)
    {
        Debug.LogError(message);
    }
}