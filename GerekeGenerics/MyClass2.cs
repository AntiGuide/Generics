using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerekeGenerics {
    class MyClass2 : MyClass{
        public MyClass2(string value) : base(value) { }
        public override string ToString() => String.Format("'{0}'", Value);
    }
}
