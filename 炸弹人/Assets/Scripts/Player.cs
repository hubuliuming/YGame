/****************************************************
    文件：Player.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 30;
    private Rigidbody2D rig;
    public Transform gameTrans;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(new Vector2(-speed * Time.deltaTime ,0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(new Vector2(speed * Time.deltaTime,0));
        } 
        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(new Vector2(0 ,speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(new Vector2(0 ,-speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBoom();
        }
    }

    private void CreateBoom()
    {
        var boomPreb = Resources.Load<GameObject>("Prefabs/Boom");
        var boom = Instantiate(boomPreb,gameTrans);
        boom.transform.position = transform.position;
    }
}