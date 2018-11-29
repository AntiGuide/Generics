using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerekeGenerics {
    public delegate void MyDel<in V>(V value);
    interface IMultiMap<K, V> : IEnumerable<KeyValuePair<K, V>> {
        event MyDel<V> MyAddEvent;
        event MyDel<V> MyRemoveEvent;

        bool ContainsKey(K key);
        bool ContainsValue(K key, V value);

        IEnumerable<K> Keys { get; }
        IEnumerable<V> Values { get; }
        IEnumerable<V> this[K key] { get; }

        void Add(K key, V value);
        void Remove(K key, V value);
    }
}
