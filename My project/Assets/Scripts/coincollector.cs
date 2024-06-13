using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coincollector : MonoBehaviour
{
    public static coincollector instance;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    private const string CoinPlayerPrefsKey = "CoinCount";

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

    private void SaveCoinCount()
    {
        PlayerPrefs.SetInt(CoinPlayerPrefsKey, coinCount);
        PlayerPrefs.Save(); 
    }

    private void LoadCoinCount()
    {
        if (PlayerPrefs.HasKey(CoinPlayerPrefsKey))
        {
            coinCount = PlayerPrefs.GetInt(CoinPlayerPrefsKey);
        }
    }
}
