/****************************************************
    文件：Test3.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class Test3 : MonoBehaviour 
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<CharacterController>().SimpleMove(Vector3.forward);
        }
        
    }
}