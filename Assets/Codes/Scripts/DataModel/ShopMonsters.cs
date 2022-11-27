using System.Collections.Generic;
using UnityEngine;

namespace Codes.Scripts.DataModel
{
    [CreateAssetMenu(fileName = "ShopMonsters", menuName = "Data/ShopMonsters")]
    // Monsters that can be bought in the shop
    public class ShopMonsters : ScriptableObject
    {
        public List<Monsters> monsters;
    }
}
