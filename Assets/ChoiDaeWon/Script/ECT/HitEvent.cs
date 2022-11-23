using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{

    private bool isHitCo;

    public void Hit()
    {

        if (!isHitCo)
        {

            StartCoroutine(HitCo());

        }

    }

    IEnumerator HitCo()
    {

        isHitCo = true;
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        Color[] colors = new Color[spriteRenderers.Length];

        yield return null;

        for(int i = 0; i < spriteRenderers.Length; i++)
        {

            colors[i] = spriteRenderers[i].color;

            spriteRenderers[i].color = Color.red;

            yield return null;

        }

        yield return new WaitForSeconds(0.05f);

        for (int i = 0; i < spriteRenderers.Length; i++)
        {


            spriteRenderers[i].color = colors[i];

            yield return null;

        }
        isHitCo = false;

    }

}
