using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
    // Start is called before the first frame update
    private double BPM = 107.0;
    public Sprite[] Cs;
    IEnumerator Timer()
    {
        int beat = 0;
        int index = 1;
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
                IEnumerator Rise()
                {
                    float time = (float)(60f / BPM);

                    while (gameObject.transform.localPosition.y <= 0)
                    {
                        var oldp = gameObject.transform.localPosition;
                        oldp.y += 10 / 50f;
                        gameObject.transform.localPosition = oldp;
                        yield return new WaitForSecondsRealtime(time / 100f);
                    }
                }

                StartCoroutine(Rise());
            }
            if (cb == 2)
            {
                IEnumerator Rs()
                {
                    bool rd = true;
                    while (true)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = Cs[index];

                        if (rd)
                        {
                            index++;
                            if (index == 4) rd = false;
                        }
                        else
                        {
                            index--;
                            if (index == 1) rd = true;
                        }

                        yield return new WaitForSecondsRealtime((float)(60.0 / BPM / 2));
                    }
                }
                StartCoroutine(Rs());
            }
            beat++;
            yield return new WaitForSecondsRealtime((float)(60.0 / BPM / 4));
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
