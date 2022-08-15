using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseItemData : MonoBehaviour {
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount; // ref to text object that displays the number of items in the player's system

    private void Awake() {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }
}