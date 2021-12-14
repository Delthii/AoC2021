using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class MultiSet<Key> : IDictionary<Key, long> where Key : notnull
    {
        private readonly Dictionary<Key, long> dict;

        public MultiSet()
        {
            dict = new Dictionary<Key, long>();
        }

        public long this[Key key] { get => dict.ContainsKey(key) ? dict[key] : 0; set => Add(key, value); }

        public ICollection<Key> Keys => dict.Keys;

        public ICollection<long> Values => dict.Values;

        public int Count => dict.Count();

        public bool IsReadOnly => true;

        public void Add(Key key, long value)
        {
            dict[key] = value;
        }

        public void Add(KeyValuePair<Key, long> item)
        {
            dict.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            dict.Clear();
        }

        public bool Contains(KeyValuePair<Key, long> item)
        {
            return dict.Contains(item);
        }

        public bool ContainsKey(Key key)
        {
            return dict.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<Key, long>[] array, int arrayIndex)
        {
            var dictArr = dict.ToArray();
            for (int i = arrayIndex; i < dict.Count; i++)
            {
                array[i] = dictArr[i];
            }
        }

        public IEnumerator<KeyValuePair<Key, long>> GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        public bool Remove(Key key)
        {
            return dict.Remove(key);
        }

        public bool Remove(KeyValuePair<Key, long> item)
        {
            return dict.Remove(item.Key);
        }

        public bool TryGetValue(Key key, [MaybeNullWhen(false)] out long value)
        {
            return dict.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
