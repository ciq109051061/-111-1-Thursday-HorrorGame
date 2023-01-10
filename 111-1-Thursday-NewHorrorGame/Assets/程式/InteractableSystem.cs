using UnityEngine;
using UnityEngine.Events;

namespace Blythe
{
    /// <summary>
    /// ���ʨt��
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField,Header("��ܸ��")]
        private DialogueData dataDialogue;

        [SerializeField,Header("��ܵ����᪺�ƥ�")]
        private UnityEvent afterDialogueFinish;

        [SerializeField,Header("�Ұʹ�ܪ��D��")]
        private GameObject propActive;

        [SerializeField,Header("�Ұʫ᪺��ܸ��")]
        private DialogueData dataDialogueActive;

        [SerializeField,Header("�Ұʫ��ܵ����᪺�ƥ�")]
        private UnityEvent afterDialogueFinishActive;

        private string nameTargt = "PlayerCapsule";

        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("��ܨt��_�e��").GetComponent<DialogueSystem>();

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
