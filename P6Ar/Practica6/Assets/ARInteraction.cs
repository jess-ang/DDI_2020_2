using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInteraction : MonoBehaviour
{
    public GameObject answer;

    void OnMouseDown()
    {
        answer.SetActive(true);
        Debug.Log("Capturando");
        Destroy(this.gameObject);
    }
}
