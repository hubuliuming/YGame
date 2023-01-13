/****************************************************
    文件：Game.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using Code_01.Mode;
using Code_01.System;
using YFramework;

namespace Code_01
{
    public class Game : Architecture<Game>
    {
        protected override void Init()
        {
            RegisterModel(new PlayerModel());
            RegisterUtility(new LogUtility());
            RegisterModel(new GoodsModel());
            RegisterSystem(new FactoryUISystem());
            RegisterSystem(new PlayerEventSystem());
        }
    }
}