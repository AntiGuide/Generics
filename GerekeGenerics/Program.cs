using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerekeGenerics {
    class Program {
        static void Main(string[] args) {
            var v1 = new MyClass("car");
            var v2 = new MyClass("plane");
            var v3 = new MyClass("NPC2");
            var v4 = new MyClass2("NPC2");

            var test = new MultiMap<string, MyClass>((myClass) => { return myClass.Value != "error"; });
            test.MyAddEvent += key => Console.WriteLine("{0} Item added!", key);
            test.MyRemoveEvent += key => Console.WriteLine("{0} Item removed!", key);

            var test2 = new MultiMap<string, MyClass2>((myClass2) => { return myClass2.Value != "error2"; });
            test2.MyAddEvent += key => Console.WriteLine("{0} Item added!", key);
            test2.MyRemoveEvent += key => Console.WriteLine("{0} Item removed!", key);

            try {
                test.Add("vehicle", v1);
                test.Add("vehicle", v2);
                test.Add("npc", v3);
                test.Add("npc", v3);
                test.Add("npc", v3);
                test2.Add("npc", v4);
                test2.Add("npc", v4);
                test2.Add("npc", v4);
                test2.Add("pc", v4);
                test.Add(test2);
            } catch (NullNotAllowedException e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Keys: {0}", String.Join(", ", test.Keys));
            Console.WriteLine("Values: {0}", String.Join(", ", test.Values));
            Console.WriteLine("Key {1}: {0}", String.Join(", ", test["npc"]), "npc");
            Console.WriteLine("Key {1}: {0}", String.Join(", ", test["pc"]), "pc");
            Console.WriteLine("Contains {1}->{2}: {0}", test.ContainsValue("vehicle", v1), "vehicle", v1);
            Console.WriteLine("Contains {1}->{2}: {0}", test.ContainsValue("vehicles", v1), "vehicles", v1);

            test.Remove("npc", v3);
            Console.WriteLine("Key {1}: {0}", String.Join(", ", test["npc"]), "npc");
            test.Remove("npc", v3);
            Console.WriteLine("Key {1}: {0}", String.Join(", ", test["npc"]), "npc");
            test.Remove("npc", v3);
            Console.WriteLine("Contains {1}: {0}", test.ContainsKey("npc"), "npc");

            Console.ReadLine();
        }

        public void AddEvent<MyClass>() {
            Console.WriteLine("An element has been added!");
        }

        public void RemoveEvent() {
            Console.WriteLine("An element has been removed!");
        }
    }
}
