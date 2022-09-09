using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField ]private Transform traget;

    private void Update()
    {

        Move();

    }

    private void Move()
    {

        Vector3 pos = new Vector3(traget.transform.position.x, traget.transform.position.y, -10);

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f);

    }
}
