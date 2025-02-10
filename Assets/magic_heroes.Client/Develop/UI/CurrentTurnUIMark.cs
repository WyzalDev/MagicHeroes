using TMPro;
using UnityEngine;

namespace magic_heroes.Client.UI
{
    public class CurrentTurnUIMark : MonoBehaviour
    {
        private TMP_Text _currentTurnText;
        private void Awake()
        {
            _currentTurnText = GetComponentInChildren<TMP_Text>();
        }

        public void SetText(string text)
        {
            _currentTurnText.text = text;
        }
    }
}