using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace auttr
{
    /// <summary>
    /// �ĤT�H�����Y����
    /// ���ʡB�ʵe��s
    /// </summary>
    public class Thirdcamera : MonoBehaviour
    {
        #region ���
        Animator ani;
        CharacterController controller;
        [SerializeField, Header("���ʳt��"), Range(0, 50)]
        float speed = 5f;
        [SerializeField, Header("����t��"), Range(0, 50)]
        float rotate = 19f;
        [SerializeField, Header("���D����"), Range(0, 50)]
        float jump = 3f;
        Vector3 direction;
        Transform tracamera;
        string paraRun = "�]�����B";
        #endregion

        #region �ƥ�
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


        #region ��k
        void Move()
        {
            #region ����
            //���Y
            transform.rotation = Quaternion.Lerp(transform.rotation, tracamera.rotation, rotate * Time.deltaTime);
            //����u��y�brotate
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            #endregion


            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            direction.z = v;
            direction.x = h;
            direction = transform.TransformDirection(direction);


            controller.Move(direction * speed * Time.deltaTime);
            //���ʰʵe��s

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
