using UnityEngine;
using UnityEngine.Events;

namespace Blythe
{
    /// <summary>
    /// 互動系統
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField,Header("對話資料")]
        private DialogueData dataDialogue;

        [SerializeField,Header("對話結束後的事件")]
        private UnityEvent afterDialogueFinish;

        [SerializeField,Header("啟動對話的道具")]
        private GameObject propActive;

        [SerializeField,Header("啟動後的對話資料")]
        private DialogueData dataDialogueActive;

        [SerializeField,Header("啟動後對話結束後的事件")]
        private UnityEvent afterDialogueFinishActive;

        private string nameTargt = "PlayerCapsule";

        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("對話系統_畫布").GetComponent<DialogueSystem>();

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.name.Contains(nameTargt))
            {
                print(other.name);

                if(propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, afterDialogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive, afterDialogueFinishActive);
                }
            }
        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    }
}
