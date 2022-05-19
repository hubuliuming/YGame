/****************************************************
    文件：YJsonUtility.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Json信息存储操作，注意需要序列化的数据
*****************************************************/

using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace YFramework
{
    public static class YJsonUtility 
    {
        public static void WriteToJson<T>(T data,string savePath)
        {
            if (!savePath.EndsWith(".json"))
                savePath += ".json";
            var jsonStr =JsonConvert.SerializeObject(data);
            StreamWriter sw = new StreamWriter(savePath);
            var str = jsonStr.Split(",");
            for (int i = 0; i < str.Length -1; i++)
            {
                sw.WriteLine(str[i] + ",");
            }
            sw.Write(str[str.Length-1]);
            sw.Close();
        }

        public static T ReadFromJson<T>(string path) 
        {
            if (!path.EndsWith(".json"))
                path += ".json"; 
            StreamReader sr = new StreamReader(path);
            var data = sr.ReadToEnd(); 
            sr.Close();
            return JsonConvert.DeserializeObject<T>(data);
        }

    }
}