/****************************************************
    文件：DropSystem.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：物品掉落系统
*****************************************************/


using System.Collections.Generic;
using Random = UnityEngine.Random;

public class DropSystem 
{
    public static Dictionary<string, int> GetGoods(string goodsName, int num)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        dic.Add(goodsName,num);
        return dic;
    }
    public static Dictionary<string,int> GetRangeGoods(string goodsName,int min,int max)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        var num = Random.Range(min, max);
        dic.Add(goodsName,num);
        return dic;
    }
    
  
}