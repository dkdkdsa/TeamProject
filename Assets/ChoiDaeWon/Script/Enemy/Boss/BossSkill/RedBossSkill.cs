using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RedBossSkill : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cvcam;

    private CinemachineBasicMultiChannelPerlin cbmcp;
    private bool isDash;
    private bool isDashShake;
    private bool isShake;
    private Vector3 endPos;

    private void Awake()
    {

        cbmcp = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    private void Update()
    {

        if (isDash)
        {

            transform.position = Vector2.MoveTowards(transform.position, endPos, 30 * Time.deltaTime);

        }

        if(endPos == transform.position)
        {

            isDash = false;

        }

    }

    public void Shake()
    {

        StartCoroutine(ShackCo());

    }

    public void DashShake()
    {

        StartCoroutine(DashShackCo());

    }

    public void Dash()
    {

        isDash = true;
        endPos = GameManager.instance.Player.position;
        
    }

    public void Slice()
    {

        bool flip = GetComponent<SpriteRenderer>().flipX;

        Vector2 boxSize;
        boxSize = flip ? new Vector2(-3, 4) : new Vector2(3, 4);

        if (Physics2D.BoxCast(transform.position, new Vector2(2,2), 0, Vector2.zero, 0, LayerMask.GetMask("Player")))
        {

            GameManager.instance.PlayerTakeDamage(20);

        }

    }

    public void DieEvnet()
    {

        PoolManager.instance.Add(gameObject);

    }

    IEnumerator ShackCo()
    {

        yield return null;

        isShake = true;
        cbmcp.m_AmplitudeGain += 2;
        cbmcp.m_FrequencyGain += 2;
        yield return new WaitForSeconds(0.1f);
        cbmcp.m_AmplitudeGain -= 2;
        cbmcp.m_FrequencyGain -= 2;
        isShake = false;

    }

    IEnumerator DashShackCo()
    {

        yield return null;

        isDashShake = true;
        cbmcp.m_AmplitudeGain += 0.5f;
        cbmcp.m_FrequencyGain += 0.5f;
        yield return new WaitForSeconds(0.1f);
        cbmcp.m_AmplitudeGain -= 0.5f;
        cbmcp.m_FrequencyGain -= 0.5f;
        isDashShake = false;

    }

    private void OnDisable()
    {

        if (isDashShake)
        {

            cbmcp.m_AmplitudeGain -= 0.5f;
            cbmcp.m_FrequencyGain -= 0.5f;

        }

        if (isShake)
        {

            cbmcp.m_AmplitudeGain -= 2;
            cbmcp.m_FrequencyGain -= 2;

        }

    }

}
