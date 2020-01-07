using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputBox : MonoBehaviour
{
    [SerializeField]
    private GameObject iF;
    [SerializeField]
    private Raycast rCast;
    [SerializeField]
    private GameObject padlock;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject txt;
    private string password;
    
    // Start is called before the first frame update
    void Start()
    {
        iF.SetActive(false);
        txt.SetActive(false);
    }
    public void Password()
    {
        password = iF.GetComponentInChildren<Text>().text;
        if (password =="water" || password == "Water" || password == "WATER")
        {
            rCast.TabernacleUnlock();
            padlock.GetComponent<Rigidbody>().isKinematic = false;
            door.SetActive(false);
        }
    }
}
