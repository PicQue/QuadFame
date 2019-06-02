using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addWheels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            objectLocation pOL = other.GetComponent<objectLocation>();
            if (pOL.sendTag() == "tire")
            {
                pOL.giveObject(gameObject);
            }
        }
    }
}
