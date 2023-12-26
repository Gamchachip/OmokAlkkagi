using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Push : MonoBehaviour
{
    public GameObject selectedObject; // ���콺�� ���õ� ��ü�� ������ ����
    private float offset = 0.7f;
    Ray ray;

    private void Awake()
    {
        selectedObject = null;
    }
    private void Update()
    {
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        
        
        //��Ŭ�� ���� �� �ٵϾ� ����
        if (Input.GetMouseButtonDown(0))
        {

            selectedObject = SelectedBaduk();
        }


        //��Ŭ�� ���� �� �ٵϾ� �߻�
        if (Input.GetMouseButtonUp(0))
        {
            if (!selectedObject.CompareTag("Baduk"))
                return;

            print(selectedObject.transform.position);
            print(selectedObject.transform.name);
            selectedObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }

    }


    //ray ���콺 �������� �߻� �� ���� ������Ʈ ��ȯ�ϴ� �Լ�
    GameObject SelectedBaduk()
    {
         
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Baduk")))
        {
            selectedObject = hit.transform.gameObject;
        }
        
        return selectedObject;
    }
}
