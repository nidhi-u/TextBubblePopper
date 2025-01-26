using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverDropShadow : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Shadow shadow;

    void Start()
    {
        image = GetComponent<Image>();

        shadow = GetComponent<Shadow>();
        if (shadow == null)
        {
            shadow = gameObject.AddComponent<Shadow>();
        }

        shadow.effectDistance = new Vector2(20, -3);  
        shadow.effectColor = new Color(0, 0, 0, 0.5f);  
        shadow.enabled = false;  
    }

    public void OnPointerEnter()
    {
        shadow.enabled = true; 
    }

    public void OnPointerExit()
    {
        shadow.enabled = false; 
    }
}
