using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ConvoManager : MonoBehaviour
{
    [SerializeField] private ConvoSO convoSO;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < convoSO.Conversations.Count; i++)
        {
            UnityEngine.Debug.Log(convoSO.Conversations[i]);
        }
    }

    
}
