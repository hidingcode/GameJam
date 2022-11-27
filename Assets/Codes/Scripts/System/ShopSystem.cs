using Codes.Scripts.DataModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace Codes.Scripts.System
{
    public class ShopSystem : MonoBehaviour
    {   
        // Just for testing (need to take candy count from player)
        public int candyCounts = 100;
        // Index to track which monster is selected
        private int _buyIndex;
    
        public ShopMonsters shopMonsters;
        public Button[] shopButtons;
        private GameObject _descriptionBox;
        private GameObject _confirmationBox;
        private Image _monsterImage;
        private TextMeshProUGUI _candyCountsGUI;

        // Start is called before the first frame updateWW
        void Start()
        {
            _descriptionBox = GameObject.Find("Description Box");
            _confirmationBox = GameObject.Find("Confirmation Box");
            _monsterImage = GameObject.Find("CImage").GetComponent<Image>();
            _candyCountsGUI = GameObject.Find("Candy Count").GetComponent<TextMeshProUGUI>();
            
            UpdateMonsterShop();
            HideConfirmationBox();
        }

        // Update is called once per frame
        void Update()
        { 
            UpdateShopButtons();
            DisplayCandyCounts();
        }

        public void SetBuyIndex(int index)
        {
            _buyIndex = index;
            ShowConfirmationBox();
        }

        // Unlock selected monster
        public void UnlockMonster()
        {
            if (!shopMonsters.monsters[_buyIndex].isUnlocked)
            {
                if (candyCounts >= shopMonsters.monsters[_buyIndex].monsterPrice)
                {
                    candyCounts -= shopMonsters.monsters[_buyIndex].monsterPrice;
                    GameObject.Find("CardSystem").GetComponent<CardSystem>().monstersUnlocked.monsters.Add(shopMonsters.monsters[_buyIndex]);
                    shopMonsters.monsters[_buyIndex].isUnlocked = true;
                    HideConfirmationBox();
                }
                
                // TODO: Add a sound effect for when the player buys a monster
            }
        }

        // Display the number of candy that the user have
        private void DisplayCandyCounts()
        {
            // Need to be refactor in future
            _candyCountsGUI.text = candyCounts.ToString();
        }
        
        // Update the monsters shop after passing a level
        private void UpdateMonsterShop()
        {
            for(int i = 0; i < shopMonsters.monsters.Count; i++)
            {
                GameObject.Find("Name (" + i + ")").GetComponent<TextMeshProUGUI>().text = shopMonsters.monsters[i].monsterName;
                GameObject.Find(("Price (" + i + ")")).GetComponent<TextMeshProUGUI>().text = shopMonsters.monsters[i].monsterPrice.ToString();
                GameObject.Find("MonsterImage ("+ i +")").GetComponent<Image>().sprite = shopMonsters.monsters[i].monsterSprite;
            }
        }
        
        // Update the buttons to active or inactive buttons according to the candy count
        private void UpdateShopButtons()
        {
            for(int i = 0; i < shopButtons.Length; i++)
            {   
                if(shopMonsters.monsters[i].isUnlocked)
                {
                    shopButtons[i].interactable = false;
                }
                else
                {
                    if(candyCounts >= shopMonsters.monsters[i].monsterPrice)
                    {
                        shopButtons[i].interactable = true;
                    }
                    else
                    {
                        shopButtons[i].interactable = false;
                    }
                }
            }
        }
        // Show the monsters description
        public void ShowDescription(int monsterIndex)
        {
            _descriptionBox.SetActive(true);
            GameObject.Find("MonsterName").GetComponent<TextMeshProUGUI>().text = shopMonsters.monsters[monsterIndex].monsterName;
            GameObject.Find("Description").GetComponent<TextMeshProUGUI>().text = shopMonsters.monsters[monsterIndex].description;

        }

        public void ClearDescription()
        {   
            GameObject.Find("MonsterName").GetComponent<TextMeshProUGUI>().text = "Witch";
            GameObject.Find("Description").GetComponent<TextMeshProUGUI>().text = "Welcome to the shop, is there anything you want?";
        }
        
        private void ShowConfirmationBox()
        {   
            _monsterImage.sprite = shopMonsters.monsters[_buyIndex].monsterSprite;
            _confirmationBox.SetActive(true);
        }

        private void HideConfirmationBox()
        {
            _confirmationBox.SetActive(false);
        }
    }
}
