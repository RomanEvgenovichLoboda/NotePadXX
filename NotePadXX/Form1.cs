using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadXX
{
    public partial class Form1 : Form
    {
       // TabControl tabCtrl;
        MenuStrip menu;
        ToolBar tBar;
        ImageList imList;
        My_TabControl MTControl = new My_TabControl();

        ToolStripMenuItem _new;
        ToolStripMenuItem save;
        //public static OpenFileDialog OFDiaog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            MTControl.Size = ClientSize;
            //toolStripmenu
            menu = new MenuStrip();
            ToolStripMenuItem file = (ToolStripMenuItem)menu.Items.Add("File");
            ToolStripMenuItem edit = (ToolStripMenuItem)menu.Items.Add("Edit");
            //menu.Location = new Point(0,50);
            this.MainMenuStrip = menu;
            menu.BackColor = Color.BurlyWood;
            this.Controls.Add(menu);
            _new = (ToolStripMenuItem)file.DropDownItems.Add("New");
            ToolStripMenuItem open = (ToolStripMenuItem)file.DropDownItems.Add("Open");
            save = (ToolStripMenuItem)file.DropDownItems.Add("Save");
            file.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem close = (ToolStripMenuItem)file.DropDownItems.Add("Close");
            close.ShortcutKeys = Keys.Alt | Keys.C;
            close.ShowShortcutKeys = true;
            close.Click += new System.EventHandler(close_Click);
            open.Click += new System.EventHandler(open_Click);
            _new.Click += new System.EventHandler(new_Click);
            save.Click += new System.EventHandler(save_Click);

            //file.DropDownItemClicked += new ToolStripItemClickedEventHandler(file_Click);

            //tabCtrl
            //tabCtrl = new TabControl();
            ////tabCtrl.Padding = new Point(5, 10);
            //this.Controls.Add(tabCtrl);
            //this.tabCtrl.Size = this.ClientSize;
            //this.tabCtrl.Location = new Point(0, 70);
            //this.tabCtrl.Padding = new Point(20, 4);
            //this.tabCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //this.tabCtrl.Controls.Add(new C_Tab("RMZS"));
            //this.tabCtrl.Controls.Add(new C_Tab("ZBS"));
            this.Controls.Add(MTControl);
           // MTControl.TabPages.Add(new TabPage());
            //MTControl.TabPages.Add(new C_Tab("dfgdfgd"));
            //this.Controls.Add(MTControl);

            //toolBar
            imList = new ImageList();
            imList.ImageSize = new Size(30, 30);
            imList.Images.Add(new Bitmap(Properties.Resources._38));
            imList.Images.Add(new Bitmap(Properties.Resources.image2));
            imList.Images.Add(new Bitmap(Properties.Resources.image3));
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
            tBar.Location = new Point(0, 24);
            
            this.Controls.Add(tBar);
            //this.Controls.Add(new My_ToolBar());
            //this.Control.Add(OFDiaog)


        }
        void close_Click(object sender, System.EventArgs e) { this.Close(); }
        void open_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "TEXT|*.txt|ALL|*.*";
                ofd.Title = "Choose your destiny";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    MTControl.TabPages.Add(new C_Tab(ofd.SafeFileName,File.ReadAllText(ofd.FileName)));
                    this.Text = ofd.FileName;
                   
                }
            }
            
        }
        void save_Click(object sender, System.EventArgs e)
        {
           using (SaveFileDialog sfd = new SaveFileDialog())
            {
                C_Tab temp = (C_Tab)MTControl.SelectedTab;
                //sfd.FileName = temp.Text;
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, temp.tb.Text);
                }
            }
        }
        void new_Click(object sender, System.EventArgs e) { MTControl.TabPages.Add(new C_Tab()); }
    }
}


