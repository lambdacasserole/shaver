using System.Text;

namespace Shaver
{
    /// <summary>
    /// Represents a character in the Shaw alphabet.
    /// </summary>
    public class ShavianCharacter
    {
        private string character;

        /// <summary>
        /// Gets the character as a string.
        /// </summary>
        public string Character
        {
            get
            {
                return character;
            }
        }

        /// <summary>
        /// Gets the length of the character in bytes.
        /// </summary>
        public int Length
        {
            get
            {
                return Encoding.UTF8.GetBytes(character).Length;
            }
        }

        /// <summary>
        /// Initializes a new instance of a character of the Shaw alphabet.
        /// </summary>
        /// <param name="character">The character as a string.</param>
        public ShavianCharacter(string character)
        {
            this.character = character;
        }
    }
}
