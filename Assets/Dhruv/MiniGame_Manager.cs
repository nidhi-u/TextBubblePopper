using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniGame_Manager : MonoBehaviour
{
    public static MiniGame_Manager Instance;


   // public Image lineRendererPrefab;
   // private Image currentLine;
    private Bubble selectedBubble;
    private List<Bubble> bubbles = new List<Bubble>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Find all bubbles in the canvas
        bubbles.AddRange(FindObjectsOfType<Bubble>());
    }

    public void SelectBubble(Bubble bubble)
    {
        selectedBubble = bubble;
        Debug.Log("buuble :" + selectedBubble);
        //currentLine = Instantiate(lineRendererPrefab, bubble.transform.parent);
        //currentLine.transform.position = bubble.transform.position;
    }

    public void ReleaseBubble()
    {
        if (selectedBubble != null)
        {
            GameObject hitObject = GetObjectUnderMouse();

            if (hitObject != null)
            {
                Bubble releasedBubble = hitObject.GetComponent<Bubble>();
                if (releasedBubble != null && releasedBubble != selectedBubble)
                {
                    if (selectedBubble.bubbleType == releasedBubble.bubbleType)
                    {
                        // Match found, destroy both bubbles
                        bubbles.Remove(selectedBubble);
                        bubbles.Remove(releasedBubble);
                        Destroy(selectedBubble.gameObject);
                        Destroy(releasedBubble.gameObject);

                        CheckGameCompletion();
                    }
                }
            }

           // Destroy(currentLine.gameObject);
            selectedBubble = null;
        }
    }

    private void Update()
    {
/*        if (currentLine != null)
        {
            Vector2 mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                currentLine.transform.parent as RectTransform,
                Input.mousePosition, null, out mousePosition);
           // currentLine.transform.localPosition = mousePosition;
        }*/
    }

    private GameObject GetObjectUnderMouse()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        GameObject rres = results[0].gameObject;
        Debug.Log("awdawd:" + rres);
        return results.Count > 0 ? results[0].gameObject : null;
    }

    private void CheckGameCompletion()
    {
        if (bubbles.Count == 0)
        {
            Debug.Log("All bubbles matched! Game Over!");
            // Add any game completion logic here
        }
    }
}
