﻿namespace AngleSharp.Css.Conditions
{
    using System;
    using System.Collections.Generic;

    sealed class NotCondition : CssCondition
    {
        CssCondition _content;

        public CssCondition Value 
        {
            get { return _content; }
            internal set { _content = value; }
        }

        public override String GetSource()
        {
            var source = String.Concat(Keywords.Not, _content.GetSource());
            return Decorate(source);
        }
        
        protected override String Serialize()
        {
            return String.Concat("not ", _content.Text);
        }

        public override Boolean Check()
        {
            return !_content.Check();
        }

        public override IEnumerable<CssNode> GetChildren()
        {
            if (_content != null)
                yield return _content;
        }
    }
}
