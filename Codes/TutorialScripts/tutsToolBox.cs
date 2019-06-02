using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutsToolBox : MonoBehaviour
{
    [SerializeField]
    GameObject ChangeTireTutorial;

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
        for (int i = 0; i < players; i++)
        {
            index[i] = PlayerPrefs.GetInt(strings[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            Debug.Log(collision.transform.GetComponent<UserMovement>().charIndexNumber);
            int index = collision.transform.GetComponent<UserMovement>().charIndexNumber;
            if (Input.GetKeyDown(kc[this.index[index]]))
            {
                GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<objectLocation>().placeObject(transform.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log(collision.transform.GetComponent<UserMovement>().charIndexNumber);
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    
}
