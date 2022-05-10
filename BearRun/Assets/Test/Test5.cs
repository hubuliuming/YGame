/****************************************************
    文件：Test5.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Test5 : MonoBehaviour
{
    private CharacterController cc;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Debug.Log(cc.isGrounded);
    }
}