/****************************************************
    文件：ItemBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework.UI;

public abstract class ItemBase : UIBase,IInit
{
    public virtual void InitFirst()
    {
        InitData();
    }

    public abstract void InitData();
}