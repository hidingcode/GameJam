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
        private enum MonsterState
        {
            Spawned,
            CoolDown,
            SearchingTarget,
            ChasingTarget,
            PerformSkill,
            Dead
        }
        
        public string monsterName = "Unnamed";
        public string description = "No description";
        public GameObject monsterPrefab;
        public MonsterType monsterType;
        public Sprite monsterSprite;
        public int monsterPrice;
        public bool isUnlocked;
        
        [Header("Stats")]
        public float hitPoint;
        public float speedModifier;
        public float spawnCoolDown;
    }
}
