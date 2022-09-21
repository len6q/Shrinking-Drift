using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _garbageCollector;

    protected T CreateElement<T>(T prefab, Queue<T> pool) where T: MonoBehaviour
    {
        T element = Instantiate(prefab, _garbageCollector);
        element.gameObject.SetActive(false);
        pool.Enqueue(element);
        return element;
    }

    protected bool TryGetElement<T>(out T prefab, Queue<T> pool) where T: MonoBehaviour
    {
        T item = pool.Peek();
        if (item.gameObject.activeInHierarchy == false)
        {
            pool.Dequeue();
            pool.Enqueue(item);
            prefab = item;
            item.gameObject.SetActive(true);
            return true;
        }
        else
        {
            prefab = null;
            return false;
        }
    }

}
