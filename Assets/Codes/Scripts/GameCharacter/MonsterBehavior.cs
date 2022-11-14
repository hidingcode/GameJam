using System;
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
    Spawn,
    Cooldown,
    SearchingTarget,
    ChasingTarget,
    PerformSkill,
    Dead
}

public class MonsterSkill : MonoBehaviour
{
    [SerializeField] private MonsterBehavior _behavior;

    // Monster skill related
    [SerializeField] public MonsterSkill monsterSkill;
    [SerializeField] public float skillCooldown;
    private float skillTimer;
    public bool skillReady;

    void Update()
    {
        if (!skillReady)
        {
            skillTimer += Time.deltaTime;
            skillReady = skillTimer > skillCooldown;
        }
        else
        {
            skillTimer = 0;
        }
    }
}

public class MonsterBehavior : MonoBehaviour
{
    // General information
    [SerializeField] public string monsterName;

    // Monster information
    [SerializeField] public float speedModifier;
    [SerializeField] public float hitPoint;

    // Monster Summon Related
    [SerializeField] public MonsterType monsterType;
    [SerializeField] public float spawnTime;
    private float spawnTimer;
    public bool spawnReady;


    void Start()
    {
        this.spawnReady = true;
    }

    private void Update()
    {
        if (!spawnReady)
        {
            spawnTimer += Time.deltaTime;
            spawnReady = spawnTimer > spawnTime;
        }
        else
        {
            spawnTimer = 0;
        }
    }
}