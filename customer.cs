using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class customer : MonoBehaviour
{
    [SerializeField]
    GameObject dynamicCustomers;

    TextMeshProUGUI tm, cc;
    
    public int totalCustomers;
    public int currentCustomers;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
        cc = dynamicCustomers.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = totalCustomers.ToString();
        cc.text = currentCustomers.ToString();

    }

    
}
