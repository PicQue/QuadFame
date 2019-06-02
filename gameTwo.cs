using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameTwo : MonoBehaviour
{
    [SerializeField]
    Image fil;

    public GameObject summoner;

    public string pName;

    int players, dPadIndex;
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

        fil.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (pName)
        {

            case "Rose_Collider(Clone)":

                dPadIndex = 0;

                break;

            case "Sean_Collider(Clone)":

                dPadIndex = 1;

                break;

            case "Mae_Collider(Clone)":

                dPadIndex = 2;

                break;

            case "Josh_Collider(Clone)":

                dPadIndex = 3;

                break;
        }




        if (Input.GetKeyDown(kc[index[dPadIndex]]))
        {
            Debug.Log(pName);
            fil.fillAmount += 0.1f;
        }
        else if (fil.fillAmount > 0.1f)
        {
            fil.fillAmount -= 0.01f;
        }


        if (fil.fillAmount > 0.9f)
        {
            summoner.GetComponent<problemTwo>().sendTM();
            Destroy(gameObject);
        }
    }
}
