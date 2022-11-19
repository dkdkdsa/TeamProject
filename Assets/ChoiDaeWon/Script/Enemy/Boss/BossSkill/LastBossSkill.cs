using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LastBossSkill : MonoBehaviour
{

    private readonly int summonHash = Animator.StringToHash("Summon");
    private readonly int attackHash = Animator.StringToHash("Attack");
    private bool isSummonCool;
    private bool flip;
    private CinemachineBasicMultiChannelPerlin cbmcp;

    public void Skill(Animator animator, SpriteRenderer renderer)
    {

        if (!isSummonCool)
        {

            animator.SetTrigger(summonHash);
            StartCoroutine(SummoningCoolCo());

        }
        else
        {

            animator.SetTrigger(attackHash);
            flip = renderer.flipX;

        }

    }

    public void Slice()
    {

        Vector2 boxSize;
        boxSize = flip ? new Vector2(-3, 4) : new Vector2(3, 4);

        if(Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.zero, 0, LayerMask.GetMask("Player")))
        {

            GameManager.instance.PlayerTakeDamage(50f);

        }

    }

    public void Shack()
    {

        StartCoroutine(ShackCo());

    }
    public void Smmoning()
    {

        int r = Random.Range(1, 4);
        string s = "";
        s = r switch
        {

            1 => "Fire",
            2 => "Blue",
            3 => "Red",
            _ => "Fire"

        };

        PoolManager.instance.Remove(s, transform.position, Quaternion.identity);

    }

    IEnumerator SummoningCoolCo()
    {

        isSummonCool = true;
        yield return new WaitForSeconds(60f);
        isSummonCool = false;

    }

    private void Awake()
    {

        cbmcp = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    IEnumerator ShackCo()
    {

        cbmcp.m_AmplitudeGain += 3;
        cbmcp.m_FrequencyGain += 3;

        yield return new WaitForSeconds(0.1f);

        cbmcp.m_AmplitudeGain -= 3;
        cbmcp.m_FrequencyGain -= 3;

    }

}
