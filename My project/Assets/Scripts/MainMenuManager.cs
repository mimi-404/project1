using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;

    private const string CoinPlayerPrefsKey = "CoinCount";

    private void Start()
    {
        DisplayCoinCount();
    }

    private void DisplayCoinCount()
    {
        int coinCount = PlayerPrefs.GetInt(CoinPlayerPrefsKey, 0);
        coinCountText.text = "Coins:" + coinCount.ToString();
    }
}
