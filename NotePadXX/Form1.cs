using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadXX
{
    public partial class Form1 : Form
    {
        TabControl tabCtrl = new TabControl();
        MenuStrip menu;
        
        
        
        public Form1()
        {
            InitializeComponent();

            ////menuStrip
            menu = new MenuStrip();
            ToolStripMenuItem file = (ToolStripMenuItem)menu.Items.Add("File");
            ToolStripMenuItem edit = (ToolStripMenuItem)menu.Items.Add("Edit");
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);
            file.DropDownItems.Add("New");
            file.DropDownItems.Add("Open");
            file.DropDownItems.Add("Save");
            file.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem close = (ToolStripMenuItem)file.DropDownItems.Add("Close");
            close.ShortcutKeys = Keys.Alt | Keys.C;
            close.ShowShortcutKeys = true;
            close.Click += new System.EventHandler(close_Click);

            //tabCtrl
            this.Controls.Add(tabCtrl);
            this.tabCtrl.Size = this.ClientSize;
            this.tabCtrl.Location = new Point(5, 20);
            this.tabCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tabCtrl.Controls.Add(new C_Tab("RMZS"));
            this.tabCtrl.Controls.Add(new C_Tab("ZBS"));
        }
        void close_Click(object sender, System.EventArgs e) { this.Close(); }
    }
}


