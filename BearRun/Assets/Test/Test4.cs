/****************************************************
    文件：Test4.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using YFramework;

public class Test4 : MonoBehaviour
{
    private CharacterController cc;
    private int effectiveDistance = 70;
    private Vector3 starPos = Vector3.zero;
    private bool hasDir = false;
    private Animation playerAnim;
    private Direction curDir;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdateCurDir();
        cc.Move(Vector3.forward * Time.deltaTime);
        Debug.Log(curDir);
    }

    private void FixedUpdate()
    {
        PlayerMove(curDir);
    }
    
   
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
            if (Mathf.Abs(offset.x )> Mathf.Abs(offset.y))
            {
                //left
                if (offset.x > effectiveDistance)
                {
                    //PlayerMove(Direction.Left);
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
                    //PlayerMove(Direction.Up);
                }
                else if(offset.y >effectiveDistance)
                {
                    //PlayerMove(Direction.Down);
                }
            }
        }
        //键盘输入
        if (Input.GetKeyDown(KeyCode.W))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            
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

    private void PlayerMove(Direction dir)
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
                if (transform.position.x - 1.5 < -2.1f) return;
                Debug.Log("left");
                //cc.Move(new Vector3(curPos.x - 2f, curPos.y, curPos.z));
                transform.AddLocalPosX(-2f);
                //StartCoroutine(PlayAnimation(Consts.AnimLeftJump));
                break;
            case Direction.Right:
                if (transform.position.x + 1.5 > 2.1f) return;
                Debug.Log("right");
                //cc.Move(new Vector3(curPos.x + 2f, curPos.y, curPos.z));
                transform.AddLocalPosX(2f);
                //StartCoroutine(PlayAnimation(Consts.AnimRightJump));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
        }

        curDir = Direction.None;
        hasDir = true;
    }
}