using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expland : MonoBehaviour
{
    float rate = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0.05f, 0.05f, 1);

        IEnumerator sc()
        {
            while (rate <= 1)
            {
                this.transform.localScale = new Vector3(rate, rate, 1);
                rate += 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
        }

        StartCoroutine(sc());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
