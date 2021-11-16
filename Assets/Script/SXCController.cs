using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SXCController : MonoBehaviour
{
    public Sprite[] Ania;
    IEnumerator ANV()
    {
        while (true)
            foreach (var i in Ania)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = i;
                yield return new WaitForSeconds(1 / 24f);
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ANV());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
