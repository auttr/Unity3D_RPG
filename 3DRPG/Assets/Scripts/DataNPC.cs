
using UnityEngine;

namespace aa
{
    /// <summary>
    ///存放 NPC名稱，對話內容，聲音 scriptableOBJ
    /// </summary>
    [CreateAssetMenu (menuName = "Auttr/Data NPC" ,fileName ="Data NPC")]
    
    public class DataNPC : ScriptableObject
    {
        [Header("NPC name")]
        public string npcname;

        [Header("所有對話"),NonReorderable]
        public NPCdailogue [] npcDailogue;



    }
    [System.Serializable]
    public class NPCdailogue
    {
        [Header("NPC對話")]
        public string npccontent;
        [Header("NPC聲音")]
        public AudioClip sound;
    }


}
