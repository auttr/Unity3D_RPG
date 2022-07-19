using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace auttr
{
    /// <summary>
    /// 第三人稱鏡頭控制
    /// 移動、動畫更新
    /// </summary>
    public class Thirdcamera : MonoBehaviour
    {
        #region 資料
        Animator ani;
        CharacterController controller;
        [SerializeField, Header("移動速度"), Range(0, 50)]
        float speed = 5f;
        [SerializeField, Header("旋轉速度"), Range(0, 50)]
        float rotate = 19f;
        [SerializeField, Header("跳躍高度"), Range(0, 50)]
        float jump = 3f;
        Vector3 direction;
        Transform tracamera;
        string paraRun = "跑路走步";
        #endregion

        #region 事件
        private void Awake()
        {
            ani = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
            tracamera = GameObject.Find("Main Camera").transform;
        }
        private void Update()
        {
            Move();
            Jump();
        }
        #endregion


        #region 方法
        void Move()
        {
            #region 旋轉
            //鏡頭
            transform.rotation = Quaternion.Lerp(transform.rotation, tracamera.rotation, rotate * Time.deltaTime);
            //角色只有y軸rotate
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            #endregion


            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            direction.z = v;
            direction.x = h;
            direction = transform.TransformDirection(direction);


            controller.Move(direction * speed * Time.deltaTime);
            //移動動畫更新

            float vAxis = Input.GetAxis("Vertical");
            float hAxis = Input.GetAxis("Horizontal");

            if (Mathf.Abs(vAxis) >0.1)
            {
                ani.SetFloat(paraRun, Mathf.Abs(vAxis));
            }
            else if ( Mathf.Abs(hAxis) > 0.1f)
            {
                ani.SetFloat(paraRun, Mathf.Abs(hAxis));
            }
            else
            {
                ani.SetFloat(paraRun,0);
            }
            

        }
        void Jump()
        {
            if(controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jump;
              
            }
            direction.y += Physics.gravity.y * Time.deltaTime;
        }
        #endregion




    }

}
