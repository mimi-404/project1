using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonImageChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage;
    public Sprite normalImage;
    public Sprite pressedImage;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        audioManager.PlaySFX(audioManager.engine);
        buttonImage.sprite = pressedImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //audioManager.PlaySFX(audioManager.engine);
        buttonImage.sprite = normalImage;
    }
}
