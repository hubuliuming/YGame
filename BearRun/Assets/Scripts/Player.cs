/****************************************************
    文件：Player.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;
using YFramework;

public enum Direction
{
    None,
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
        playerAnim = GetComponent<Animation>();
        lerpVec3 = followCam.transform.position - transform.position;
    }

    private void Update()
    {
        cc.SimpleMove(Vector3.forward*speed);
        CamFollowMe();
        UpdateCurDir();
    }

    private void FixedUpdate()
    {
        //有物理效果时，改变位置操作放到Fix这里
        MovePlayerPos(curDir);
    }

    private void CamFollowMe()
    {
        followCam.transform.position = transform.position + lerpVec3;
    }

    #region 控制角色移动的方法

    private int effectiveDistance = 70;
    private Vector3 starPos = Vector3.zero;
    private bool hasDir = false;
    private Animation playerAnim;
    private Direction curDir;
    private void UpdateCurDir()
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
            if (Mathf.Abs(offset.x ) > Mathf.Abs(offset.y))
            {
                //left
                if (offset.x > effectiveDistance)
                {
                    curDir = Direction.Left;
                }
                //right
                else if (offset.x < -effectiveDistance)
                {
                    curDir = Direction.Right;
                }
            }
            //上下移动
            else
            {
                //上面
                if (offset.y < -effectiveDistance)
                {
                    curDir = Direction.Up;
                }
                else if(offset.y >effectiveDistance)
                {
                    curDir = Direction.Down;
                }
            }
        }
        //键盘输入
        if (Input.GetKeyDown(KeyCode.W))
        {
            curDir = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            curDir = Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            curDir = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            curDir = Direction.Right;
        }
    }

    private void MovePlayerPos(Direction dir)
    {
        var curPos = transform.position;
        switch (dir)
        {
            case Direction.None:
                break;
            case Direction.Up:
                break;
            case Direction.Down:
                break;
            case Direction.Left:
                if (curPos.x - 1.5 < -2.1f) return;
                Debug.Log("left");
                transform.AddLocalPosX(-2f);
                hasDir = true;
                //StartCoroutine(PlayAnimation(Consts.AnimLeftJump));
                break;
            case Direction.Right:
                if (curPos.x + 1.5 > 2.1f) return;
                Debug.Log("right");
                transform.AddLocalPosX(2f);
                //StartCoroutine(PlayAnimation(Consts.AnimRightJump));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
        }
        hasDir = true;
        curDir = Direction.None;
    }
    
    private IEnumerator PlayAnimation(string _name)
    {
        playerAnim.Play(_name);
        yield return new WaitForSeconds(Consts.AnimTime);
        playerAnim.Play(Consts.AnimRun);
    }
    
    #endregion
    
}