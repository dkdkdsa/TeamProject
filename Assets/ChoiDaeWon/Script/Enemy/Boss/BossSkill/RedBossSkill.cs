using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Editor;

public class RedBossSkill : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cvcam;

    private CinemachineBasicMultiChannelPerlin cbmcp;
    private bool isDash;
    private Vector3 endPos;

    private void Awake()
    {
        
        cbmcp = cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

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

    IEnumerator ShackCo()
    {

        yield return null;

        cbmcp.m_AmplitudeGain += 2;
        cbmcp.m_FrequencyGain += 2;
        yield return new WaitForSeconds(0.1f);
        cbmcp.m_AmplitudeGain -= 2;
        cbmcp.m_FrequencyGain -= 2;

    }

    IEnumerator DashShackCo()
    {

        yield return null;

        cbmcp.m_AmplitudeGain += 0.5f;
        cbmcp.m_FrequencyGain += 0.5f;
        yield return new WaitForSeconds(0.1f);
        cbmcp.m_AmplitudeGain -= 0.5f;
        cbmcp.m_FrequencyGain -= 0.5f;

    }

}
