using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Helpers
{
    public static class TextBoxHelper
    {
       public static bool PreventLetters(object sender, KeyPressEventArgs e)
        {
            bool res = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                res = true;
            }
            return res;
        }
    }
}
