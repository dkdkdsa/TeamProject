using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShopShow : MonoBehaviour
{

    [SerializeField] private GameObject slotParent;

    private SlotShow[] slots;
    private bool isReset;

    private void Awake()
    {

        isReset = true;
        slots = GetComponentsInChildren<SlotShow>();

    }

    public void Show()
    {

        transform.DOLocalMove(Vector2.zero, 1).SetEase(Ease.OutBounce)
        .SetDelay(0.5f)
        .OnComplete(() => 
        {

            StartCoroutine(SlotShowCo());

        });

    }

    public void ResetUI()
    {

        if(isReset == false) StartCoroutine(ResetCo());

    }

    IEnumerator SlotShowCo()
    {

        yield return null;
        for(int i = 0; i < slots.Length; i++)
        {

            slots[i].Show();
            yield return new WaitForSeconds(0.2f);

        }

        yield return new WaitForSeconds(1f);
        isReset = false;

    }

    IEnumerator ResetCo()
    {

        isReset = true;
        yield return null;
        for (int i = 0; i < slots.Length; i++)
        {

            slots[i].UIReset();
            yield return new WaitForSeconds(0.1f);

        }


        yield return null; new WaitForSeconds(1f);

        StartCoroutine(SlotShowCo());

    }

}
