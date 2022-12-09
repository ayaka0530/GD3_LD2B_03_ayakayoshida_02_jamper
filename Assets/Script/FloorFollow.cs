using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFollow : MonoBehaviour
{
    public GameObject mainCamera;
    public Vector2 oldCameraPos;//前のカメラの位置
    public float floorDistance;//床から中心までの距離

    // Start is called before the first frame update
    void Start()
    {
        //中心から床までの距離
        floorDistance = mainCamera.transform.position.y - this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.transform.position.y > oldCameraPos.y)
        {
            //カメラの最高地点の更新
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
