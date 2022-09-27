/****************************************************
    文件：Game.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using YFramework;

public class Game : Architecture<Game>
{
    protected override void Init()
    {
        RegisterModel<IPlayerModel>(new PlayerModel());
        RegisterUtility(new LogUtility());
        RegisterModel(new GoodsModel());
        RegisterSystem(new FactoryUISystem());
        RegisterSystem<IPlayerEventSystem>(new PlayerEventSystem());
    }
}