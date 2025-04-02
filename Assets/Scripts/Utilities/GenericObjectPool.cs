using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool <T> where T : class
    {
        protected List<PooledObject> genericPool = new();

        public class PooledObject
        {
            public T objectToPool;
            public bool isUsed;
        }

        protected T GetObject()
        {
            if (genericPool.Count > 0)
            {
                PooledObject item = genericPool.Find(item => !item.isUsed);
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
            PooledObject newObject = new PooledObject
            {
                objectToPool = CreateObject(),
                isUsed = true
            };
            genericPool.Add(newObject);
            return newObject.objectToPool;
        }

        protected virtual T CreateObject()
        {
            throw new NotImplementedException("CreateObject() not implemented");
        }

        protected void ReturnObjectToPool(T objectToReturn)
        {
            PooledObject objectToReturnToPool = genericPool.Find(i => i.objectToPool.Equals(objectToReturn));
            objectToReturnToPool.isUsed = false;
        }
    }
}