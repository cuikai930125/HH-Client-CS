using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace HHMES.Core
{
    /// <summary>
    /// 菜单管理辅助工具
    /// </summary>
    public class MenuStripUtils
    {
        /// <summary>
        /// 跟据菜单标题在主菜单中查找出菜单项
        /// </summary>
        /// <param name="mainMenu">主菜单</param>
        /// <param name="text">菜单标题</param>
        /// <returns></returns>
        public static ToolStripMenuItem FindMenuItemByText(MenuStrip mainMenu, string text)
        {
            foreach (ToolStripMenuItem item in mainMenu.Items)
                if (item.Text == text) return (ToolStripMenuItem)item;
            return null;
        }

        /// <summary>
        /// 是否有子菜單.
        /// </summary>
        public static bool IsSubMenuOwner(ToolStripItem item)
        {
            if (item is ToolStripMenuItem)
            {
                if (((ToolStripMenuItem)item).DropDownItems.Count > 0)
                    return true;
            }
            return false;
        }
    }
}
