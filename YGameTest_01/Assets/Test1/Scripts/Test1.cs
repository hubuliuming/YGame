/****************************************************
    文件：Test1.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Test1 : MonoBehaviour
{
    private float _curTime;

    private TimeSpan _timeSpan;
    
    private void Start()
    {
        // Stopwatch t = new Stopwatch();
        // t.Start();
        // t.Stop();
        // t.Elapsed 
        
        //Debug.Log(DateTime.Now.ToString("yyyyMMddHHmmss"));
        //Debug.Log(DateTime.Now.ToString());

        string str = "1221";
        var upstr = str.Substring(0, str.Length / 2);
        var downstr = str.Substring(str.Length / 2);
        
        Debug.Log(upstr); 
        Debug.Log(downstr);
    }

    private void Update()
    {
        
    }
}