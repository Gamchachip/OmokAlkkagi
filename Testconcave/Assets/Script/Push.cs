using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Push : MonoBehaviour
{
    public GameObject selectedObject; // 마우스로 선택된 객체를 저장할 변수
    private float offset = 0.7f;
    Ray ray;

    private void Awake()
    {
        selectedObject = null;
    }
    private void Update()
    {
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        
        
        //좌클릭 누를 시 바둑알 선택
        if (Input.GetMouseButtonDown(0))
        {

            selectedObject = SelectedBaduk();
        }


        //좌클릭 때질 때 바둑알 발사
        if (Input.GetMouseButtonUp(0))
        {
            if (!selectedObject.CompareTag("Baduk"))
                return;

            print(selectedObject.transform.position);
            print(selectedObject.transform.name);
            selectedObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }

    }


    //ray 마우스 방향으로 발사 후 맞은 오브젝트 반환하는 함수
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
