using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class ConvoManager : MonoBehaviour
{
    [SerializeField] private ConvoSO convoSO;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject textImg;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < convoSO.Conversations.Count; i++)
        {
            UnityEngine.Debug.Log(convoSO.Conversations[i]);
        }
        StartCoroutine(PlayConvo());
    }

    IEnumerator PlayConvo()
    {
        for (int i = 0; i < convoSO.Conversations.Count; i++)
        {
            text.text = convoSO.Conversations[i];
            textImg.transform.Rotate(0, 180, 0, Space.Self);
            text.gameObject.transform.Rotate(0, 180, 0, Space.Self);
            yield return new WaitForSeconds(2.5f);
        }
    }
    
}
