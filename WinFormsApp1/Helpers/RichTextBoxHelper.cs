using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Helpers
{
    public static class RichTextBoxHelper
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool AddNewLine = false, bool bold = false)
        {
            if (AddNewLine)
            {
                text += Environment.NewLine;
            }

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;


            box.SelectionFont = bold ? new Font(box.Font, FontStyle.Bold) : new Font(box.Font, box.Font.Style);
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
