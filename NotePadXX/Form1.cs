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
        ToolTip tTip = new ToolTip();
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
            this.BackColor = Color.DarkSeaGreen;
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
            save = (ToolStripMenuItem)file.DropDownItems.Add("Save As");
            file.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem close = (ToolStripMenuItem)file.DropDownItems.Add("Close");
            ToolStripMenuItem font = (ToolStripMenuItem)edit.DropDownItems.Add("Font");
            ToolStripMenuItem collor = (ToolStripMenuItem)edit.DropDownItems.Add("Color");
            close.ShortcutKeys = Keys.Alt | Keys.C;
            close.ShowShortcutKeys = true;
            close.Click += new System.EventHandler(close_Click);
            open.Click += new System.EventHandler(open_Click);
            _new.Click += new System.EventHandler(new_Click);
            save.Click += new System.EventHandler(save_Click);

            //file.DropDownItemClicked += new ToolStripItemClickedEventHandler(file_Click);

            //tabCtrl

            this.Controls.Add(MTControl);
           ;

            //toolBar
            imList = new ImageList();
            imList.ImageSize = new Size(30, 30);
            imList.Images.Add(new Bitmap(Properties.Resources.application_add));
            imList.Images.Add(new Bitmap(Properties.Resources.drive_disk));
            imList.Images.Add(new Bitmap(Properties.Resources.information));
            tBar = new ToolBar();
            tBar.ImageList = imList;
            ToolBarButton toolBarButton1 = new ToolBarButton();
            ToolBarButton toolBarButton2 = new ToolBarButton();
            ToolBarButton toolBarButton3 = new ToolBarButton();
            ToolBarButton tbSeparator = new ToolBarButton();
            tbSeparator.Style = ToolBarButtonStyle.Separator;
            toolBarButton1.ImageIndex = 0;
            toolBarButton1.ToolTipText = "Open";
            toolBarButton2.ImageIndex = 1;
            toolBarButton2.ToolTipText = "Save";
            toolBarButton3.ImageIndex = 2;
            toolBarButton3.ToolTipText = "Info";
            tBar.Buttons.Add(toolBarButton1);
            tBar.Buttons.Add(tbSeparator);
            tBar.Buttons.Add(toolBarButton2);
            tBar.Buttons.Add(tbSeparator);
            tBar.Buttons.Add(toolBarButton3);
            tBar.Appearance = ToolBarAppearance.Flat;
            tBar.BorderStyle = BorderStyle.Fixed3D;
            tBar.Location = new Point(0, 24);
            tBar.ButtonClick += new ToolBarButtonClickEventHandler(tBar_ButtonClick);
            this.Controls.Add(tBar);
            
            //this.Controls.Add(new My_ToolBar());
            //this.Control.Add(OFDiaog)


        }
        void tBar_ButtonClick(object sender,ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.ImageIndex)
            {
                case 0:
                    open_Click(sender, e);
                    break;
                case 1:
                    save_Click(sender, e);
                    break;
                case 2:
                    MessageBox.Show("Экзамен(WinForms)\nСтудент - Лобода Р.Е.");
                    break;
                default:
                    break;
            }

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
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    C_Tab temp = (C_Tab)MTControl.SelectedTab;
                    sfd.Filter = "TEXT|*.txt|ALL|*.*";
                    sfd.Title = "Choose your destiny";
                    //sfd.FileName = temp.Text;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, temp.tb.Text);
                    }
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }

        }
        void new_Click(object sender, System.EventArgs e) { MTControl.TabPages.Add(new C_Tab()); }
    }
}


