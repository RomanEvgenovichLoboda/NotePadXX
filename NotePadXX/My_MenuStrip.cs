using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadXX
{
    public class My_MenuStrip:MenuStrip
    {
        protected ToolStripMenuItem file;
        protected ToolStripMenuItem edit;
        public ToolStripMenuItem _new;
        public ToolStripMenuItem open;
        public ToolStripMenuItem save;
        public ToolStripMenuItem close;
        public ToolStripMenuItem font;
        public ToolStripMenuItem collor;
        public My_MenuStrip()
        {
            file = (ToolStripMenuItem)Items.Add("File");
            edit = (ToolStripMenuItem)Items.Add("Edit");
            BackColor = Color.BurlyWood;
            _new = (ToolStripMenuItem)file.DropDownItems.Add("New");
            open = (ToolStripMenuItem)file.DropDownItems.Add("Open");
            save = (ToolStripMenuItem)file.DropDownItems.Add("Save As");
            file.DropDownItems.Add(new ToolStripSeparator());
            close = (ToolStripMenuItem)file.DropDownItems.Add("Close");
            font = (ToolStripMenuItem)edit.DropDownItems.Add("Font");
            collor = (ToolStripMenuItem)edit.DropDownItems.Add("Color");
            close.ShortcutKeys = Keys.Alt | Keys.C;
            close.ShowShortcutKeys = true;
        }
    }
}
