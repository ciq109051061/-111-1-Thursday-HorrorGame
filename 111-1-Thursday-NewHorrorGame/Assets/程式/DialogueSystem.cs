using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Blythe
{
    /// <summary>
    /// 對話系統
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region 資料區域

        [SerializeField,Header("對話間隔"),Range(0,0.5f)]
        private float dialogueIntervalTime = 0.1f;

        [SerializeField,Header("開頭對話")]
        private DialogueData dialogueOpening;

        [SerializeField,Header("對話按鍵")]
        private KeyCode dialogueKey = KeyCode.Mouse0;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);

        private CanvasGroup groupDialogue;

        private TextMeshProUGUI textName;

        private TextMeshProUGUI textContent;

        private GameObject goTrinagle;

        private PlayerInput playerInput;

        private UnityEvent onDialogueFinish;

        #endregion

        private void Awake()
        {
            groupDialogue = GameObject.Find("對話系統_畫布").GetComponent<CanvasGroup>();

            textName = GameObject.Find("對話者名稱").GetComponent<TextMeshProUGUI>();

            textContent = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();

            goTrinagle = GameObject.Find("對話完成圖示");

            goTrinagle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(dialogueOpening);
        }

        /// <summary>
        /// 開頭對話
        /// </summary>
        /// <param name="data">要執行的對話資料</param>
        /// <param name="_onDialogueFinish">對話結束後的事件</param>
        public void StartDialogue(DialogueData data,UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;

            StartCoroutine(FadeGroup());

            StartCoroutine(TypeEffect(data));

            onDialogueFinish = _onDialogueFinish;
        }

        #region 協同程序

        /// <summary>
        /// 淡入淡出群組
        /// </summary>
        /// <param name="fadeIn">淡入淡出判定</param>
        /// <returns></returns>
        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            
            float increase = fadeIn ? +0.1f : -0.1f;

            for(int i = 0; i<10; i++)
            {
                groupDialogue.alpha += increase;

                yield return new WaitForSeconds(0.04F);
            }
        }

        /// <summary>
        /// 打字效果
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IEnumerator TypeEffect(DialogueData data)
        {
            textName.text = data.dialogueName;

            for(int j =0; j<data.dialogueContent.Length; j++)
            {
                textContent.text = "";

                string dialogue = data.dialogueContent[j];

                for(int i = 0; i< dialogue.Length; i++)
                {
                    textContent.text += dialogue[i];

                    yield return dialogueInterval;
                }

                goTrinagle.SetActive(true);

                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }

                print("玩家按下按鍵");
                playerInput.enabled = true;

                onDialogueFinish?.Invoke();
            }

            StartCoroutine(FadeGroup(false));
            
        }

        #endregion


    }
}
