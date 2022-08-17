
using UnityEngine;

namespace aa
{
    /// <summary>
    ///�s�� NPC�W�١A��ܤ��e�A�n�� scriptableOBJ
    /// </summary>
    [CreateAssetMenu (menuName = "Auttr/Data NPC" ,fileName ="Data NPC")]
    
    public class DataNPC : ScriptableObject
    {
        [Header("NPC name")]
        public string npcname;

        [Header("�Ҧ����"),NonReorderable]
        public NPCdailogue [] npcDailogue;



    }
    [System.Serializable]
    public class NPCdailogue
    {
        [Header("NPC���")]
        public string npccontent;
        [Header("NPC�n��")]
        public AudioClip sound;
    }


}
