using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaver
{
    class ShavianCharacter
    {
        private string character;

        public string Character
        {
            get
            {
                return character;
            }
        }

        public int Length
        {
            get
            {
                return Encoding.UTF8.GetBytes(character).Length;
            }
        }

        public ShavianCharacter(string character)
        {
            this.character = character;
        }
    }
}
