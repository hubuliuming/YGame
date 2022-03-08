/****************************************************
    文件：Player.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5;
    private Vector3 lerpVec3;
    public Camera followCam;
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        lerpVec3 = followCam.transform.position - transform.position;
    }

    private void Update()
    {
        CamFollowMe();
        Move();
    }
    
    private void Move()
    {
        cc.SimpleMove(Vector3.forward*speed);
    }

    private void CamFollowMe()
    {
        followCam.transform.position = transform.position + lerpVec3;
    }
    
}