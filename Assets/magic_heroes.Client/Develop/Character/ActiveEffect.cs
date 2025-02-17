using TMPro;
using UnityEngine;

namespace magic_heroes.Client.Character
{
    public class ActiveEffect : MonoBehaviour
    {
        public EffectName activeEffectName;

        private TMP_Text _remainingTimeTMP;
        
        private void Awake()
        {
            _remainingTimeTMP = GetComponentInChildren<TMP_Text>();
        }

        public void SetRemainingTimeText(int remainingTime)
        {
            if (remainingTime <= 0)
            {
                _remainingTimeTMP.gameObject.SetActive(false);
                return;
            } else if (!_remainingTimeTMP.gameObject.activeSelf)
            {
                _remainingTimeTMP.gameObject.SetActive(true);
            }
            _remainingTimeTMP.SetText(remainingTime.ToString());
        }
    }
    
    

    public enum EffectName
    {
        Burning,
        Regeneration,
        Barier
    }
}