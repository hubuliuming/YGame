/****************************************************
    文件：MsgDispatcher.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：消息机制单例
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public class MsgDispatcher
{
    static Dictionary<string, Action<object>> mRegisteredMsgs = new Dictionary<string, Action<object>>();

    public static void Register(string msgName, Action<object> onMsgReceived)
    {
        if (!mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs.Add(msgName, _ => { });
        }

        mRegisteredMsgs[msgName] += onMsgReceived;
    }

    public static void UnRegisterAll(string msgName)
    {
        mRegisteredMsgs.Remove(msgName);
    }

    public static void UnRegister(string msgName, Action<object> onMsgReceived)
    {
        if (mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs[msgName] -= onMsgReceived;
        }
    }

    public static void Send(string msgName, object data)
    {
        if (mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs[msgName](data);
        }
    }
}