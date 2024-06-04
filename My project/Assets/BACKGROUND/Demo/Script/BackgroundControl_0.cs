using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl_0 : MonoBehaviour
{
    [Header("BackgroundNum 0 -> 3")]
    public int backgroundNum;
    public Sprite[] Layer_Sprites;
    private GameObject[] Layer_Object = new GameObject[5];
    private int max_backgroundNum = 3;
    public float transitionInterval = 5.0f; // Time in seconds between transitions

    void Start()
    {
        for (int i = 0; i < Layer_Object.Length; i++)
        {
            Layer_Object[i] = GameObject.Find("Layer_" + i);
        }

        ChangeSprite();
        StartCoroutine(AutoTransition());
    }

    void ChangeSprite()
    {
        // Change the sprite for Layer_0
        Layer_Object[0].GetComponent<SpriteRenderer>().sprite = Layer_Sprites[backgroundNum * 5];

        // Change the sprites for Layer_1 to Layer_3, excluding Layer_4
        for (int i = 1; i < Layer_Object.Length - 1; i++)
        {
            Sprite changeSprite = Layer_Sprites[backgroundNum * 5 + i];

            // Update Layer_i sprite
            Layer_Object[i].GetComponent<SpriteRenderer>().sprite = changeSprite;

            // Update "Layer_(i)x" sprites in children of Layer_i
            if (Layer_Object[i].transform.childCount >= 2)
            {
                Layer_Object[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = changeSprite;
                Layer_Object[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = changeSprite;
            }
            else
            {
                Debug.LogWarning("Layer_Object[" + i + "] doesn't have enough child objects to update sprites.");
            }
        }
    }

    IEnumerator AutoTransition()
    {
        while (true)
        {
            yield return new WaitForSeconds(transitionInterval);
            NextBG();
        }
    }

    public void NextBG()
    {
        backgroundNum = backgroundNum + 1;
        if (backgroundNum > max_backgroundNum) backgroundNum = 0;
        ChangeSprite();
    }
}
