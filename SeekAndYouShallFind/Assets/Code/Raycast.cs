using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private GameObject raycastObject;
    [SerializeField]
    private float rayLength = 1f;
    [SerializeField]
    private LayerMask layerMaskInteract;
    [SerializeField]
    private Image crosshair;
    [SerializeField]
    private GameObject iF;
    [SerializeField]
    private CameraLook cL;
    [SerializeField]
    private PlayerMovement pM;
    private bool crosshairState;
    [SerializeField]
    private int cities= 0;
    [SerializeField]
    private GameObject lid;
    [SerializeField]
    private GameObject txt;
    [SerializeField]
    private GameObject relic2;
    [SerializeField]
    private Chalice cH;
    [SerializeField]
    private GameObject door;
    private int relicCount = 0;
    void Start()
    {
        crosshairState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TabernacleUnlock();
        }
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast (transform.position, forward, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Interact") || hit.collider.CompareTag("Book"))
            {
                raycastObject = hit.collider.gameObject;
                CrosshairActive();
                crosshairState = true;

                if (Input.GetKeyDown(KeyCode.Mouse0) && raycastObject.name == "Cube.002")
                {
                    TabernacleLock();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && raycastObject.name == "Rome")
                {
                    cities = cities + 1;
                    Destroy(raycastObject);
                    Cities();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && raycastObject.name == "Constantinople")
                {
                    cities = cities + 1;
                    Destroy(raycastObject);
                    Cities();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && raycastObject.name == "Moscow")
                {
                    cities = cities + 1;
                    Destroy(raycastObject);
                    Cities();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && raycastObject.name == "Relic1" || (Input.GetKeyDown(KeyCode.Mouse0) && raycastObject.name == "Relic2"))
                {
                    relicCount = relicCount + 1;
                    Destroy(raycastObject);
                    Relic();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && raycastObject.name == "chalice")
                {
                    Destroy(raycastObject);
                    Door();
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
        crosshair.color = Color.magenta;
    }
    void CrosshairInactive()
    {
        crosshair.color = Color.white;
        crosshairState = false;
    }
    public void TabernacleLock()
    {
        iF.SetActive(true);
        txt.SetActive(true);
        cL.enabled = false;
        pM.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public void TabernacleUnlock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        iF.SetActive(false);
        txt.SetActive(false);
        cL.enabled = true;
        pM.enabled = true;
    }
    public void Cities()
    {
        if (cities== 3)
        {
            Destroy(lid);
            relic2.transform.Translate(0, 0.5f, 0);
        }
    }
    public void Relic()
    {
        if (relicCount== 2)
        {
            cH.Drop();
        }
    }
    public void Door()
    {
        door.SetActive(false);
    }
}
