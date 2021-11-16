using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HC : MonoBehaviour
{
    public GameObject startg;
    public void HandC()
    {
        startg.GetComponent<handup>().OnHand();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
