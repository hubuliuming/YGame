/****************************************************
    文件：GameManager.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public int coinRate { get; set; }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(Consts.SceneGame);
    }
}