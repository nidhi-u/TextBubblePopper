using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_InRange : MonoBehaviour
{
    [SerializeField] GameObject MiniGame_;
    [SerializeField] GameObject MiniGame;

    private bool InRange;
    void Start()
    {
        MiniGame_.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        InRange = true;
        MiniGame_.gameObject.SetActive(true);
        convo.StartConvo();
    }

    private void OnTriggerExit(Collider other)
    {
        InRange = false;
        MiniGame_.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (InRange) {
            if (Input.GetKeyDown(KeyCode.E)) {
                MiniGame.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                MiniGame.SetActive(false);
            }
        }
        else{
            MiniGame.SetActive(false);
        }
    }


}
