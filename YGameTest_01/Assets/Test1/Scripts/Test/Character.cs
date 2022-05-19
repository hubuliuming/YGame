/****************************************************
    文件：Character.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Canshu
{
    public int hp;
    public int power;
}
[CreateAssetMenu]
public class Character : ScriptableObject
{

    public List<Canshu> canshus;
    private void Reset()
    {
        canshus = new List<Canshu>();
        canshus.Add(new Canshu(){hp = 100,power = 10});
    }
}