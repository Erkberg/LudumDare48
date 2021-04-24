using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public EnemyType type;
    public float minSpeed;
    public float maxSpeed;
}
