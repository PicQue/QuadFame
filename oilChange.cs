using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilChange : MonoBehaviour
{

    [SerializeField]
    GameObject gThree, oilChangeIcon, oilChangeIcon2;

    [SerializeField]
    carManager cm;

    [SerializeField]
    int oilNumber;
    
    GameObject g_Three;
    public bool sendCond, fail;

    int players;
    int[] index;
    string[] strings;
    KeyCode[] kc;
    private void Awake()
    {
        players = PlayerPrefs.GetInt("Active_Users");
        index = new int[players];
        strings = new string[4] { "one", "two", "three", "four" };
        kc = new KeyCode[4] { KeyCode.Joystick1Button0, KeyCode.Joystick2Button0, KeyCode.Joystick3Button0, KeyCode.Joystick4Button0 };
    }
    // Start is called before the first frame update
    void Start()
    {
        sendCond = false; fail = false;
        for (int i = 0; i < players; i++)
        {
            index[i] = PlayerPrefs.GetInt(strings[i]);
        }

        if(cm.faults < 3)
        {
            if (oilNumber == 1)
            {
                oilChangeIcon.SetActive(true);
            }
            else
            {
                oilChangeIcon2.SetActive(true);
            }
            cm.faults += 1;
        }

        g_Three = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (sendCond)
        {
            cm.faults -= 1;
            sendCond = false;
            Destroy(gameObject);
        }
        if (fail)
        {
            if (oilNumber == 1)
            {
                oilChangeIcon.SetActive(true);
            }
            else
            {
                oilChangeIcon2.SetActive(true);
            }

            fail = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            objectLocation pOL = collision.transform.GetComponent<objectLocation>();
            if (Input.GetKeyDown(kc[index[collision.transform.GetComponent<UserMovement>().charIndexNumber]]))
            {
                if (oilNumber == 1)
                {
                    if (pOL.sendTag() == "orangeOil")
                    {
                        g_Three = Instantiate(gThree, new Vector3(transform.position.x, 8, transform.position.z), Quaternion.identity);
                        oilChangeIcon.SetActive(false);
                        g_Three.GetComponent<gameThree>().pName = collision.transform.name;
                        g_Three.GetComponent<gameThree>().summoner = gameObject;
                        Destroy(collision.transform.Find(pOL.sendTag()), 5);
                    }
                }

                if(oilNumber == 2)
                {
                    if (pOL.sendTag() == "blackOil")
                    {
                        g_Three = Instantiate(gThree, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.identity);
                        oilChangeIcon2.SetActive(false);
                        g_Three.GetComponent<gameThree>().pName = collision.transform.name;
                        g_Three.GetComponent<gameThree>().summoner = gameObject;
                        Destroy(collision.transform.Find(pOL.sendTag()), 5);
                    }
                }
                
            }
        }
    }
}
