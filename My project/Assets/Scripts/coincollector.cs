using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System.Text;
using System;

public class coincollector : MonoBehaviour
{
    public static coincollector instance;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    private const string CoinPlayerPrefsKey = "CoinCount";
    private const string CoinHashKey = "CoinHash";
    private const string Salt = "your-salt";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadCoinCount();
        UpdateCoinText();
    }

    private void OnDestroy()
    {
        SaveCoinCount();
    }

    public void AddCoin_5()
    {
        coinCount += 5;
        UpdateCoinText();
    }

    public void AddCoin_25()
    {
        coinCount += 25;
        UpdateCoinText();
    }

    public void AddCoin_500()
    {
        coinCount += 500;
        UpdateCoinText();
    }

    public void AddCoin_100()
    {
        coinCount += 100;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = coinCount.ToString();
    }

    public void SaveCoinCount()
    {
        PlayerPrefs.SetInt(CoinPlayerPrefsKey, coinCount);
        PlayerPrefs.SetString(CoinHashKey, GetHash(coinCount.ToString()));
        PlayerPrefs.Save();
    }

    private void LoadCoinCount()
    {
        if (PlayerPrefs.HasKey(CoinPlayerPrefsKey) && PlayerPrefs.HasKey(CoinHashKey))
        {
            int savedCoinCount = PlayerPrefs.GetInt(CoinPlayerPrefsKey);
            string savedHash = PlayerPrefs.GetString(CoinHashKey);
            if (savedHash == GetHash(savedCoinCount.ToString()))
            {
                coinCount = savedCoinCount;
            }
            else
            {
                Debug.LogWarning("Coin count hash mismatch! Data might be tampered.");
                coinCount = 0;
            }
        }
    }

    private string GetHash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + Salt);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

}