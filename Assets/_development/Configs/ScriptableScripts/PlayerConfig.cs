using UnityEngine;

namespace Assets._development.Configs.ScriptableScripts
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Speed movement")]
        public float PlayerForwardSpeed;
        public float PlayerSlideSpeed;

        [Header("LimitMovement")]
        public float LimitWidth; //This value can be setted from chunk width or you can create movement area, so I decide set value manually because it simpler and faster)

        [Header("MoneyToNextStatus")]
        public int StartMoney;

        [Header("MoneyToNextStatus")]
        public int MoneyForCasualMoneyLimit;
        public int MoneyToBecomeCasual;
        public int MoneyToBecomeRich;
    }
}
