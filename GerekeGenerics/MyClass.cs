using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerekeGenerics {
    class MyClass {
        public string Value { get; }

        public MyClass(string value) {
            Value = value;
        }

        public override string ToString() => Value;
    }
}
