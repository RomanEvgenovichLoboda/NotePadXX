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
        My_MenuStrip menu;
        ToolBar tBar;
        ImageList imList;
        My_TabControl MTControl = new My_TabControl();
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.DarkSeaGreen;
     //toolStripmenu
            menu = new My_MenuStrip();
            menu.close.Click += new System.EventHandler(close_Click);
            menu.open.Click += new System.EventHandler(open_Click);
            menu._new.Click += new System.EventHandler(new_Click);
            menu.save.Click += new System.EventHandler(save_Click);
            menu.font.Click += new System.EventHandler(font_ButtonClick);
            menu.collor.Click += new System.EventHandler(color_ButtonClick);
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);
            MTControl.Size = ClientSize;
            this.Controls.Add(MTControl);
     //toolBar
            imList = new ImageList();
            imList.ImageSize = new Size(30, 30);
            imList.Images.Add(new Bitmap(Properties.Resources.application_add));
            imList.Images.Add(new Bitmap(Properties.Resources.drive_disk));
            imList.Images.Add(new Bitmap(Properties.Resources.resultset_previous));
            imList.Images.Add(new Bitmap(Properties.Resources.resultset_next));
            imList.Images.Add(new Bitmap(Properties.Resources.cut));
            imList.Images.Add(new Bitmap(Properties.Resources.paste_word));
            imList.Images.Add(new Bitmap(Properties.Resources.contrast_high));
            imList.Images.Add(new Bitmap(Properties.Resources.information));
            tBar = new ToolBar();
            tBar.ImageList = imList;
            ToolBarButton toolBarButton1 = new ToolBarButton();
            ToolBarButton toolBarButton2 = new ToolBarButton();
            ToolBarButton toolBarButton3 = new ToolBarButton();
            ToolBarButton toolBarButton4 = new ToolBarButton();
            ToolBarButton toolBarButton5 = new ToolBarButton();
            ToolBarButton toolBarButton6 = new ToolBarButton();
            ToolBarButton toolBarButton7 = new ToolBarButton();
            ToolBarButton toolBarButton8 = new ToolBarButton();
            ToolBarButton tbSeparator = new ToolBarButton();
            tbSeparator.Style = ToolBarButtonStyle.Separator;
            toolBarButton1.ImageIndex = 0;
            toolBarButton1.ToolTipText = "Open";
            toolBarButton2.ImageIndex = 1;
            toolBarButton2.ToolTipText = "Save";
            toolBarButton3.ImageIndex = 2;
            toolBarButton3.ToolTipText = "Redo";
            toolBarButton4.ImageIndex = 3;
            toolBarButton4.ToolTipText = "Undo";
            toolBarButton5.ImageIndex = 4;
            toolBarButton5.ToolTipText = "Cut";
            toolBarButton6.ImageIndex = 5;
            toolBarButton6.ToolTipText = "Paste";
            toolBarButton7.ImageIndex = 6;
            toolBarButton7.ToolTipText = "Day/Night";
            toolBarButton8.ImageIndex = 7;
            toolBarButton8.ToolTipText = "Info";
            tBar.Buttons.Add(toolBarButton1);
            tBar.Buttons.Add(toolBarButton2);
            tBar.Buttons.Add(tbSeparator);
            tBar.Buttons.Add(toolBarButton3);
            tBar.Buttons.Add(toolBarButton4);
            tBar.Buttons.Add(tbSeparator);
            tBar.Buttons.Add(toolBarButton5);
            tBar.Buttons.Add(toolBarButton6);
            tBar.Buttons.Add(tbSeparator);
            tBar.Buttons.Add(toolBarButton7);
            tBar.Buttons.Add(tbSeparator);
            tBar.Buttons.Add(toolBarButton8);
            tBar.Appearance = ToolBarAppearance.Flat;
            tBar.BorderStyle = BorderStyle.Fixed3D;
            tBar.Location = new Point(0, 24);
            tBar.ButtonClick += new ToolBarButtonClickEventHandler(tBar_ButtonClick);
            this.Controls.Add(tBar);
        }
        public void font_ButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                using (FontDialog fd = new FontDialog())
                {
                    fd.ShowColor = true;
                    My_TabPage temp = (My_TabPage)MTControl.SelectedTab;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        temp.tb.Font = fd.Font;
                        temp.tb.ForeColor = fd.Color;
                        temp.BackColor = fd.Color;
                        temp.ForeColor = fd.Color;
                    }
                }
            }
            catch (Exception m) { MessageBox.Show(m.Message); }
        }
        void color_ButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                using (ColorDialog cd = new ColorDialog())
                {
                    My_TabPage temp = (My_TabPage)MTControl.SelectedTab;
                    cd.Color = temp.tb.BackColor;
                    if (cd.ShowDialog() == DialogResult.OK) {temp.tb.BackColor = cd.Color;}
                }
            }
            catch (Exception m) {MessageBox.Show(m.Message);}
        }
        void open_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "TEXT|*.txt|ALL|*.*";
                ofd.Title = "Choose your destiny";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    MTControl.TabPages.Add(new My_TabPage(ofd.SafeFileName,File.ReadAllText(ofd.FileName)));
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
                    My_TabPage temp = (My_TabPage)MTControl.SelectedTab;
                    sfd.Filter = "TEXT|*.txt|ALL|*.*";
                    sfd.Title = "Choose your destiny";
                    if (sfd.ShowDialog() == DialogResult.OK) {File.WriteAllText(sfd.FileName, temp.tb.Text);}
                }
            }
            catch (Exception m) {MessageBox.Show(m.Message);}
        }
        void tBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.ImageIndex)
            {
                case 0:
                    new_Click(sender, e);
                    break;
                case 1:
                    save_Click(sender, e);
                    break;
                case 2:
                    SendKeys.Send("^z");
                    break;
                case 3:
                    SendKeys.Send("^y");
                    break;
                case 4:
                    SendKeys.Send("^x");
                    break;
                case 5:
                    SendKeys.Send("^v");
                    break;
                case 6:
                    try
                    {
                        My_TabPage temp = (My_TabPage)MTControl.SelectedTab;
                        if (temp.tb.BackColor == Color.Black)
                        {
                            temp.tb.BackColor = Color.White;
                            temp.tb.ForeColor = Color.Black;
                            temp.BackColor = Color.Black;
                            temp.ForeColor = Color.Black;
                        }
                        else
                        {
                            temp.tb.BackColor = Color.Black;
                            temp.tb.ForeColor = Color.White;
                            temp.BackColor = Color.White;
                            temp.ForeColor = Color.White;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    break;
                case 7:
                    MessageBox.Show("Экзамен(WinForms)\nСтудент - Лобода Р.Е.");
                    break;
                default:
                    break;
            }
        }
        void new_Click(object sender, System.EventArgs e) { MTControl.TabPages.Add(new My_TabPage()); }
        void close_Click(object sender, System.EventArgs e) { this.Close(); }
    }
}