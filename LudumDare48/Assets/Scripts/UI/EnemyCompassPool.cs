using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyCompassPool : MonoBehaviour
{
    public EnemyCompassIndicator indicatorPrefab;
    
    public bool collectionChecks = true;
    public int maxPoolSize = 40;

    private IObjectPool<EnemyCompassIndicator> pool;

    public IObjectPool<EnemyCompassIndicator> Pool
    {
        get
        {
            if (pool == null)
            {
                pool = new ObjectPool<EnemyCompassIndicator>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
            }
            
            return pool;
        }
    }

    private EnemyCompassIndicator CreatePooledItem()
    {
        EnemyCompassIndicator indicator = Instantiate(indicatorPrefab, transform);

        return indicator;
    }

    void OnReturnedToPool(EnemyCompassIndicator obj)
    {
        obj.target = null;
        obj.gameObject.SetActive(false);
    }

    void OnTakeFromPool(EnemyCompassIndicator obj)
    {
        obj.gameObject.SetActive(true);
    }

    void OnDestroyPoolObject(EnemyCompassIndicator obj)
    {
        Destroy(obj.gameObject);
    }
}
