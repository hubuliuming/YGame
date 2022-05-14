/****************************************************
    文件：RegisterMsg.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class RegisterMsg : MonoBehaviour
{
    public const string PlayerAttack = "PlayerAttack";
    public const string UpdateShowData = "UpdateShowData";
}

public class AttackDataPack
{
    public int Attack;
    public int Defence;
}