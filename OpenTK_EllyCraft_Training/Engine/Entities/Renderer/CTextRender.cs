using Cairo;
using Crow;

namespace EllyCraft.GUI
{
    class CTextRender : GraphicObject
    {
        public CTextRender(Interface iface) : base(iface) { }

        string _text;
        public string text
        {
            get { return _text; }
            set
            {
                if (value == _text)
                    return;
                _text = value;
                NotifyValueChanged("text", _text);
            }
        }

        protected override void onDraw(Context gr)
        {
            base.onDraw(gr);
        }
    }
}
