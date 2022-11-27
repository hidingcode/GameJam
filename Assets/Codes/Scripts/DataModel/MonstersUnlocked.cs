using System.Collections.Generic;
using UnityEngine;

namespace Codes.Scripts.DataModel
{
    [CreateAssetMenu(fileName = "MonstersUnlocked", menuName = "Data/MonstersUnlocked")]
    // Monsters unlocked
    public class MonstersUnlocked : ScriptableObject
    {
        public List<Monsters> monsters;
    }
}
