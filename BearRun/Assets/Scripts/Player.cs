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
    private float MaxSpeed;
    public float Speed
    {
        get
        {
            
            return speed;
        }
        set
        {
            if (speed >=Consts.MaxMoveSpeed)
            {
                speed = Consts.MaxMoveSpeed;
            }
            else
            {
                speed = value;
            }
        }
    }

    private Vector3 camelerpPlayer;
    public Camera followCam;
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        playerAnim = GetComponent<Animation>();
        camelerpPlayer = followCam.transform.position - transform.position;
    }

    private void Update()
    {
        AllMove();
        CamFollowMe();
        UpdateCurDir();
        UpdateSpeed();
        Debug.Log(Speed);
    }

    private void FixedUpdate()
    {
        //有物理效果时，改变位置操作放到Fix这里
        MovePlayerPos(curDir);
    }

    private void CamFollowMe()
    {
        followCam.transform.position = transform.position + camelerpPlayer;
    }

    #region 控制角色移动的方法

    private float gravity = 9.8f;
    private int effectiveDistance = 80;
    private float moveY = 0f;
    private Vector3 starPos = Vector3.zero;
    private bool hasDir = false;
    private Animation playerAnim;
    private Direction curDir;
    
    private void AllMove()
    {
        if (moveY !=0)
        {
            //模拟重力上跳下降
            moveY -= gravity * Time.deltaTime;
        }
        cc.Move(new Vector3(0,moveY,1) * Time.deltaTime * Speed);
    }
    
    private void UpdateCurDir()
    {
        Vector3 curPos = Vector3.zero;
        if (Input.GetMouseButtonDown(0) && !hasDir)
        {
            starPos = Input.mousePosition;
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
                moveY = 1.5f;
                StartCoroutine(PlayAnimation(Consts.AnimJump));
                break;
            case Direction.Down:
                StartCoroutine(PlayAnimation(Consts.AnimRoll));
                break;
            case Direction.Left:
                if (curPos.x - 1.5 < -2.1f) return;
                transform.AddLocalPosX(-2f);
                StartCoroutine(PlayAnimation(Consts.AnimLeftJump));
                break;
            case Direction.Right:
                if (curPos.x + 1.5 > 2.1f) return;
                transform.AddLocalPosX(2f);
                StartCoroutine(PlayAnimation(Consts.AnimRightJump));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
        }
        curDir = Direction.None;
    }
    
    private IEnumerator PlayAnimation(string _name)
    {
        hasDir = true;
        playerAnim.Play(_name);
        yield return new WaitForSeconds(Consts.AnimTime);
        playerAnim.Play(Consts.AnimRun);
        moveY = 0;
        transform.SetLocalPosY(0.215f);
        hasDir = false;
    }

    private void UpdateSpeed()
    {
        if (transform.position.z> 0 && Speed < Consts.MaxMoveSpeed)
        {
            Speed += Time.deltaTime;
        }
    }
    
    #endregion
    
}