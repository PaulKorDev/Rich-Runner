using UnityEngine;

namespace Assets._development.Configs.ScriptableScripts
{
    [CreateAssetMenu(fileName = "PickupsConfig", menuName = "ScriptableObjects/PickupsConfig")]
    public class PickupsConfig : ScriptableObject
    {
        [Header("Bottles")]
        public int BottlesValue;

        [Header("Bills")]
        public int ValueMin;
        public int ValueMax;
    }
}
