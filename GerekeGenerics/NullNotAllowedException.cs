using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerekeGenerics {
    class NullNotAllowedException : System.Exception {
        public NullNotAllowedException(string message) : base(message) { }
    }
}
