using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniGame_Manager : MonoBehaviour
{
    public static MiniGame_Manager Instance;

    public LineRenderer lineRendererPrefab;
    private LineRenderer currentLine;
    private Bubble selectedBubble;
    private List<Bubble> bubbles = new List<Bubble>();

    public Camera uiCamera;

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

        //uiCamera = Camera.main;
    }

    private void Start()
    {
        // Find all bubbles in the canvas
        bubbles.AddRange(FindObjectsOfType<Bubble>());
    }

    public void SelectBubble(Bubble bubble)
    {
        selectedBubble = bubble;
        currentLine = Instantiate(lineRendererPrefab);
        currentLine.positionCount = 2;
        currentLine.SetPosition(0, bubble.GetWorldPosition());
    }

    public void ReleaseBubble()
    {
        if (selectedBubble != null && currentLine != null)
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

            Destroy(currentLine.gameObject);
            selectedBubble = null;
        }
    }

    private void Update()
    {
        if (currentLine != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10; // Set this to an appropriate distance from the camera
            Vector3 worldPosition = uiCamera.ScreenToWorldPoint(mousePosition);
            currentLine.SetPosition(1, worldPosition);
        }
    }

    private GameObject GetObjectUnderMouse()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

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
