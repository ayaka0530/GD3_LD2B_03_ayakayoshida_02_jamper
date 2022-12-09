using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private float speed = 0.05f;
    private int jumpCount = 0;
    private float jumpForce = 25f;


    public bool isScaffold = false;//足場のフラグ
    public GameObject floor;
    public GameObject oldFloor;//前の床のゲームオブジェクト
    public Vector2 oldFloorPos;//前の床の位置
    public FloorFollow floorFollw;
    public float floorDistance;
    public float stepOnCount;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        floorFollw = GameObject.Find("Floor").GetComponent<FloorFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if (Input.GetKey("left") || (Input.GetKey(KeyCode.A)))
        {
            position.x -= speed;

        }
        else if (Input.GetKey("right") || (Input.GetKey(KeyCode.D)))
        {
            position.x += speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 1)
        {
            //this.rbody2D.AddForce(transfxorm.up * jumpForce);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpForce, 0);
            jumpCount++;

            //床についているとき
            if (isScaffold == false)
            {
                float jumpPower = stepOnCount * jumpForce;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower + 25, 0);

                stepOnCount = 0;

                //float floorGap;
                //floorGap = floor.transform.position.y - Camera.main.transform.position.y;
                //Debug.Log("floorGapの値" + floorGap);
                //Debug.Log("jumpPowerの値" + jumpPower);
            }
        }
        //Debug.Log("差" + (Camera.main.transform.position.y - floor.transform.position.y));
        Debug.Log("floorの位置" + floor.transform.position.y);
        Debug.Log("cameraの位置" + Camera.main.transform.position.y);
        var pos = transform.position;

        //エリア指定して移動する
        //position.x = Mathf.Clamp(position.x, -7.33f, 6.5f);
        //position.y = Mathf.Clamp(position.y, -3.63f, 3.63f);

        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            jumpCount = 0;
            isScaffold = false;
        }

        //足場に触れた時に床が移動する
        else if (other.gameObject.tag == "Scaffold" && oldFloor != other.gameObject && other.transform.position.y > oldFloorPos.y && other.transform.position.y < this.transform.position.y)
        {
            float upHalf;
            jumpCount = 0;

            //床の移動量
            upHalf = (other.transform.position.y - oldFloorPos.y) / 2;

            //床の移動
            Vector2 pos = new Vector2(floor.transform.position.x, floor.transform.position.y + upHalf);
            floor.transform.position = pos;

            //床の更新
            oldFloorPos = other.transform.position;

            //フラグを戻す
            isScaffold = true;

        }

        if (other.gameObject.tag == "Scaffold")
        {
            jumpCount = 0;
            isScaffold = true;
            stepOnCount++;
        }
    }
}
