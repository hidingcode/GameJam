using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Monster")]
public class Card : ScriptableObject
{
    public Sprite icon;
    public GameObject prefab;
    public float coolDown;

}
