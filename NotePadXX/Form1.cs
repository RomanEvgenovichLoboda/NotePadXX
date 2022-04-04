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
        TabControl tabCtrl;
        MenuStrip menu;
        ToolBar tBar;
        ImageList imList;
        public Form1()
        {
            InitializeComponent();

            //menuStrip
            menu = new MenuStrip();
            ToolStripMenuItem file = (ToolStripMenuItem)menu.Items.Add("File");
            ToolStripMenuItem edit = (ToolStripMenuItem)menu.Items.Add("Edit");
            //menu.Location = new Point(100,100);
            this.MainMenuStrip = menu;
            menu.BackColor = Color.Coral;
            this.Controls.Add(menu);
            file.DropDownItems.Add("New");
            file.DropDownItems.Add("Open");
            file.DropDownItems.Add("Save");
            file.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem close = (ToolStripMenuItem)file.DropDownItems.Add("Close");
            close.ShortcutKeys = Keys.Alt | Keys.C;
            close.ShowShortcutKeys = true;
            close.Click += new System.EventHandler(close_Click);
            file.DropDownItemClicked += new ToolStripItemClickedEventHandler(file_Click);

            //tabCtrl
            tabCtrl = new TabControl();
            //tabCtrl.Padding = new Point(5, 10);
            this.Controls.Add(tabCtrl);
            this.tabCtrl.Size = this.ClientSize;
            this.tabCtrl.Location = new Point(5, 70);

            this.tabCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tabCtrl.Controls.Add(new C_Tab("RMZS"));
            this.tabCtrl.Controls.Add(new C_Tab("ZBS"));

            //toolBar
            imList = new ImageList();
            imList.ImageSize = new Size(30, 30);
            imList.Images.Add(new Bitmap("38.JPG"));
            imList.Images.Add(new Bitmap("disk.PNG"));
            imList.Images.Add(new Bitmap("image3.JPG"));
            tBar = new ToolBar();
            tBar.ImageList = imList;
            ToolBarButton toolBarButton1 = new ToolBarButton();
            ToolBarButton toolBarButton2 = new ToolBarButton();
            ToolBarButton toolBarButton3 = new ToolBarButton();
            ToolBarButton tbSeparator = new ToolBarButton();
            tbSeparator.Style = ToolBarButtonStyle.Separator;
            toolBarButton1.ImageIndex = 0;
            toolBarButton2.ImageIndex = 1;
            toolBarButton3.ImageIndex = 2;
            tBar.Buttons.Add(toolBarButton1);
            tBar.Buttons.Add(tbSeparator);
            tBar.Buttons.Add(toolBarButton2);
            tBar.Buttons.Add(tbSeparator);
            tBar.Buttons.Add(toolBarButton3);
            tBar.Appearance = ToolBarAppearance.Flat;
            tBar.BorderStyle = BorderStyle.Fixed3D;
            //tBar.Location = new Point(50, 50);
            this.Controls.Add(tBar);
           


        }
        void close_Click(object sender, System.EventArgs e) { this.Close(); }
        void file_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("BORODA");
        }
    }
}


