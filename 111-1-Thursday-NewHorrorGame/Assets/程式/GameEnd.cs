using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blythe
{
    /// <summary>
    /// 跳轉結束畫面
    /// </summary>
    public class GameEnd : MonoBehaviour
    {
        
        [SerializeField]
        private float pitch;
        
        private AudioSource backgroundMusic;

        private void Start()
        {
            backgroundMusic = GameObject.Find("背景音樂").GetComponent<AudioSource>();
        }

        /// <summary>
        /// 結束遊戲
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {

            if(other.gameObject.tag=="Player")
            {
                backgroundMusic.Stop();

                backgroundMusic.pitch = pitch;

                backgroundMusic.Play();
                
                SceneManager.LoadScene(1);
            }
        }
    }
}
