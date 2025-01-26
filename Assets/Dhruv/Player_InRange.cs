using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_InRange : MonoBehaviour
{
    [SerializeField] GameObject MiniGame_; 

    void Start()
    {
        MiniGame_.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        MiniGame_.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        MiniGame_.gameObject.SetActive(false);
    }


}
