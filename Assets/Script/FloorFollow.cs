using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFollow : MonoBehaviour
{
    public GameObject mainCamera;
    public Vector2 oldCameraPos;//�O�̃J�����̈ʒu
    public float floorDistance;//�����璆�S�܂ł̋���

    // Start is called before the first frame update
    void Start()
    {
        //���S���珰�܂ł̋���
        floorDistance = mainCamera.transform.position.y - this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.transform.position.y > oldCameraPos.y)
        {
            //�J�����̍ō��n�_�̍X�V
            oldCameraPos = mainCamera.transform.position;

            this.transform.position = new Vector3 (this.transform.position.x,oldCameraPos.y - floorDistance,this.transform.position.z);
        }
        
        //if (mainCamera.transform.position.y > this.transform.position.y)
        //{
        //    Vector3 cameraPos = new Vector3(this.transform.position.x, mainCamera.transform.position.y, this.transform.position.z);
        //    this.transform.position = cameraPos;
        //}
    }
}
