namespace SystemProgramming.second_labs.forms.lab7
{
    public class TextRender
    {
        public static string ChangeVowelCase(string text)
        {
            string result = "";

            foreach (char i in text)
            {
                if (IsVowel(i))
                {
                    if (char.IsUpper(i))
                    {
                        result += i.ToString().ToLower();
                    }
                    else
                    {
                        result += i.ToString().ToUpper();
                    }
                }
                else
                {
                    result += i;
                }

            }

            return result;
        }



                /* Private methods */

        // Variant 18

        private static bool IsVowel(char s)
        {
            char[] vowels = 
                {

                // Eng
                'a', 'e', 'i', 'o', 'u', 'y',
                'A', 'E', 'I', 'O', 'U', 'Y',

                // Rus
                'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
                'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я'

                };


            foreach (char i in vowels)
            {
                if (s.Equals(i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
