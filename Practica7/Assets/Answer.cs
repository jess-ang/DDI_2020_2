using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public Material rightAnswerMaterial;
    public Material wrongAnswerMaterial;
    private Renderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    public void ChangeMaterial(bool answer)
    {
        myRenderer.material = answer ? rightAnswerMaterial : wrongAnswerMaterial;
    }
    
}
