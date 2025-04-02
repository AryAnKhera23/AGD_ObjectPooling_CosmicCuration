using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool <T> where T : class
    {
        protected List<PooledObject<T>> genericPool = new List<PooledObject<T>>();

        public class PooledObject<T>
        {
            public T objectToPool;
            public bool isUsed;
        }

        protected T GetObject()
        {
            if (genericPool.Count > 0)
            {
                PooledObject<T> item = genericPool.Find(item => !item.isUsed);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.objectToPool;
                }
            }
            return CreateNewPooledObject();
        }

        private T CreateNewPooledObject()
        {
            PooledObject<T> newObject = new PooledObject<T>();
            newObject.objectToPool = CreateObject();
            newObject.isUsed = true;
            genericPool.Add(newObject);
            return newObject.objectToPool;
        }

        protected virtual T CreateObject()
        {
            throw new NotImplementedException("CreateObject() not implemented");
        }

        protected void ReturnObjectToPool(T objectToReturn)
        {
            PooledObject<T> objectToReturnToPool = genericPool.Find(i => i.objectToPool.Equals(objectToReturn));
            objectToReturnToPool.isUsed = false;
        }
    }
}