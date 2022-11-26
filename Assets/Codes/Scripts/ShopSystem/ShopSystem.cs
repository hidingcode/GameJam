using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace Codes.Scripts.ShopSystem
{
    public class ShopSystem : MonoBehaviour
    {   
        // Just for testing (need to take candy count from player)
        public int candyCount = 100;
    
        public ShopMonsters[] shopMonsters;
        public Button[] shopButtons;

        // Start is called before the first frame update
        void Start()
        {
            InitMonsterShop();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateShopButtons();
        }
    
        // Buy
        public void UnlockMonster(int monsterCost)
        {
            candyCount -= monsterCost;
        }
        
        // Initialise Monster Shop Details
        public void InitMonsterShop()
        {
            for(int i = 0; i < shopMonsters.Length; i++)
            {
                GameObject.Find("Name (" + i + ")").GetComponent<TextMeshProUGUI>().text = shopMonsters[i].monsterName;
                GameObject.Find(("Price (" + i + ")")).GetComponent<TextMeshProUGUI>().text = shopMonsters[i].monsterPrice.ToString();
                GameObject.Find("MonsterImage ("+ i +")").GetComponent<Image>().sprite = shopMonsters[i].monsterSprite;
            }
        }
        
        // Update the buttons to active or inactive buttons according to the candy count
        public void UpdateShopButtons()
        {
            for(int i = 0; i < shopButtons.Length; i++)
            {
                if (candyCount >= shopMonsters[i].monsterPrice)
                {
                    shopButtons[i].interactable = true;
                }
                else
                {
                    shopButtons[i].interactable = false;
                }
            }
        }
        public void ShowDescription(int monsterIndex)
        {   
            Debug.Log("Trigger");
            GameObject.Find("MonsterName").GetComponent<TextMeshProUGUI>().text = shopMonsters[monsterIndex].monsterName;
            GameObject.Find("Description").GetComponent<TextMeshProUGUI>().text = shopMonsters[monsterIndex].description;
        }
    }
}
