using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalice : MonoBehaviour
{
    [SerializeField]
    private GameObject rB;
    void Start()
    {
        
    }

    public void Drop()
    {
        rB.SetActive(true);
    }
}
