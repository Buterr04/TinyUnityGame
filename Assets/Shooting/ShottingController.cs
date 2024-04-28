using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShottingController : MonoBehaviour
{
    public static ShottingController Instance;
    //子弹
    public GameObject zidan;
    //玩家
    public Transform player;

    public Text scoreText;

    public int score;

    public float speed = 15f;

   // public float lookSpeed = 2f;

    public float zoomSpeed = 20f;

    //private float rotationX = 0f;  // 初始化水平旋转角度为0
    //private float rotationY = 0f;  // 初始化垂直旋转角度为0
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //0:鼠标左键 1：鼠标右键 2：鼠标中键
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Vector3 vector = new Vector3(0,0,1);
        //    ForceMode forceMode = ForceMode.Force;
        //    rigidbody.AddForce(vector * 1000, forceMode);
        //}
        if (Input.GetKey(KeyCode.A))
        {
            //按下键盘A键向左移动
            player.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //按下键盘D键向右移动
            player.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            //按下键盘W键向前移动
            player.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //按下键盘D键向后移动
            player.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.Space))  // 如果玩家按下了空格键
        {
            // 将移动方向的y轴分量设为跳跃速度
        }


        // 视角控制
       // rotationX += Input.GetAxis("Mouse X") * lookSpeed;  // 根据鼠标水平移动改变水平角度
      //  rotationY += Input.GetAxis("Mouse Y") * lookSpeed;  // 根据鼠标垂直移动改变垂直角度
      //  rotationY = Mathf.Clamp(rotationY, -90f, 90f);  // 限制垂直角度在 -90 度到 90 度之间

      //  transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0f);  // 根据水平和垂直角度旋转物体的局部坐标系

        // 视角放大缩小
        float zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;  // 获取鼠标滚轮的输入并乘以缩放速度
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - zoom, 10f, 100f);  // 根据输入改变相机的视野大小，并限制在10到100的范围内

        if (Input.GetMouseButtonDown(1))
        {
            //实例化子弹
            GameObject obj = Instantiate(zidan);
            //设置子弹的初始位置
            obj.transform.position = player.transform.position;
            Rigidbody rig = null;
            //获取子弹的刚体组件
            if (obj.GetComponent<Rigidbody>() != null)
            {
                rig = obj.GetComponent<Rigidbody>();
            }
            else
            {
                rig = obj.AddComponent<Rigidbody>();
            }
          
            //给子弹一个向前的力
            Vector3 vector = new Vector3(0, 0, 1);
            ForceMode forceMode = ForceMode.Force;
            rig.AddForce(vector * 1000, forceMode);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(gameObject);
    //}

    public void SettingScore()
    {
        score++;//0   1  2
        scoreText.text = score.ToString();


    }
}
