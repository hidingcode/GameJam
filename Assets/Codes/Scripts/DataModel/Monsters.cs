using UnityEngine;

namespace Codes.Scripts.DataModel
{
    [CreateAssetMenu(fileName = "Monster", menuName = "Data/Monster")]
    public class Monsters : ScriptableObject
    {
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
        
        [Header("Monster Information")]
        public string monsterName = "Unnamed";
        public string description = "No description";
        public GameObject monsterPrefab;
        public MonsterType monsterType;
        public Sprite monsterSprite;
        public int monsterPrice;
        public bool isUnlocked;
        
        // To prevent from modify the whole data please make a copy of the data
        [Header("Monster Stats")]
        public float hitPoint;
        public float speedModifier;
        public float spawnCoolDown;
    }
}
