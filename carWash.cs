using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carWash : MonoBehaviour
{
    [SerializeField]
    GameObject icon;

    [SerializeField]
    carManager cm;

    int ran;
    bool sendcondition;

    int players;
    int[] index;
    string[] strings;
    KeyCode[] kc;

    // Start is called before the first frame update
    private void Awake()
    {
        sendcondition = false;
        players = PlayerPrefs.GetInt("Active_Users");
        index = new int[players];
        strings = new string[4] { "one", "two", "three", "four" };
        kc = new KeyCode[4] { KeyCode.Joystick1Button0, KeyCode.Joystick2Button0, KeyCode.Joystick3Button0, KeyCode.Joystick4Button0 };

        ran = Random.Range(0, 10);
        if (ran <= 7)
        {
            this.enabled = false;
        }
        else
        {
            icon.SetActive(true);
            cm.faults += 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sendcondition)
        {
            cm.faults -= 1;
            icon.SetActive(false);
            sendcondition = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            objectLocation pOL = collision.transform.GetComponent<objectLocation>();
            if (Input.GetKeyDown(kc[index[collision.transform.GetComponent<UserMovement>().charIndexNumber]]))
            {
                sendcondition = true;
            }
        }
    }
}
