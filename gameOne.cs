using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOne : MonoBehaviour
{
    [SerializeField]
    Image[] images;

    GameObject parentWheel;
    float axisValues;
    List<float> values;
    List<string> string_val;

    bool lost, ps, xb;
    string pName;

    int count, counter, dPadIndex;
    int number, str_num;

    float[] valuess;
    string[] strinngss;

    int players;
    int[] index;
    string[] strings;

    private void Awake()
    {
        ps = true;
        xb = true;
        axisValues = 0f;
        players = PlayerPrefs.GetInt("Active_Users");
        index = new int[players];
        strings = new string[4] { "one", "two", "three", "four" };
    }

    // Start is called before the first frame update
    void Start()
    {
        lost = false;
        values = new List<float>();
        string_val = new List<string>();

        count = 0;
        counter = 0;

        number = values.Count;
        str_num = string_val.Count;

        valuess = new float[2] { -1f, 1f };
        strinngss = new string[2] { "Y", "X" };

        for (int i = 0; i < players; i++)
        {
            index[i] = PlayerPrefs.GetInt(strings[i]);
        }

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
    }

    //Update is called once per frame
    void Update()
    {
        if (values.Count < 5 || string_val.Count < 5)
        {

            if (values.Count != 5)
            {
                int rand = Random.Range(0, 3);

                if (rand != 0)
                {

                    if (rand == 1)
                    {
                        values.Add(valuess[1]);
                    }
                    else
                    {
                        values.Add(valuess[0]);
                    }
                }
            }

            if (string_val.Count != 5)
            {
                int Srand = Random.Range(0, 3);

                if (Srand != 0)
                {
                    if (Srand == 1)
                    {
                        string_val.Add(strinngss[1]);

                    }
                    else
                    {
                        string_val.Add(strinngss[0]);
                    }
                }
            }

        }

        if (values.Count == 5 && string_val.Count == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                if (values[i] == 1)
                {
                    if (string_val[i] == "X")
                    {
                        images[i].rectTransform.localEulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        images[i].rectTransform.localEulerAngles = new Vector3(0, 0, 90);
                    }
                }
                else
                {
                    if (string_val[i] == "X")
                    {
                        images[i].rectTransform.localEulerAngles = new Vector3(0, 0, 180);
                    }
                    else
                    {
                        images[i].rectTransform.localEulerAngles = new Vector3(0, 0, 270);
                    }
                }

            }
        }

    }

    private void LateUpdate()
    {

        if (count > 4)
        {
            parentWheel.GetComponent<problemOne>().dettachAllowed = true;
            Destroy(gameObject);
        }

        if (lost)
        {
            //parentWheel.GetComponent<Tire_Stats>().Over = true;
            //Destroy(gameObject);
        }
        else if (values.Count == 5 && string_val.Count == 5)
        {
            if (count < 5 && xb)
            {
                if (string_val[count] == "Y")
                {
                    
                    if (Input.GetAxis((index[dPadIndex] + 1) + "PDpadV") < 0 || Input.GetAxis((index[dPadIndex] + 1) + "PDpadV") > 0)
                    {
                        if (Input.GetAxis((index[dPadIndex] + 1) + "PDpadV") == values[count])
                        {
                            count++;
                            ps = false;
                        }
                    }
                }
                else if (string_val[count] == "X")
                {
                    if (Input.GetAxis((index[dPadIndex] + 1) + "PDpadH") < 0 || Input.GetAxis((index[dPadIndex] + 1) + "PDpadH") > 0)
                    {
                        if (Input.GetAxis((index[dPadIndex] + 1) + "PDpadH") == values[count])
                        {
                            count++;
                            ps = false;
                        }
                    }
                }

            }

        }
    }

    public string PName
    {
        get
        {
            return pName;
        }

        set
        {
            pName = value;
        }
    }

    public bool Lost
    {
        get
        {
            return lost;
        }

        set
        {
            lost = value;
        }
    }

    public GameObject ParentWheel
    {
        get
        {
            return parentWheel;
        }

        set
        {
            parentWheel = value;
        }
    }
}
