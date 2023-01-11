using UnityEngine;

namespace Blythe
{

    public class DontDelet : MonoBehaviour
    {
        /// <summary>
        /// 跳轉關卡不刪除
        /// </summary>
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
