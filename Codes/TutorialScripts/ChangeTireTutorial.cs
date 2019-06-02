using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTireTutorial : MonoBehaviour
{
    //progress of tutorial
    int progress;

    bool toolBoxEquipped;
    // Start is called before the first frame update
    void Start()
    {
        progress = 0;
        toolBoxEquipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(progress == 0)
        {

        }
    }

    void AddProgress()
    {
        progress++;
    }

    public void toolBoxEquippedByPlayer()
    {
        toolBoxEquipped = true;
    }
}
