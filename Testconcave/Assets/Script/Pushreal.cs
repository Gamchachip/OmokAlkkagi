using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushreal : MonoBehaviour
{
    private float offset = 1f;

    private Vector3 tempPos;
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, offset, transform.position.z);

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, offset, hit.point.z);
            transform.position = targetPosition;
        }
    }

}
