using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadXX
{
    public class My_TabControl : TabControl
    {
        public My_TabControl()
        {
            Location = new Point(0, 70);
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Padding = new Point(12, 4);
            DrawMode = TabDrawMode.OwnerDrawFixed;
            DrawItem += tabControl1_DrawItem;
            MouseDown += tabControl1_MouseDown;
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabPage = TabPages[e.Index];
            var tabRect = GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);
            
            var closeImage = Properties.Resources.Close;
            e.Graphics.DrawImage(closeImage, (tabRect.Right - closeImage.Width), tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                tabRect, tabPage.ForeColor, TextFormatFlags.Left);
        }
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < TabPages.Count; i++)
            {
                var tabRect = GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var closeImage = Properties.Resources.cross;
                var imageRect = new Rectangle( (tabRect.Right - closeImage.Width), tabRect.Top + (tabRect.Height - closeImage.Height) / 2, closeImage.Width, closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    TabPages.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
