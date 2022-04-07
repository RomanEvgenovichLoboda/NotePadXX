using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace NotePadXX
{
    public class My_TabPage : TabPage
    { 
        public TextBox tb;
        public My_TabPage(string title = "new",string _text = "")
        {
            this.ForeColor = Color.DarkOliveGreen;
            this.BackColor = Color.Coral;
            this.Text = title;
            tb = new TextBox { Multiline = true,Text = _text, ScrollBars = ScrollBars.Both, Size = ClientSize, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
            this.Controls.Add(tb);
        }
    }
}
