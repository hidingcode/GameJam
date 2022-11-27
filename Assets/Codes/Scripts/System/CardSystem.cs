using System.Collections.Generic;
using Codes.Scripts.DataModel;
using UnityEngine;
using UnityEngine.UI;

namespace Codes.Scripts.System
{
    public class CardSystem : MonoBehaviour
    {
        public MonstersUnlocked monstersUnlocked;

        // Start is called before the first frame update
        void Start()
        {   
            for(int i = 0; i < monstersUnlocked.monsters.Count; i++)
            {
                GameObject.Find("Card (" + i + ")").GetComponent<Image>().sprite = monstersUnlocked.monsters[i].monsterSprite;
            }
        }

        // Update is called once per frame
        void Update()
        {
            for(int i = 0; i < monstersUnlocked.monsters.Count; i++)
            {
                GameObject.Find("Card (" + i + ")").GetComponent<Image>().sprite = monstersUnlocked.monsters[i].monsterSprite;
            }
        }
    }
}
