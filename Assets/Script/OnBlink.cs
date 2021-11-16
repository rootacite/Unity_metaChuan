using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBlink : MonoBehaviour
{
    void Blink()
    {
        var lsc = this.gameObject.transform.localScale;
        float ls_rate_x = lsc.x;
        float ls_rate_y = lsc.y;

        float moved_rate = 0;

        float time = 0.24f;

        IEnumerator Vx()
        {
            while (moved_rate <= 0.11f)
            {
                moved_rate += (0.11f / time) / 100f;


                this.gameObject.transform.localScale = new Vector3(ls_rate_x - moved_rate, ls_rate_y + moved_rate, 1);
                yield return new WaitForSecondsRealtime(time / 100f);
            }

            while (moved_rate >= 0f)
            {
                moved_rate -= (0.11f / time) / 100f;


                this.gameObject.transform.localScale = new Vector3(ls_rate_x - moved_rate, ls_rate_y + moved_rate, 1);
                yield return new WaitForSecondsRealtime(time / 100f);
            }

            yield break;

        }

        StartCoroutine(Vx());
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
