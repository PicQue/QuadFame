using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectLocation : MonoBehaviour
{
    [SerializeField]
    private GameObject objLoc;

    [SerializeField]
    UserMovement um; 

    GameObject obj, manger, car, moneyz;

    int players;
    int[] index;
    string[] strings;
    KeyCode[] kc;
    private void Awake()
    {
        players = PlayerPrefs.GetInt("Active_Users");
        index = new int[players];
        strings = new string[4] { "one", "two", "three", "four" };
        kc = new KeyCode[4] { KeyCode.Joystick1Button1, KeyCode.Joystick2Button1, KeyCode.Joystick3Button1, KeyCode.Joystick4Button1};
    }
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < players; i++)
        {
            index[i] = PlayerPrefs.GetInt(strings[i]);
        }

        obj = null;
        car = null;moneyz = null;
        manger = GameObject.Find("manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(kc[index[um.charIndexNumber]]))
        {
            remObject();
        }
    }

    public void placeObject(GameObject objectToAdd)
    {

        if (obj == null)
        {
            obj = objectToAdd;
            obj.transform.SetParent(objLoc.transform);
            obj.transform.position = objLoc.transform.position;

            if (obj.GetComponent<BoxCollider>())
            {
                obj.GetComponent<BoxCollider>().enabled = false;
            }

            if (obj.tag != "Tool Box" && obj.GetComponent<tireManager>())
            {
                if (obj.GetComponent<tireManager>().nameSpawn != null)
                {
                    manger.GetComponent<manager>().addFault(obj.GetComponent<tireManager>().nameSpawn.name);
                }
            }
        }
    }

    public void remObject()
    {
        if (obj != null)
        {
            if (obj.GetComponent<BoxCollider>())
            {
                obj.GetComponent<BoxCollider>().enabled = true;
            }
            obj.transform.parent = null;
            obj = null;
            
        }
    }

    public string sendTag()
    {
        if(obj != null)
        {
            return obj.tag;
        }
        else
        {
            return "";
        }
    }

    public void deleteObj()
    {
        GameObject toDel;
        toDel = obj;
        Destroy(toDel);
        obj = null;
    }

    public void giveObject(GameObject gib)
    {
        GameObject temp;
        temp = obj;
        manger.GetComponent<manager>().remFault(temp.name);
        temp.transform.SetParent(gib.transform);
        temp.transform.localPosition = new Vector3 (0, 0, 0);
        temp.transform.localEulerAngles = new Vector3(1, 1, 1);
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.GetComponent<BoxCollider>().enabled = false;
        obj = null;
    }

    public void addCar(GameObject c)
    {
        if(car == null)
        {
            car = c;
        }
    }

    public void addMon(GameObject m)
    {
        if(moneyz == null)
        {
            moneyz = m;
        }
    }

    public void remCar()
    {
        car = null;
    }

    public GameObject getCar()
    {
        if(car != null)
        {
            return car;
        }

        return null;
    }

    public GameObject getMon()
    {
        if (moneyz != null)
        {
            return moneyz;
        }

        return null;
    }
}
