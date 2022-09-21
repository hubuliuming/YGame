/****************************************************
    文件：LogSystem.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using YFramework;

public interface ILogSystem : ISystem
{
    void Log(object message);
    void LogWarning(object message);
    void LogError(object message);
}

public class LogSystem : AbstractSystem,ILogSystem 
{
    protected override void OnInit()
    {
        
    }

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