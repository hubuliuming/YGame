/****************************************************
    文件：UseItemCommand.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using Code_01.System;
using YFramework;

namespace Code_01.Command
{
    public class UseItemCommand : AbstractCommand
    {
        private ItemBase.ItemData _data;
        public UseItemCommand(){}
        public UseItemCommand(ItemBase.ItemData data)
        {
            this._data = data;
        }
        protected override void OnExecute()
        {
            this.GetSystem<PlayerEventSystem>().ChangeAll(_data);
        }
    }
}