using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadukController : MonoBehaviour
{
    public GameObject selectedObject; // ���콺�� ���õ� ��ü�� ������ ����



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

    //�ݶ��̴��� �巡�� �� �۵�
    private void OnMouseDrag()
    {

        //����Ʈ���� �ٵϾ� ������ �Ÿ�
        currentDistance = Vector3.Distance(mousePointA.transform.position, transform.position);

        

        //�ִ�Ÿ�3������ ����
        if (currentDistance <= maxDistance)
        {
            safeSpace = currentDistance;
        }
        else
        {
            safeSpace = maxDistance;
        }
        shootPower = safeSpace * 10f;
        Debug.Log("���� ����Ʈ����" + currentDistance);
        Debug.Log("���� ����" + safeSpace);

        //A�� ���ϴ� ���͸� �̿��ؼ� �ݴ������ B�� ���ϴ� ����
        Vector3 dirPointA = mousePointA.transform.position - transform.position;
        dirPointA = dirPointA/dirPointA.magnitude;
        mousePointB.transform.position = (transform.position + dirPointA * currentDistance * -1);
        mousePointB.transform.position = new Vector3(mousePointB.transform.position.x, 1f, mousePointB.transform.position.z);
    }


    private void OnMouseUp()
    {
        shootDir = transform.position - mousePointA.transform.position;
        shootDir = shootDir.normalized * shootPower;

        Debug.Log("dir ����: " +shootDir);
        GetComponent<Rigidbody>().AddForce(shootDir, ForceMode.Impulse);
    }

}
