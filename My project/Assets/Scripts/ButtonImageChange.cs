using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonImageChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage; // Reference to the image component of the button
    public Sprite normalImage; // The normal image when button is not pressed
    public Sprite pressedImage; // The image when button is pressed

    // Called when mouse is pressed down on the button
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = pressedImage; // Change image to pressed image
    }

    // Called when mouse is released from the button
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = normalImage; // Change image to normal image
    }
}
