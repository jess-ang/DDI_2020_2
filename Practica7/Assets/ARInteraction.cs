using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInteraction : MonoBehaviour
{
    public Answer targetAnswer;
    public bool answerType;
    private AudioSource source;

    void OnMouseDown()
    {
        source = GetComponent<AudioSource>();
        source.Play();
        if(targetAnswer != null)
        {
            targetAnswer.ChangeMaterial(answerType);
        }
        // Debug.Log("Capturando");
        // Destroy(this.gameObject);
    }
}
