using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHello : MonoBehaviour
{
    // Start is called before the first frame update
    private double BPM = 107.0;
    public Sprite HandonS;
    IEnumerator Timer()
    {
        int beat = 0;
        List<GameObject> Clist = new List<GameObject>();

        void Clear()
        {
            foreach (var i in Clist) Destroy(i);
            Clist.Clear();
        }

        while (true)
        {
            double cb = beat / 2d;

            if (beat == 0)
            {
                gameObject.GetComponent<Animation>().Play();
            }
            if (cb == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = HandonS;
                this.transform.position = new Vector3(0, 0, -9);
            }
            beat++;
            yield return new WaitForSecondsRealtime((float)(60.0 / BPM / 2));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
