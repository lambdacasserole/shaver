using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaver
{
    class ShavianCharacterHelper
    {
        public const string Peep = "\U00010450";

        public const string Tot = "\U00010451";

        public const string Kick = "\U00010452";

        public const string Fee = "\U00010453";

        public const string Thigh = "\U00010454";

        public const string So = "\U00010455";

        public const string Sure = "\U00010456";

        public const string Church = "\U00010457";

        public const string Yea = "\U00010458";

        public const string Hung = "\U00010459";

        public const string Bib = "\U0001045A";

        public const string Dead = "\U0001045B";

        public const string Gag = "\U0001045C";

        public const string Vow = "\U0001045D";

        public const string They = "\U0001045E";

        public const string Zoo = "\U0001045F";

        public const string Measure = "\U00010460";

        public const string Judge = "\U00010461";

        public const string Woe = "\U00010462";

        public const string Haha = "\U00010463";

        public const string Loll = "\U00010464";

        public const string Mime = "\U00010465";

        public const string If = "\U00010466";

        public const string Egg = "\U00010467";

        public const string Ash = "\U00010468";

        public const string Ado = "\U00010469";

        public const string On = "\U0001046A";

        public const string Wool = "\U0001046B";

        public const string Out = "\U0001046C";

        public const string Ah = "\U0001046D";

        public const string Roar = "\U0001046E";

        public const string Nun = "\U0001046F";

        public const string Eat = "\U00010470";

        public const string Age = "\U00010471";

        public const string Ice = "\U00010472";

        public const string Up = "\U00010473";

        public const string Oak = "\U00010474";

        public const string Ooze = "\U00010475";

        public const string Oil = "\U00010476";

        public const string Awe = "\U00010477";

        public const string Are = "\U00010478";

        public const string Or = "\U00010479";

        public const string Air = "\U0001047A";

        public const string Err = "\U0001047B";

        public const string Array = "\U0001047C";

        public const string Ear = "\U0001047D";

        public const string Ian = "\U0001047E";

        public const string Yew = "\U0001047F";

        private static string[] codePoints = new string[]
        {
            Peep, Tot, Kick,
            Fee, Thigh, So,
            Sure, Church, Yea,
            Hung, Bib, Dead,
            Gag, Vow, They,
            Zoo, Measure, Judge,
            Woe, Haha, Loll,
            Mime, If, Egg,
            Ash, Ado, On,
            Wool, Out, Ah,
            Roar, Nun, Eat,
            Age, Ice, Up,
            Oak, Ooze, Oil,
            Awe, Are, Or,
            Air, Err, Array,
            Ear, Ian, Yew
        };

        public static string GetAtCodePoint(int codePoint)
        {
            if (codePoint < 0 || codePoint >= codePoints.Length)
            {
                throw new IndexOutOfRangeException("There is no Shavian character at this code point.");
            }
            return codePoints[codePoint];
        }

        public static byte[] GetBytesAtCodePoint(int codePoint)
        {
            return Encoding.Unicode.GetBytes(GetAtCodePoint(codePoint));
        }
    }
}
