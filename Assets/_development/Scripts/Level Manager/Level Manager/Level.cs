using UnityEngine;

namespace ButchersGames
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private LevelConfig _levelConfig;

        public LevelConfig GetLevelConfig() => _levelConfig;
        public Vector3 GetPlayerSpawnPosition() => _playerSpawnPoint.position;

#if UNITY_EDITOR
        private void OnDrawGizmos()
    {
        if (_playerSpawnPoint != null)
        {
            Gizmos.color = Color.magenta;
            var m = Gizmos.matrix;
            Gizmos.matrix = _playerSpawnPoint.localToWorldMatrix;
            Gizmos.DrawSphere(Vector3.up * 0.5f + Vector3.forward, 0.5f);
            Gizmos.DrawCube(Vector3.up * 0.5f, Vector3.one);
            Gizmos.matrix = m;
        }
    }
#endif
    }
}