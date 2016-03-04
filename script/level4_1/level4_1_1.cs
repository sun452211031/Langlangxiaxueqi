using UnityEngine;
using System.Collections;

public class level4_1_1 : MonoBehaviour
{
    IEnumerator ChangeColor1()
    {
        float speed = 0.0f;
        while (speed < 1)
        {
            speed += Time.deltaTime;
            this.renderer.sharedMaterial.color = Color.Lerp(new Color(0.82f, 0.4f, 0.24f, 1), new Color(0.59f, 0.59f, 0.59f, 1), speed);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator ChangeColor2()
    {
        float speed = 0.0f;
        while (speed < 1)
        {
            speed += 0.5f * Time.deltaTime;
            this.renderer.sharedMaterial.color = Color.Lerp(new Color(0.59f, 0.59f, 0.59f, 1), new Color(0.82f, 0.4f, 0.24f, 1), speed);
            yield return new WaitForEndOfFrame();
        }
    }
}
