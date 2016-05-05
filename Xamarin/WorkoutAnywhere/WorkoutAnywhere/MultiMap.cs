using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutAnywhere
{
    /// <summary>
    /// This MultiMap is used to group Runs by specific feature parameters.
    /// These parameters of interest compose the Tuple, which serves as the key.
    /// Each Run that creates that Tuple as its key is grouped into the List<Run>
    /// </summary>
    public class MultiMap<V>
    {
        Dictionary<string, List<V>> _dictionary = new Dictionary<string, List<V>>();

        public void Add(string key, V value)
        {
            List<V> list;
            if (this._dictionary.TryGetValue(key, out list))
            {
                list.Add(value);
            }
            else
            {
                list = new List<V>();
                list.Add(value);
                this._dictionary[key] = list;
            }
        }

        public IEnumerable<string> Keys
        {
            get
            {
                return this._dictionary.Keys;
            }
        }

        public List<V> this[string key]
        {
            get
            {
                List<V> list;
                if (!this._dictionary.TryGetValue(key, out list))
                {
                    list = new List<V>();
                    this._dictionary[key] = list;
                }
                return list;
            }
        }
    }
}

