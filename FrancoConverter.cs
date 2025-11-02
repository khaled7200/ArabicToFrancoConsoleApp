using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagerConsoleApp
{


    public static class FrancoConverter
    {

     
public static Dictionary<string, string> arabicSpecialWords = new Dictionary<string, string>
{
    {"شارع", "St."},
    {"ش", "St."},
    {"الشارع", "St."},        // مع ال
    {"بلوك", "Blk."},
    {"البلوك", "Blk."},        // مع ال
    {"حي", "Dist."},
    {"حى", "Dist."},
    {"الحي", "Dist."},         // مع ال
    {"الحى", "Dist."},         // مع ال
    {"مجاورة", "Mg."},
    {"مجاوره", "Mg."},
    {"المجاورة", "Mg."},       // مع ال
    {"المجاوره", "Mg."},       // مع ال
  //  {"بجوار", "Next to"},
 //   {"وبجوار", "and Next to"},     // مع الواو
    {"و", "and"},
    { "فيلا","V."}
};



      public static  Dictionary<string, string> arabicPrepositions = new Dictionary<string, string>
        {
            {"في", "in"},
                {"فى", "in"},
            {"على", "on"},
                   {"علي", "on"},
        //    {"من", "from"},
            {"إلي", "to"},
            {"الي", "to"},
            {"إلى", "to"},
            {"الى", "to"}/*,
            {"عن", "about"},
            {"مع", "with"},
            {"تحت", "under"},
            {"فوق", "above"},
            {"بين", "between"},   
            {"أمام", "in front of"},
            {"امام", "in front of"},
            {"خلف", "behind"},
            {"خلال", "during, through"},
            {"بعد", "after"},
            {"قبل", "before"},
            {"بدون", "without"},
            {"نحو", "towards"},
            {"عند", "at"}*/
        };

        private static readonly Dictionary<string, string> FrancoMap = new Dictionary<string, string>
    {
        // High-Priority Numerals (Non-Latin sounds)
        { "أ", "a" }, { "آ", "aa" }, { "إ", "e" }, { "ئ", "aa" }, { "ؤ", "oaa" }, { "ء", "aa" },
        { "ع", "aa" },
        { "غ", "gh" }, // Can also be 3'
        { "ح", "h" },
        { "خ", "kh" }, // Can also be kh
        { "ق", "q" }, // Can also be q
        { "ص", "s" },
        { "ض", "d'" },
        { "ط", "t" },
        { "ظ", "z'" },
        { "ك", "k" },
        
        // Basic Latin Approximations (Vowels and Consonants)
        { "ب", "b" },
        { "ت", "t" },
        { "ث", "th" },
        { "ج", "j" }, // Can be g in some dialects
        { "د", "d" },
        { "ذ", "z" }, // Can be dh
        { "ر", "r" },
        { "ز", "z" },
        { "س", "s" },
        { "ش", "sh" },
        { "ف", "f" },
        { "ل", "l" },
        { "م", "m" },
        { "ن", "n" },
        { "ه", "h" },
        { "ة", "a" }, // Taa Marbuta is often 'a' or 'eh'
        { "و", "w" },
        { "ي", "y" },
        { "ى", "a" }, // Alef Maqsura is often 'a'
        { "ا", "a" }, // Alef is usually 'a'
        
        // Final cleanups (especially for 'h' and diacritics - though complex)
        // ... you may add more complex rules here based on context
    };








        public static string ConvertSpecialWords(string arabicText)
        {
            string normalizedText = arabicText.ToLowerInvariant().Replace(" ", " ");

            // 2. Transliteration using the map
            var result = new StringBuilder();

            foreach (string word in normalizedText.Split(" "))
            {
                string charStr = word.ToString();

                if (arabicSpecialWords.TryGetValue(charStr, out string francoEquivalent))
                {
                    result.Append(francoEquivalent + " ");
                }
                else
                {
                    // Keep non-Arabic characters (like punctuation or spaces) as they are
                    result.Append(word +" ");
                }
            }

            // 3. Post-processing (Optional: handle sequences like 'a' for 'ا' before 'l' for 'ل')
            // Franco is phonetic, so sometimes the 'a' for 'ا' is dropped for brevity, e.g. "ال" -> "el"
            // This is where custom phonetic logic would be highly beneficial, 
            // but for a simple mapping, we return the result.

            return result.ToString();

        }












        public static string ConvertPreposition(string arabicText)
        {
            string normalizedText = arabicText.ToLowerInvariant().Replace(" ", " ");

            // 2. Transliteration using the map
            var result = new StringBuilder();

            foreach (string c in normalizedText.Split(" "))
            {
                string charStr = c.ToString();

                if (arabicPrepositions.TryGetValue(charStr, out string francoEquivalent))
                {
                    result.Append(francoEquivalent+" ");
                }
                else
                {
                    // Keep non-Arabic characters (like punctuation or spaces) as they are
                    result.Append(c+" ");
                }
            }

            // 3. Post-processing (Optional: handle sequences like 'a' for 'ا' before 'l' for 'ل')
            // Franco is phonetic, so sometimes the 'a' for 'ا' is dropped for brevity, e.g. "ال" -> "el"
            // This is where custom phonetic logic would be highly beneficial, 
            // but for a simple mapping, we return the result.

            return result.ToString();

        }


        public static string ConvertArabicToFranco(string arabicText)
        {
            arabicText= ConvertSpecialWords(arabicText);
            arabicText= ConvertPreposition(arabicText);

            // 1. Basic Normalization (optional but recommended)
            string normalizedText = arabicText.ToLowerInvariant().Replace(" ", " ");

            // 2. Transliteration using the map
            var result = new StringBuilder();

            foreach (char c in normalizedText)
            {
                string charStr = c.ToString();

                if (FrancoMap.TryGetValue(charStr, out string francoEquivalent))
                {
                    result.Append(francoEquivalent);
                }
                else
                {
                    // Keep non-Arabic characters (like punctuation or spaces) as they are
                    result.Append(c);
                }
            }

            // 3. Post-processing (Optional: handle sequences like 'a' for 'ا' before 'l' for 'ل')
            // Franco is phonetic, so sometimes the 'a' for 'ا' is dropped for brevity, e.g. "ال" -> "el"
            // This is where custom phonetic logic would be highly beneficial, 
            // but for a simple mapping, we return the result.

            return result.ToString();
        }
    }




}