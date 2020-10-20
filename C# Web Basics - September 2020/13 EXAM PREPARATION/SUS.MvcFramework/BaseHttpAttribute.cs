using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class BaseHttpAttribute : Attribute //Custom attribute classes must inherit the Attribute class!
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get; } //abstract - Require each of the heirs to implement this method.
    }
}
