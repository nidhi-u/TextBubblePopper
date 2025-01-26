using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIn_range : MonoBehaviour
{
    [SerializeField] GameObject minigameButton_;

    private void Start()
    {
        minigameButton_.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        minigameButton_.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        minigameButton_.SetActive(false);
    }

}
