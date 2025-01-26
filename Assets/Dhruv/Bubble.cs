using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bubble : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string bubbleType; // Use this to identify matching bubbles

    public void OnPointerDown(PointerEventData eventData)
    {
        MiniGame_Manager.Instance.SelectBubble(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MiniGame_Manager.Instance.ReleaseBubble();
    }
}