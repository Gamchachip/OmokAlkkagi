using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadukController : MonoBehaviour
{
    public GameObject selectedObject; // 마우스로 선택된 객체를 저장할 변수



    GameObject mousePointA;
    GameObject mousePointB;
    GameObject arrow;
    GameObject circle;

    private float currentDistance;
    private float maxDistance = 3f;
    private float safeSpace;
    public float shootPower;

    private Vector3 shootDir;


    void Awake()
    {
        mousePointA = GameObject.FindGameObjectWithTag("PointA");
        mousePointB = GameObject.FindGameObjectWithTag("PointB");
    }

    //콜라이더에 드래그 시 작동
    private void OnMouseDrag()
    {

        //포인트에서 바둑알 까지의 거리
        currentDistance = Vector3.Distance(mousePointA.transform.position, transform.position);

        

        //최대거리3까지로 지정
        if (currentDistance <= maxDistance)
        {
            safeSpace = currentDistance;
        }
        else
        {
            safeSpace = maxDistance;
        }
        shootPower = safeSpace * 10f;
        Debug.Log("실제 포인트길이" + currentDistance);
        Debug.Log("적용 길이" + safeSpace);

        //A로 향하는 벡터를 이용해서 반대방향인 B로 향하는 벡터
        Vector3 dirPointA = mousePointA.transform.position - transform.position;
        dirPointA = dirPointA/dirPointA.magnitude;
        mousePointB.transform.position = (transform.position + dirPointA * currentDistance * -1);
        mousePointB.transform.position = new Vector3(mousePointB.transform.position.x, 1f, mousePointB.transform.position.z);
    }


    private void OnMouseUp()
    {
        shootDir = transform.position - mousePointA.transform.position;
        shootDir = shootDir.normalized * shootPower;

        Debug.Log("dir 방향: " +shootDir);
        GetComponent<Rigidbody>().AddForce(shootDir, ForceMode.Impulse);
    }

}
