/****************************************************
    文件：Test.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Test1 : MonoBehaviour
{ 
    private ObjectPool<GameObject> roadsPool;
    private GameObject road1Go;
    private List<GameObject> goList = new List<GameObject>();

    private void Start()
    {
        road1Go = Resources.Load<GameObject>("Prefabs/road1");
        roadsPool = new ObjectPool<GameObject>(Create,OnGet,OnRelease);
        
    }
    

    private GameObject Create()
    {
        return Instantiate(road1Go);
    }

    private void OnGet(GameObject go)
    {
        go.SetActive(true);
        go.transform.position = Vector3.forward;
    }

    private void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
         
    }
}