using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> npcs;
    private List<int> interacted = new List<int>();
    private bool gameDone = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateNPC());
    }

    IEnumerator ActivateNPC()
    {
        yield return new WaitForSeconds(2);
        while (interacted.Count < npcs.Count)
        {
            if(gameDone)
            {
                int index = Random.Range(0, npcs.Count);
                if (!interacted.Contains(index))
                {
                    npcs[index].SetActive(true);
                    interacted.Add(index);
                    gameDone = false;
                }
                
            }
            // activate after first minigame is done
            yield return new WaitForSeconds(2);

        }
        EndGame();
    }

    public void NextConvo()
    {
        gameDone = false;
    }

    void EndGame()
    {
        Debug.Log("Game over!");
    }
}
