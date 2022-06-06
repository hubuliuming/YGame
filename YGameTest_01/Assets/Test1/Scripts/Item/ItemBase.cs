/****************************************************
    文件：ItemBase.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using YFramework;
using YFramework.UI;

[Serializable]
public struct ItemData
{
    public string name;
    public int addHp;
    public int addPower;
    public int addAttack;
    public int addDefence;
    public int addSpeed;
    public int addCoin;
}

public abstract class ItemBase : UIBase,IInit
{
    public enum Names
    {
        ActiveApple,
    }
    protected ItemData _data;
    protected Player _player;
    
    public virtual void InitOnce()
    {
        _player = GameManager.Instance.player;
        var datas = YJsonUtility.ReadFromJson<ItemData[]>(Paths.RecoverItemConfig);
        foreach (var i in datas)
        {
            
        }
    }
}