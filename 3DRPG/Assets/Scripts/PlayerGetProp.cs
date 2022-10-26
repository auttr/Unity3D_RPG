using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace aa
{
    public class PlayerGetProp : MonoBehaviour
    {
        SteakPool steakPool;
        string propSteak = "Steak";
        int steakCount=0;
        int steakMax=10;
        TextMeshProUGUI steakText;
        NpcSystem npcSystem;
        [SerializeField, Header("�������ȹ��")]
        DataNPC dataNPC;
        private void Awake()
        {
            // steakPool = FindObjectOfType<SteakPool>();
            steakPool = GameObject.Find("StealPool").GetComponent<SteakPool>();
            steakText = GameObject.Find("Text_�ױƼƶq").GetComponent<TextMeshProUGUI>();
            npcSystem = GameObject.Find("NPC").GetComponent<NpcSystem>();
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            print(hit.gameObject.name);

            if (hit.gameObject.name.Contains(propSteak))
            {

                steakPool.ReleaseSteakPool(hit.transform.root.gameObject);
                UpdateUI();
            }
        }
        void UpdateUI()
        {
            steakText.text = "����:" + (++steakCount) + "/" + steakMax;
            if (steakCount>=steakMax)
            {
                npcSystem.npcData = dataNPC;
            }
        }
    }

}

