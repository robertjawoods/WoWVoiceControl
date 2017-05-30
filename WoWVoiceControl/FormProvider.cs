using WoWVoiceControl.Classes;
using WoWVoiceControl.ClassForms.Warlock;
using WoWVoiceControl.ClassForms.Warlock.Specs;

namespace WoWVoiceControl
{
    /// <summary>
    /// Class holding singleton instances of forms
    /// </summary>
    public static class FormProvider
    {

        private static BaseAbilityForm baseAbilityInstance = null;

        public static BaseAbilityForm BaseAbilityForm(Classes.Classes wowClass)
        {
            if (baseAbilityInstance != null && baseAbilityInstance.IsDisposed)
                baseAbilityInstance = null;

            return baseAbilityInstance ?? (baseAbilityInstance = new WoWVoiceControl.BaseAbilityForm(ClassFactory.GetClass(wowClass)));
        }

        private static SpecAbilityForm specAbilityInstance = null;
        public static SpecAbilityForm SpecAbilityForm(WoWClass wowClass, string specName)
        {
            if (specAbilityInstance != null && specAbilityInstance.IsDisposed)
                specAbilityInstance = null;

            return specAbilityInstance ?? (specAbilityInstance = new WoWVoiceControl.SpecAbilityForm(wowClass, specName));
        }

        private static WarlockBaseForm warlockBaseForm = null;
        public static WarlockBaseForm WarlockBaseForm => warlockBaseForm ?? (warlockBaseForm = new WarlockBaseForm());

        private static AfflictionHotkeysForm afflictionHotkeysForm = null;
        public static AfflictionHotkeysForm AfflictionHotkeysForm(WarlockHotkeys keys)
        {
            if (afflictionHotkeysForm != null && afflictionHotkeysForm.IsDisposed)
                afflictionHotkeysForm = null;

            return afflictionHotkeysForm ?? (afflictionHotkeysForm = new AfflictionHotkeysForm(keys));
        }

        private static DemonologyHotkeysForm demonologyHotKeysForm = null;
        public static DemonologyHotkeysForm DemonologyHotkeysForm(WarlockHotkeys hotkeys)
        {
            if (demonologyHotKeysForm != null && demonologyHotKeysForm.IsDisposed)
                demonologyHotKeysForm = null;

            return demonologyHotKeysForm ?? (demonologyHotKeysForm = new DemonologyHotkeysForm(hotkeys));
        }

        private static DestructionHotkeysForm destructionHotKeysForm = null;
        public static DestructionHotkeysForm DestructionHotkeysForm(WarlockHotkeys keys)
        {
            if (destructionHotKeysForm != null && destructionHotKeysForm.IsDisposed)
                destructionHotKeysForm = null;

            return destructionHotKeysForm ?? (destructionHotKeysForm = new DestructionHotkeysForm(keys));
        }
    }
}
