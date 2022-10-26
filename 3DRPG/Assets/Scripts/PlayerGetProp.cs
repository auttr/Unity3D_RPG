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
        [SerializeField, Header("完成任務對話")]
        DataNPC dataNPC;
        private void Awake()
        {
            // steakPool = FindObjectOfType<SteakPool>();
            steakPool = GameObject.Find("StealPool").GetComponent<SteakPool>();
            steakText = GameObject.Find("Text_肉排數量").GetComponent<TextMeshProUGUI>();
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
            steakText.text = "狗排:" + (++steakCount) + "/" + steakMax;
            if (steakCount>=steakMax)
            {
                npcSystem.npcData = dataNPC;
            }
        }
    }

}

