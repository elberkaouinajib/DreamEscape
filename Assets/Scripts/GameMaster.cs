using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameMaster : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinsText;

    private void Start() {
        
    }

    private void Update() {
        coinsText.text=("Coins : "+coins);
    }
}
