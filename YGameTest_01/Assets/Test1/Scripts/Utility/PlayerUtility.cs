/****************************************************
    文件：DataManager.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/


public class PlayerUtility
{
    private static GameManager _gm = GameManager.Instance;
    public static void ChangePower(int value) => _gm.ChangePower(value);
    public static void ChangeHP(int value) => _gm.ChangeHP(value);
    public static void ChangeAttack(int value) => _gm.ChangeAttack(value);
    public static void ChangeDefence(int value) => _gm.ChangeDefence(value);
    public static void ChangeSpeed(int value) => _gm.ChangeSpeed(value);
    public static void ChangeCoin(int value) => _gm.ChangeCoin(value);
}