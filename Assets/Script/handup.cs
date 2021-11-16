using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handup : MonoBehaviour
{
    public Sprite UpHand;
    public GameObject Next;
    void MyBlink()
    {
        var lsc = this.gameObject.transform.localScale;
        float ls_rate_x = 1;
        float ls_rate_y = 1;

        float moved_rate = 0;

        float time = 0.3f;

        IEnumerator Vx()
        {
            while (moved_rate <= 0.35f)
            {
                moved_rate += (0.35f / time) / 100f;


                this.gameObject.transform.localScale = new Vector3(ls_rate_x - moved_rate, ls_rate_y + moved_rate, 1);
                yield return new WaitForSecondsRealtime(time / 100f);
            }
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = UpHand;
            while (moved_rate >= 0f)
            {
                moved_rate -= (0.35f / time) / 100f;


                this.gameObject.transform.localScale = new Vector3(ls_rate_x - moved_rate, ls_rate_y + moved_rate, 1);
                yield return new WaitForSecondsRealtime(time / 100f);
            }
            
            yield break;

        }

        StartCoroutine(Vx());
    }
    public void OnHand()
    {
        MyBlink();
        if (Next != null)
        {
            IEnumerator VBN()
            {
                yield return new WaitForSeconds(0.075f);
                Next.GetComponent<handup>().OnHand();
            }
            StartCoroutine(VBN());
        }
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
