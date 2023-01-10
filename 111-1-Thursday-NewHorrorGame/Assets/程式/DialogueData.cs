using UnityEngine;

namespace Blythe
{
    /// <summary>
    /// 對話資料
    /// </summary>
    [CreateAssetMenu(menuName = "Blythe/DialodueData", fileName = "New Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        #region 資料區域

        [Header("對話者名稱")]
        public string dialogueName;

        [Header("對話內容"),TextArea(2,10)]
        public string[] dialogueContent;

        #endregion
    }
}
