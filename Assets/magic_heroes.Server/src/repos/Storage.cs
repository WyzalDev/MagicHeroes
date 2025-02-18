using System.Collections.Generic;
using magic_heroes.Server.entities;

namespace magic_heroes.Server.repos
{
    public static class Storage
    {
        public static readonly List<Battle> battles = new List<Battle>();

        public static readonly List<CharacterCurrentInfo> characterCurrentInfos = new List<CharacterCurrentInfo>();

        public static readonly List<SpellCurrentCooldown> spellCurrentCooldowns = new List<SpellCurrentCooldown>();

        public static readonly List<Player> players = new List<Player>();

        public static readonly List<Character> characters = new List<Character>();

        public static readonly List<Spell> spells = new List<Spell>();

        public static readonly List<StatusEffect> statusEffects = new List<StatusEffect>();

        #region STORAGE_INITIALIZATION

        static Storage()
        {
            #region STATIC_INITIALIZATION

            #region CHARACTERS_INITIALIZATION

            var defaultCharacter = new Character()
            {
                Id = "1",
                MaxHealthPoints = 100
            };
            characters.Add(defaultCharacter);

            #endregion

            #region PLAYERS_INITIALIZATION

            var clientPlayer = new Player()
            {
                Id = "1",
                InGameId = "1",
                Name = "Client_User",
                Character = new List<Character>() { defaultCharacter }
            };
            var aiPlayer = new Player()
            {
                Id = "0",
                InGameId = "0",
                Name = "AI_User",
                Character = new List<Character>() { defaultCharacter }
            };
            players.Add(clientPlayer);

            #endregion

            #region STATUS_EFFECTS_INITIALIZATION

            var regenerationEffect = new StatusEffect()
            {
                Id = "1",
                Name = "Regeneration",
                Power = 2,
                Duration = 3,
                Dispellable = false
            };
            var barrierEffect = new StatusEffect()
            {
                Id = "2",
                Name = "Barrier",
                Power = 5,
                Duration = 2,
                Dispellable = false
            };
            var burningEffect = new StatusEffect()
            {
                Id = "3",
                Name = "Burning",
                Power = 1,
                Duration = 5,
                Dispellable = true
            };
            statusEffects.Add(regenerationEffect);
            statusEffects.Add(barrierEffect);
            statusEffects.Add(burningEffect);

            #endregion

            #region SPELLS_INITIALIZATION

            var attackSpell = new Spell()
            {
                Id = "1",
                Name = "Attack",
                Damage = 8,
                Cooldown = 0,
                Target = TargetType.Enemy,
                StatusEffects = new List<StatusEffect>()
            };
            var barrierSpell = new Spell()
            {
                Id = "2",
                Name = "Barrier",
                Damage = 0,
                Cooldown = 4,
                Target = TargetType.Self,
                StatusEffects = new List<StatusEffect>()
                {
                    barrierEffect
                }
            };
            var regenerationSpell = new Spell()
            {
                Id = "3",
                Name = "Regeneration",
                Damage = 0,
                Cooldown = 5,
                Target = TargetType.Self,
                StatusEffects = new List<StatusEffect>()
                {
                    regenerationEffect
                }
            };
            var fireballSpell = new Spell()
            {
                Id = "4",
                Name = "Fireball",
                Damage = 5,
                Cooldown = 6,
                Target = TargetType.Enemy,
                StatusEffects = new List<StatusEffect>()
                {
                    burningEffect
                }
            };
            var dispelSpell = new Spell()
            {
                Id = "5",
                Name = "Dispel",
                Damage = 0,
                Cooldown = 5,
                Target = TargetType.Self,
                StatusEffects = new List<StatusEffect>()
            };
            spells.Add(attackSpell);
            spells.Add(barrierSpell);
            spells.Add(regenerationSpell);
            spells.Add(fireballSpell);
            spells.Add(dispelSpell);

            #endregion

            #endregion

            #region DYNAMIC_INITIALIZATION

            ResetStorage();

            #endregion
        }

        #endregion
        
        static void ResetStorage()
        {
            #region CLEAR_DYNAMIC_STORAGE

            battles.Clear();
            characterCurrentInfos.Clear();
            spellCurrentCooldowns.Clear();

            #endregion

            #region DYNAMIC_INITIALIZATION

            var battle = new Battle()
            {
                Id = "1",
                InGameId = "1",
                FirstCharacterCurrentInfo = new CharacterCurrentInfo(),
                SecondCharacterCurrentInfo = new CharacterCurrentInfo(),
                Status = BattleStatus.WaitForStart
            };

            #endregion
        }
    }
}