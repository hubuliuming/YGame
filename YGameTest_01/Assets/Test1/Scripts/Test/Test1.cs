/****************************************************
    文件：Test1.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Plastic.Newtonsoft.Json;
using Unity.VisualScripting.YamlDotNet.Serialization;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Test1 : MonoBehaviour
{
    
    public class Wood
    {
        
    }
    private float _curTime;

    private TimeSpan _timeSpan;
    [SerializeField] private Character crt;
    
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
        Deserializer des = new Deserializer();

        des.Deserialize<Dictionary<string,int>>("dsf");
    }
    
}