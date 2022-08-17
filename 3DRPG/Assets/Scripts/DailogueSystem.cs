using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

namespace aa
{
    /// <summary>
    /// NPC��ܤ��e�A�n���A�W�r��s
    /// </summary>
    /// 
    public delegate void DelegateFinishDailogue();
    [RequireComponent(typeof(AudioSource))]
    public class DailogueSystem : MonoBehaviour
    {
        #region ���
        // [SerializeField, Header("NpcDATA")]
        DataNPC npcData;
        [SerializeField, Header("�e��")]
        private CanvasGroup DailogueCG;
        [SerializeField, Header("��ܪ̦W�r")]
        private TextMeshProUGUI nameTxt;
        [SerializeField, Header("��ܤ��e")]
        private TextMeshProUGUI contentTxt;
        [SerializeField, Header("�T����")]
        GameObject goTriangle;
        [SerializeField, Header("Typetime")]
        float typetime = 0.1f;
        [SerializeField, Header("Fadetime")]
        float fadetime = 0.05f;
        #endregion




        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();


            //StartCoroutine(StartDailogue());
        }
        public bool isDailogue;
        public IEnumerator StartDailogue(DataNPC _npcdata,DelegateFinishDailogue callback)
        {
            isDailogue = true;
            npcData = _npcdata;
            nameTxt.text = npcData.npcname;
            contentTxt.text = "";
            yield return StartCoroutine(Fade());
            for (int i = 0; i < npcData.npcDailogue.Length; i++)
            {

                yield return StartCoroutine(TypeEffort(i));
                while (!Input.GetKeyDown(KeyCode.E))
                {
                    yield return null;
                }
            }
            StartCoroutine(Fade(false));
            isDailogue = false;
            callback();

        }
        /// <summary>
        /// �H�J+�H�X
        /// </summary>
        /// <param name="Fadein"></param>
        /// <returns></returns>
        private IEnumerator Fade(bool Fadein = true)
        {
            float increase = Fadein ? 0.1f : -0.1f;
            for (int i = 0; i < 10; i++)
            {
                DailogueCG.alpha += increase;
                yield return new WaitForSeconds(fadetime);
            }
            aud.PlayOneShot(npcData.npcDailogue[0].sound);
            goTriangle.SetActive(true);

        }
        private IEnumerator TypeEffort(int idx)
        {
            contentTxt.text = "";
            string content = npcData.npcDailogue[idx].npccontent;
            for (int i = 0; i < content.Length; i++)
            {
                contentTxt.text += content[i];
                yield return new WaitForSeconds(typetime);

            }


        }
        private void Reset()
        {
            
        }
        #region ��P�{�Ǳо�
        private IEnumerator Test()
        {
            print("1");
            yield return new WaitForSeconds(2);
            print("2");
        }
        #endregion

    }
}

