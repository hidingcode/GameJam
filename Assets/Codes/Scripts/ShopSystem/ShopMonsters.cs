using UnityEngine;

namespace Codes.Scripts.ShopSystem
{
    [CreateAssetMenu(fileName = "Monster", menuName = "Shop/Monster")]
    public class ShopMonsters : ScriptableObject
    {
        public string monsterName = "Unnamed";
        public string description = "No description";
        public Sprite monsterSprite;
        public int monsterPrice;
        public bool isAvaliable = true;
    }
}
