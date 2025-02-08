using UnityEngine.UI;

namespace magic_heroes.Client.Develop.View
{
    public class CharacterInfo
    {
        public int MaxHealth;
        
        private int _currentHealth;

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                if (hpBar is not null)
                    hpBar.fillAmount = _currentHealth / MaxHealth;
            }
        }
        public Image hpBar { get; set; }
    }
}