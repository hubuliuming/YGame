/****************************************************
    文件：Player.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
public class Player : MonoBehaviour
{
    private float speed = 10;
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
        GetCurDir();
    }
    
    private void Move()
    {
        cc.SimpleMove(Vector3.forward*speed);
    }

    private void CamFollowMe()
    {
        followCam.transform.position = transform.position + lerpVec3;
    }

    #region 控制角色移动的方法

    private int effectiveDistance = 70;
    private Vector3 starPos = Vector3.zero;
    private bool hasDir = false;
    private void GetCurDir()
    {
        Vector3 curPos = Vector3.zero;
        if (Input.GetMouseButtonDown(0) && !hasDir)
        {
            starPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            hasDir = false;
        }

        if (Input.GetMouseButton(0) && !hasDir)
        { 
            curPos = Input.mousePosition;
            var offset = (Vector2)(starPos - curPos);
            // 左右移动
            if (Mathf.Abs(offset.x )> Mathf.Abs(offset.y))
            {
                //left
                if (offset.x > effectiveDistance)
                {
                    Debug.Log("left");
                    hasDir = true;
                }
                //right
                else if (offset.x < -effectiveDistance)
                {
                    Debug.Log("Right");
                    hasDir = true;
                }
                
            }
            //上下移动
            else
            {
                //上面
                if (offset.y < -effectiveDistance)
                {
                    Debug.Log("Up");
                    hasDir = true;
                }
                else if(offset.y >effectiveDistance)
                {
                    Debug.Log("Down");
                    hasDir = true;
                }
            }
        }
        
    }
    #endregion
    
}