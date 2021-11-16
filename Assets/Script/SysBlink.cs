using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SysBlink : MonoBehaviour
{
    public GameObject CH1;
    public GameObject CH2;
    public GameObject CH3;
    public GameObject CH4;
    public GameObject CH5;
    public GameObject CH6;
    public GameObject CH7;
    public GameObject CH8;
    public GameObject CH9;
    public GameObject CH10;
    public GameObject CH11;
    public GameObject CH12;

    public GameObject BK1;
    public GameObject BK3;
        public GameObject BK4;
    public GameObject BK5;

    public GameObject MC;
    private double BPM = 107.0;
    [DllImport("winmm")]
    static extern void timeBeginPeriod(int t);
    [DllImport("winmm")]
    static extern void timeEndPeriod(int t);
    public IEnumerator SlowChange(GameObject g1, GameObject g2)
    {
        SpriteRenderer s1 = g1.GetComponent<SpriteRenderer>();
        SpriteRenderer s2 = g2.GetComponent<SpriteRenderer>();
        s1.color = Color.white;
        s1.color = new Color(1, 1, 1, 0);

        float chsa = 0f;

        while (chsa <= 1)
        {
            s1.color = new Color(1, 1, 1, 1 - chsa);
            s2.color = new Color(1, 1, 1, chsa);
            chsa += 0.01f;

            yield return new WaitForSecondsRealtime(0.01f / 8f);
        }
    }

    IEnumerator TimerToBlink()
    {
        GameObject.Find("BGM").GetComponent<AudioSource>().Play();
        BroadcastMessage("Blink");

        while (true)
        {
            yield return new WaitForSecondsRealtime((float)(60.0 / BPM));
            BroadcastMessage("Blink");
        }
    }

    IEnumerator Timer()
    {
        GameObject cv1 = null;
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
                Clist.Add(Instantiate(CH1));
                Clist[0].transform.parent = MC.transform;
            }
            if (cb == 2)
            {
                IEnumerator cs1()
                {
                    var ch2 = Instantiate(CH2);
                    var bk1 = Instantiate(BK1);
                    ch2.transform.parent = MC.transform;


                    SlowChange(Clist[0], ch2);
                    yield return SlowChange(GameObject.Find("Square1"), ch2);

                    Clear();
                    Clist.Add(ch2);
                    Clist.Add(bk1);
                    yield break;
                }
               
                StartCoroutine(cs1());
            }
            if (cb == 3.5)
            {
                Clist.Add(Instantiate(CH3));
                Clist[2].transform.parent=MC.transform; ;
            }
            if(cb == 4)
            {
                Destroy(Clist[0]);
                Clist.RemoveAt(0);
                Destroy(Clist[0]);
                Clist.RemoveAt(0);

                Clist.Add(Instantiate(BK3));
            }
            if (cb == 8)
            {
                GameObject last;
                Clear();
                Clist.Add(Instantiate(BK4));
                Clist.Add(last = Instantiate(CH5));
                last.GetComponent<HC>().HandC();
                Clist.Add(last = Instantiate(last));
                var o1 = last.transform.localPosition;
                o1.x += 1;
                o1.y += 2.5f;
                o1.z += 0.5f;
                last.transform.localPosition = o1;
                Clist.Add(last = Instantiate(last));
                o1 = last.transform.localPosition;
                o1.x -= 1;
                o1.y += 2.5f;
                o1.z += 0.5f;
                last.transform.localPosition = o1;
                Clist.Add(last = Instantiate(last));
                o1 = last.transform.localPosition;
                o1.x += 1;
                o1.y += 2.5f;
                o1.z += 0.5f;
                last.transform.localPosition = o1;
                Clist.Add(last = Instantiate(last));
                o1 = last.transform.localPosition;
                o1.x -= 1;
                o1.y += 2.5f;
                o1.z += 0.5f;
                last.transform.localPosition = o1;

                bool first = true;
                foreach (var i in Clist)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }
                    i.transform.parent = Camera.main.transform;
                }

                IEnumerator MvCm()
                {
                    while (Camera.main.transform.localPosition.y <= 0.5f)
                    {
                        var olc = Camera.main.transform.localPosition;
                        olc.x += 0.0015f;
                        olc.y += 0.0015f;
                        Camera.main.transform.localPosition = olc;
                        yield return new WaitForSeconds(0.01f);
                    }
                }
                StartCoroutine(MvCm());
            }
            if (cb == 9)
            {
                Clist[2].GetComponent<HC>().HandC();
            }
            if (cb == 10)
            {
                Clist[3].GetComponent<HC>().HandC();
            }
            if (cb == 11)
            {
                GameObject last;
                Clist[4].GetComponent<HC>().HandC();
                Clist.Add(last = Instantiate(CH6));
                last.transform.parent = MC.transform;
                last.transform.localRotation = new Quaternion(0, -1, 0, 0);

            }
            if (cb == 12)
            {
                Clist[5].GetComponent<HC>().HandC();
            }
            if (cb == 14)
            {
                IEnumerator RV()
                {
                    while (Clist[6] != null)
                    {
                        Clist[6].transform.Rotate(Vector3.up, 18f);
                        yield return new WaitForSeconds(0.01f);
                    }
                }

                StartCoroutine(RV());
            }

            if (cb == 15)
            {
                Camera.main.transform.localPosition = new Vector3(0, 0, -10);
                Destroy(Clist[6]);
                Clist.RemoveAt(6);

                cv1 = Instantiate(CH7);
               
            }

            if (cb == 16)
            {
                Clear();

                Destroy(cv1);
                Clist.Add(Instantiate(CH1));
                Clist[0].transform.parent = MC.transform;
            }

            if (cb == 20)
            {
                IEnumerator cs1()
                {
                    var ch2 = Instantiate(CH2);
                    var bk1 = Instantiate(BK1);
                    ch2.transform.parent = MC.transform;


                    SlowChange(Clist[0], ch2);
                    yield return SlowChange(GameObject.Find("Square1"), ch2);

                    Clear();
                    Clist.Add(ch2);
                    Clist.Add(bk1);
                    yield break;
                }
                
                StartCoroutine(cs1());
            }


            if (cb == 24)
            {
                GameObject bnv;
                Clear();
                Clist.Add(bnv = Instantiate(CH8));
                Clist[0].transform.parent = MC.transform;

                IEnumerator MoveSXC()
                {
                    while (true)
                    {
                        var oldx = bnv.transform.localPosition;
                        oldx.x -= 0.05f;
                        bnv.transform.localPosition = oldx;
                        yield return new WaitForSeconds(0.01f);
                    }
                }
                Clist.Add(Instantiate(BK5));
                StartCoroutine(MoveSXC());
            }



            beat++;
            yield return new WaitForSecondsRealtime((float)(60.0 / BPM / 2));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(TimerToBlink());
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
