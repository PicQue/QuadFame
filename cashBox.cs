using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cashBox : MonoBehaviour
{
    [SerializeField]
    GameObject score;

    GameObject c,b;

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

        c = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log(Input.GetKeyDown(kc[index[collision.transform.GetComponent<UserMovement>().charIndexNumber]]));
            if (Input.GetKeyDown(kc[index[collision.transform.GetComponent<UserMovement>().charIndexNumber]]))
            {
                if (c == null)
                {
                    c = collision.transform.GetComponent<objectLocation>().getCar();
                    b = collision.transform.GetComponent<objectLocation>().getMon();
                }

                if (c != null)
                {
                    c.GetComponent<carMovement>().exit = true;
                    Destroy(b);
                    score.GetComponent<TMProTest>().Score += 10;
                }
                
            }
        }
    }
}
