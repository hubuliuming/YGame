/****************************************************
    文件：StartGame.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using YFramework;

public class StartGame : MonoBehaviour 
{
    private void Start()
    {
        GameManager.Instance.InitPlayer();
        //GameManager.Instance.ReloadJsonData();
        // var prefab = Resources.Load<GameObject>(Paths.WildBoar);
        // var go =Instantiate(prefab, transform);
        
        var wildBoarPool = EnemyFactory.Get(EnemyName.WildBoar);
        var go = wildBoarPool.Get();
        go.transform.SetParent(transform);
        go.transform.localPosition =Vector3.zero;
    }
}