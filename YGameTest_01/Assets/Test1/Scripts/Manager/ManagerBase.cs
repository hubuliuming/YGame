/****************************************************
    文件：ManagerBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using Codice.CM.Common;
using UnityEngine;

public abstract class ManagerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance;
    public virtual void Init()
    {
        DontDestroyOnLoad(this);
        Instance = this as T;
    }

    public virtual void Release()
    {
        Instance = null;
    }
}