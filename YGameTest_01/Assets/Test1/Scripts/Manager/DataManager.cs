/****************************************************
    文件：DataManager.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;

public class DataManager : NormalSingleton<DataManager>
{
    private PlayerData _playerData = new PlayerData();

    public void ChangePower(int value)
    {
        _playerData.Power += value;
    }
}