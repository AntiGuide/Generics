using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerekeGenerics {
    class MultiMap<K, V> : IMultiMap<K, V> {
        private Dictionary<K, HashSet<V>> myDictionary = new Dictionary<K, HashSet<V>>();

        public IEnumerable<V> this[K key] {
            get {
                return myDictionary.ContainsKey(key) ? myDictionary[key] : new HashSet<V>();
            }
        }

        public IEnumerable<K> Keys { get { return myDictionary.Keys; } }
        public IEnumerable<V> Values => myDictionary.Values.SelectMany(values => values);

        public void Add(K key, V value) {
            if (!ContainsKey(key)) {
                myDictionary.Add(key,new HashSet<V>());
            }
            myDictionary[key].Add(value);
        }

        public bool ContainsKey(K key) {
            return myDictionary.ContainsKey(key);
        }

        public bool ContainsValue(K key, V value) {
            return myDictionary.ContainsKey(key) && myDictionary[key].Contains(value);
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator() {
            foreach (var item1 in myDictionary) {
                foreach (var item2 in item1.Value) {
                    yield return new KeyValuePair<K, V>(item1.Key, item2);
                }
            }
        }

        public void Remove(K key, V value) {
            if (myDictionary.ContainsKey(key)) {
                myDictionary[key].Remove(value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}
