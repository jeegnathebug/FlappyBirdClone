using UnityEngine;

namespace UI
{
    public class ButtonAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip hoverSound;
        [SerializeField] private AudioClip clickSound;

        public void OnButtonHover()
        {
            AudioSource.PlayClipAtPoint(hoverSound, Vector3.zero);
        }

        public void OnButtonClicked()
        {
            AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
        }
    }
}
