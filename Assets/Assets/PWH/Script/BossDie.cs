using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossDie : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DIE");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator DIE()
    {
        yield return new WaitForSeconds(3);
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(2);
        panel.transform.DOLocalMove(new Vector3(0, 0, 0), 1.5f);
    }
}
