using System;
using System.Collections.Generic;
using System.Text;

namespace SystemProgramming.second_labs.forms.lab7
{
    class TextRender
    {
        public static string ChangeVowelCase(string text)
        {
            return text;
        }



                /* Private methods */

        // Variant 18

        private static bool IsUpperCase(char s)
        {
            if (s > 'z' || s > 'я')
            {
                return true;
            }

            return false;
        }

        private static bool IsVowel(char s)
        {
            char[] vowel = [
                // Eng
                'а', 'e', 'i', 'o', 'u', 'y',
                'A', 'E', 'I', 'O', 'U', 'Y',

                // Rus
                'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
                'Ф', 'У', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я'
            ];


            foreach (var i in vowel)
            {
                if (s == i)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
