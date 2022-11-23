using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class FireBossSkill : MonoBehaviour
{

    [SerializeField] private ParticleSystem particle;
    [SerializeField] private CinemachineVirtualCamera cvcam;
    [SerializeField] private UnityEvent roarEvent;
    [SerializeField] private UnityEvent roarEndEvent;

    private bool isShake;
    private bool isRoarShake;
    private CinemachineBasicMultiChannelPerlin cbmcp;

    private void Awake()
    {
        
        cbmcp = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    public void BossSkill(Transform skillPos)
    {

        for(int i = 0; i < 180; i += 10)
        {

            PoolManager.instance.Remove("FireSlice", skillPos.position, Quaternion.Euler(new Vector3(0,0,i + 20)));
            particle.Play();
            StartCoroutine(ShackCo());

        }

    
    }

    public void BossRoar()
    {

        StartCoroutine(RuorFireBallCo());

    }

    public void DieEvnet()
    {

        PoolManager.instance.Add(gameObject);

    }

    IEnumerator ShackCo()
    {

        isShake = true;
        cbmcp.m_AmplitudeGain += 3;
        cbmcp.m_FrequencyGain += 3;

        yield return new WaitForSeconds(0.1f);

        cbmcp.m_AmplitudeGain -= 3;
        cbmcp.m_FrequencyGain -= 3;
        isShake = false;

    }

    IEnumerator RuorFireBallCo()
    {

        yield return null;

        isRoarShake = true;

        cbmcp.m_AmplitudeGain += 0.3f;
        cbmcp.m_FrequencyGain += 0.3f;

        roarEvent?.Invoke();

        for(int j = 0; j < 5; j++)
        {

            for (int i = 0; i < 180; i += 10)
            {

                PoolManager.instance.Remove("FireSlice", transform.position, Quaternion.Euler(new Vector3(0, 0, i + (j * 10))));
                yield return null;

            }

            yield return new WaitForSeconds(0.1f);

        }

        yield return null;

        roarEndEvent?.Invoke();

        cbmcp.m_AmplitudeGain -= 0.3f;
        cbmcp.m_FrequencyGain -= 0.3f;

        gameObject.GetComponent<Animator>().SetTrigger("RoarEnd");

        isRoarShake = false;


    }

    private void OnDisable()
    {

        if (isShake)
        {

            cbmcp.m_AmplitudeGain -= 3;
            cbmcp.m_FrequencyGain -= 3;

        }

        if (isRoarShake)
        {

            cbmcp.m_AmplitudeGain -= 0.3f;
            cbmcp.m_AmplitudeGain -= 0.3f;

        }

    }

}
