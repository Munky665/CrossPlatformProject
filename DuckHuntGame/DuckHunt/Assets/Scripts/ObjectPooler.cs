﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand;

}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        if (itemsToPool != null)
        {
            foreach (ObjectPoolItem item in itemsToPool)
            {
                for (int i = 0; i < item.amountToPool; i++)
                {
                    GameObject obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                }
            }
        }
    }

    public GameObject GetPoolObject(string tag)
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach(ObjectPoolItem item in itemsToPool)
        {
            if(item.objectToPool.tag == tag)
            {
                GameObject obj = Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        return null;
    }

    public GameObject GetPooledDuck(string tag, int position)
    {
        if(!pooledObjects[position].activeInHierarchy && pooledObjects[position].tag == tag)
        {
            return pooledObjects[position];
        }
        return null;
    }
}
