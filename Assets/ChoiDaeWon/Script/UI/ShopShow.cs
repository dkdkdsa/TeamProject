using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShopShow : MonoBehaviour
{

    [SerializeField] private GameObject slotParent;

    private ShopCore core;
    private SlotShow[] slots;
    private bool isReset;

    private void Awake()
    {

        core = FindObjectOfType<ShopCore>();
        isReset = true;
        slots = GetComponentsInChildren<SlotShow>();

    }

    public void Disable()
    {

        transform.DOLocalMove(new Vector2(0, 1100), 1).SetEase(Ease.OutBounce);

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

            core.SetShopSlot(out Sprite sprite, out string name);
            slots[i].Show(sprite);
            ShopSlot slot = slots[i].GetComponent<ShopSlot>();
            slot.itemName = name;
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


        yield return new WaitForSeconds(0.2f);

        StartCoroutine(SlotShowCo());

    }

}
