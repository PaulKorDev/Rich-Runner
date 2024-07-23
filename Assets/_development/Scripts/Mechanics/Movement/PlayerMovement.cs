using UnityEngine;

namespace Assets._development.Scripts.Movement
{
    public class PlayerMovement
    {
        private float _playerForwardSpeed;
        private float _playerSlideSpeed;
        private float _limitWidth; 
        private float _invertedScreenWidth = 1f / Screen.width;
        private Vector3 _clickScreenPosition;
        private Vector3 _clickPlayerPosition;
        private Player _player;

        public PlayerMovement(Player player)
        {
            _player = player;
        }

        public void Move()
        {
            MoveForward();
            MoveSlide();
        }

        private void MoveForward()
        {
            _player.transform.position += Vector3.forward * Time.deltaTime * _playerForwardSpeed;
        }
        private void MoveSlide()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _clickScreenPosition = Input.mousePosition;
                _clickPlayerPosition = _player.transform.position;
            }
            else if (Input.GetMouseButton(0))
            {
                GetOffsetX(out float xOffset);
                MovePlayerToNewSidePosition(xOffset);
            }
        }
        private void GetOffsetX(out float xOffset)
        {
            xOffset = Input.mousePosition.x - _clickScreenPosition.x;
            xOffset *= _playerSlideSpeed * _invertedScreenWidth;
        }
        private void MovePlayerToNewSidePosition(float xOffset)
        {
            var halfOfLimitMovement = _limitWidth * 0.5f;

            Vector3 newPlayerPosition = _player.transform.position;
            var clampedPositionX = Mathf.Clamp(_clickPlayerPosition.x + xOffset, -halfOfLimitMovement, halfOfLimitMovement);
            newPlayerPosition.x = clampedPositionX;

            _player.transform.position = newPlayerPosition;
        }
    }
}