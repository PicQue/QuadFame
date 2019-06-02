using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabletControls : MonoBehaviour
{
    [SerializeField]
    magMovement magnet;

    [SerializeField]
    string[] stationNames;

    [SerializeField]
    string endNodeName;

    [SerializeField]
    GameObject can, can2, R1;

    [SerializeField] Vector3[] rot;

    string saveOne, saveTwo;

    int players, sw;
    int[] index;
    string[] strings;
    KeyCode[] kc;
    KeyCode[] ka;
    KeyCode[] kb;
    KeyCode[] kd;
    KeyCode[] R1_;
    private void Awake()
    {
        saveOne = "";
        saveTwo = "";
        players = PlayerPrefs.GetInt("Active_Users");
        index = new int[players];
        strings = new string[4] { "one", "two", "three", "four" };
        kc = new KeyCode[4] { KeyCode.Joystick1Button0, KeyCode.Joystick2Button0, KeyCode.Joystick3Button0, KeyCode.Joystick4Button0 };
        ka = new KeyCode[4] { KeyCode.Joystick1Button1, KeyCode.Joystick2Button1, KeyCode.Joystick3Button1, KeyCode.Joystick4Button1 };
        kb = new KeyCode[4] { KeyCode.Joystick1Button2, KeyCode.Joystick2Button2, KeyCode.Joystick3Button2, KeyCode.Joystick4Button2 };
        kd = new KeyCode[4] { KeyCode.Joystick1Button3, KeyCode.Joystick2Button3, KeyCode.Joystick3Button3, KeyCode.Joystick4Button3 };
        R1_ = new KeyCode[4] { KeyCode.Joystick1Button5, KeyCode.Joystick2Button5, KeyCode.Joystick3Button5, KeyCode.Joystick4Button5 };
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < players; i++)
        {
            index[i] = PlayerPrefs.GetInt(strings[i]);
        }
        sw = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            int indie = collision.transform.GetComponent<UserMovement>().charIndexNumber;
            
            if(can2 != null)
            {
                R1.SetActive(true);
                if (Input.GetKeyDown(R1_[index[indie]]))
                {
                    Debug.Log("R1");
                    if (sw == 0)
                    {
                        sw++;
                    }
                    else
                    {
                        sw = 0;
                    }
                }
            }

            switch (sw)
            {
                case 0:

                    can.SetActive(true);

                    if(can2 != null)
                    {
                        can2.SetActive(false);
                    }
                    
                    if (Input.GetKeyDown(kb[index[indie]]))
                    {
                        magnet.GetComponent<magMovement>().goTo(stationNames[0]);
                    }
                    if (Input.GetKeyDown(ka[index[indie]]))
                    {
                        magnet.GetComponent<magMovement>().goTo(stationNames[1]);
                    }

                    if (Input.GetKeyDown(kc[index[indie]]))
                    {
                        magnet.GetComponent<magMovement>().goTo(stationNames[2]);
                    }

                    if (Input.GetKeyDown(kd[index[indie]]))
                    {
                        magnet.GetComponent<magMovement>().goTo(endNodeName);
                    }
                    break;

                case 1:

                    can.SetActive(false);
                    can2.SetActive(true);

                    if (Input.GetKeyDown(kb[index[indie]]))
                    {
                        magnet.GetComponent<magMovement>().goTo(stationNames[3]);
                    }
                    if (Input.GetKeyDown(ka[index[indie]]))
                    {
                        magnet.GetComponent<magMovement>().goTo(stationNames[4]);
                    }

                    if (Input.GetKeyDown(kc[index[indie]]))
                    {
                        magnet.GetComponent<magMovement>().goTo(stationNames[5]);
                    }

                    if (Input.GetKeyDown(kd[index[indie]]))
                    {
                        magnet.GetComponent<magMovement>().goTo(endNodeName);
                    }

                    break;
            }
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        can.SetActive(false);
        if(can2 != null)
        {
            can2.SetActive(false);
            R1.SetActive(false);
        }
        
        
    }
}
