using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCompass : MonoBehaviour
{
    public List<Transform> trackedEnemies;
    public List<EnemyCompassIndicator> indicators;
    public EnemyCompassIndicator indicatorPrefab;

    public void AddEnemy(Transform enemyTransform)
    {
        if (!trackedEnemies.Contains(enemyTransform))
        {
            trackedEnemies.Add(enemyTransform);
            EnemyCompassIndicator indicator = Instantiate(indicatorPrefab, transform);
            indicator.target = enemyTransform;
            indicators.Add(indicator);
        }
    }
    
    public void RemoveEnemy(Transform enemyTransform)
    {
        if (trackedEnemies.Contains(enemyTransform))
        {
            trackedEnemies.Remove(enemyTransform);
            EnemyCompassIndicator indicator = GetIndicatorForTransform(enemyTransform);
            indicators.Remove(indicator);
            Destroy(indicator.gameObject);
        }
    }

    private EnemyCompassIndicator GetIndicatorForTransform(Transform enemyTransform)
    {
        return indicators.FirstOrDefault(indicator => indicator.target == enemyTransform);
    }
}
