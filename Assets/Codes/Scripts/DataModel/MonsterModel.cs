using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Grounded,
    Moving
}

public enum MonsterState
{
    Spawned,
    CoolDown,
    SearchingTarget,
    ChasingTarget,
    PerformSkill,
    Dead
}

public class MonsterModel : MonoBehaviour
{
    public string monsterName;
    public float speedModifier;
    public float hitPoint;

    public MonsterType monsterType;
    public float spawnCoolDown;
}