using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FireBossSkill : MonoBehaviour
{

    [SerializeField] private ParticleSystem particle;
    [SerializeField] private CinemachineVirtualCamera cvcam;

    private CinemachineBasicMultiChannelPerlin cbmcp;

    private void Awake()
    {

        cbmcp = cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

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

    IEnumerator ShackCo()
    {

        cbmcp.m_AmplitudeGain += 3;
        cbmcp.m_FrequencyGain += 3;

        yield return new WaitForSeconds(0.1f);

        cbmcp.m_AmplitudeGain -= 3;
        cbmcp.m_FrequencyGain -= 3;

    }

}
