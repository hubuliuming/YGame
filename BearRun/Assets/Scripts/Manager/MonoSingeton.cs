/****************************************************
    文件：MonoSingeton.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class MonoSingeton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T instance;

    public static T Instance => instance;

    private void Awake()
    {
        instance = this as T;
    }
}