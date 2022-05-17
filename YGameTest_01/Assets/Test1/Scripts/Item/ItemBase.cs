/****************************************************
    文件：ItemBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using YFramework.UI;

[Serializable]
public struct ItemData
{
    public ItemBase.Names Name;
    public int AddHP;
    public int AddPower;
}

public abstract class ItemBase : UIBase,IInit
{
    public enum Names
    {
        ActiveApple,
    }
    public ItemData data;
    
    public virtual void InitOnce()
    {
    }
}