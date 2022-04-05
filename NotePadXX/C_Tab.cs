using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace NotePadXX
{
    //class C_Tab:TabPage
    //{
    //    public C_Tab(string title = "new")
    //    {
    //        this.Text = title;
    //        this.Controls.Add(new TextBox() { Multiline = true, Size = ClientSize, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right });
    //    }
    //}


   public class C_Tab : TabPage
    { 
        public TextBox tb;
        public C_Tab(string title = "new",string _text = "")
        {
            this.Text = title;
            tb = new TextBox { Multiline = true,Text = _text, ScrollBars = ScrollBars.Both, Size = ClientSize, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
            //tb.ScrollBars = ScrollBars.Both;
            this.Controls.Add(tb);

            
        }
    }
}
