namespace Quadratic
{
    public class Coef(string name, string value, int cursorTop, int index)
    {
        private const int MINIMAL_CURSOR_LEFT_POSITION = 5;
        public string Name { get; set; } = name;
        private string _value = value;
        public string Value 
        {
            get { return this._value; }
            set 
            {
                this._value = value;
                this.CursorLeft = MINIMAL_CURSOR_LEFT_POSITION + value.Length;
            } 
        }
        public int ValueToNumber { get; set; }
        public int CursorTop { get; set; } = cursorTop;
        public int CursorLeft { get; set; } = MINIMAL_CURSOR_LEFT_POSITION;
        public int Index { get; set; } = index;
    }
}
