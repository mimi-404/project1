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

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "   " + coinCount;
    }
}
