using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SliceSkill : MonoBehaviour
{

    [SerializeField] private Vector2 size;
    [SerializeField] private int sliceCount;
    [SerializeField] private AudioSource sliceAudio;
    [SerializeField] private CinemachineVirtualCamera cvcam;

    private CinemachineBasicMultiChannelPerlin cbmcp;

    private bool isSlicing = false;

    private void Awake()
    {

        cbmcp = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    public void Slice()
    {

        if (isSlicing) return;
        StartCoroutine(SliceCo());

    }

    IEnumerator SliceCo()
    {

        isSlicing = true;
        List<Slice> slices = new List<Slice>();

        yield return null;

        for (int i = 0; i < sliceCount; i++)
        {

            Slice item = PoolManager.instance.Remove("Slice",
                                    new Vector2(Random.Range(transform.position.x + (size.x / 2), transform.position.x - (size.x / 2)),
                                                      Random.Range(transform.position.y + (size.y / 2), transform.position.y - (size.y / 2))),
                                     Quaternion.Euler(0, 0, Random.Range(0f, 360f)))
                                     .GetComponent<Slice>();

            item.Spawn();

            slices.Add(item);

            cbmcp.m_AmplitudeGain += 0.7f;
            cbmcp.m_FrequencyGain += 0.7f;
            yield return new WaitForSeconds(0.1f);
            cbmcp.m_AmplitudeGain -= 0.7f;
            cbmcp.m_FrequencyGain -= 0.7f;

        }

        yield return new WaitForSeconds(2f);
        sliceAudio.Play();

        yield return new WaitForSeconds(0.86f);

        cbmcp.m_AmplitudeGain += 20f;
        cbmcp.m_FrequencyGain += 20f;
        yield return new WaitForSeconds(0.1f);
        cbmcp.m_AmplitudeGain -= 20f;
        cbmcp.m_FrequencyGain -= 20f;

        foreach (var slice in slices)
        {

            slice.OnSlice();

            yield return null;

        }

        yield return new WaitForSeconds(1f);

        foreach (var slice in slices)
        {

            slice.DeSpawn();

            yield return null;

        }

        isSlicing = false;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position, size);

    }

#endif

}
