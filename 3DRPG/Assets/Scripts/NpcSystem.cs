using auttr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace aa
{
    public class NpcSystem : MonoBehaviour
    {
        // Start is called before the first frame update
        Animator aniTip;
        [SerializeField, Header("NpcData")]
       public DataNPC npcData;
        [SerializeField, Header("NpcCamera")]
       GameObject gocamera;
        bool isintrigger;
        string aniPara = "Ĳ�o�H�J�H�X";
        Thirdcamera thirdcamera;
        DailogueSystem dailogueSystem;
        Animator ani;
        string anip = "��ܶ}��";
        
        private void Update()
        {
            InputIsTrigger();
        }
        private void Awake()
        {
            aniTip = GameObject.Find("�H�J�H�X").GetComponent<Animator>();
            thirdcamera = FindObjectOfType<Thirdcamera>();
            dailogueSystem = FindObjectOfType<DailogueSystem>();
            ani = GetComponent<Animator>();
        }
        private void OnTriggerEnter(Collider other)
        {
            CheckPlayerAndAnimator(other.name, true);
        }
        private void OnTriggerExit(Collider other)
        {
            CheckPlayerAndAnimator(other.name, false);
        }
        void CheckPlayerAndAnimator(string hitname, bool _isintrigger)
        {
            if (hitname == "�p��")
            {

                isintrigger = _isintrigger;
                aniTip.SetTrigger(aniPara);
            }
        }
        void InputIsTrigger()
        {
            if(dailogueSystem.isDailogue) return;

            
            
            if(isintrigger && Input.GetKeyDown(KeyCode.E))
            {
                gocamera.SetActive(true);
                aniTip.SetTrigger(aniPara);
                thirdcamera.enabled = false;
                try
                {
                    ani.SetBool(anip, true);
                }
                catch (System.Exception)
                {
                    print("<color=red>��ҤبS�ʵe</color>");
                    throw;
                }
               
                StartCoroutine(dailogueSystem.StartDailogue(npcData, ResetCameraandthird));
       


            }
        }
        void ResetCameraandthird()
        {
            gocamera.SetActive(false);
            thirdcamera.enabled = true;
            aniTip.SetTrigger(aniPara);
            try
            {
                ani.SetBool(anip, false);
            }
            catch (System.Exception)
            {
                print("<color=red>��ҤبS�ʵe</color>");
                throw;
            }
        }
    }

}

