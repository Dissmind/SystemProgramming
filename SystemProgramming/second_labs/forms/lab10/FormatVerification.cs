using System;
using System.Collections.Generic;
using System.Text;

namespace lab10_var3
{
    class FormatVerification
    {
        public static bool IsDigital(string text)
        {
            if (int.TryParse(text, out int result))
            {
                return false;
            }

            return true;
        }


        public static bool IsEmpty(string text)
        {
            return (text.Trim() == "") ? true : false;
        }


        public static bool SpaceCheck(string text)
        {
            return ((text.IndexOf(' ') != -1)) ? true : false;
        }
    }
}
