using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Votyra.Core.Models.ObjectPool;
using Votyra.Core.TerrainMeshes;

namespace Votyra.Core.Pooling
{
    public class Pool<TValue> : IRawPool<TValue>
    {
        private readonly object _lock=new object();
        private readonly List<TValue> _list = new List<TValue>();
        private readonly Func<TValue> _factory;


        public int PoolCount { get; private set; }
        public int ActiveCount { get; private set; }
        
        public Pool(Func<TValue> factory)
        {
            _factory = factory;
        }

        public TValue GetRaw()
        {
            ActiveCount++;
            lock (_lock)
            {
                TValue value;
                if (_list.Count == 0)
                {
                    value = _factory();
                }
                else
                {
                    PoolCount--;
                    value = _list[_list.Count - 1];
                    _list.RemoveAt(_list.Count - 1);
                }

                return value;
            }
        }

        public void ReturnRaw(TValue value)
        {
            ActiveCount--;
            PoolCount++;
            lock (_lock)
            {
                _list.Add(value);
            }
        }
    }
}