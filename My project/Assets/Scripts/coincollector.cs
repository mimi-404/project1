using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coincollector : MonoBehaviour
{
    public static coincollector instance;

    public TextMeshProUGUI coinText;
    private int coinCount = 0;

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
        UpdateCoinText();
    }

    public void AddCoin_5()
    {
        coinCount+=5;
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
        coinText.text = "   " + coinCount;
    }
}
