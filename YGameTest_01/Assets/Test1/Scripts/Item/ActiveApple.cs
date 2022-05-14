/****************************************************
    文件：ActiveApple.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/


public class ActiveApple : ItemBase
{
    private int _addPower = 10;
    private void Start()
    {
        UiUtility.Get("Btn").AddListener(()=>
       {
          Player.ChangePower(_addPower);
       });
    }
}