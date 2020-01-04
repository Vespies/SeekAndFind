using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private GameObject raycastObject;
    [SerializeField]
    private float rayLength = 10f;
    [SerializeField]
    private LayerMask layerMaskInteract;
    [SerializeField]
    private Image crosshair;
    private bool crosshairState;
    void Start()
    {
        crosshairState = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast (transform.position, forward, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Interact"))
            {
                raycastObject = hit.collider.gameObject;
                CrosshairActive();
                crosshairState = true;

                if (Input.GetKeyDown("e"))
                {
                    raycastObject.SetActive(false);
                }
            }
        }
        else
        {
            if (crosshairState)
            {
                CrosshairInactive();
            }

        }
    }
    void CrosshairActive()
    {
        crosshair.color = Color.red;
    }
    void CrosshairInactive()
    {
        crosshair.color = Color.white;
        crosshairState = false;
    }
}
