using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace NotePadXX
{
    class C_Tab:TabPage
    {
        public C_Tab(string title)
        {
            this.Text = title;
            this.Controls.Add(new TextBox() { Multiline = true, Size = ClientSize, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right });
        }
    }
}
