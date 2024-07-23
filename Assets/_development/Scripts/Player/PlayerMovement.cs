using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed movement")]
    [SerializeField] private float _playerForwardSpeed;
    [SerializeField] private float _playerSlideSpeed;

    [Header("LimitMovement")]
    [SerializeField] private float _limitWidth; //This value can be setted from chunk width or you can create movement area, so I decide set value manually because it simpler and faster)

    private Vector3 _clickScreenPosition;
    private Vector3 _clickPlayerPosition;

    private float _invertedScreenWidth = 1f / Screen.width;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        MoveForward();
        MoveSlide();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * _playerForwardSpeed;
    }
    private void MoveSlide()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickScreenPosition = Input.mousePosition;
            _clickPlayerPosition = transform.position;
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

        Vector3 newPlayerPosition = transform.position;
        var clampedPositionX = Mathf.Clamp(_clickPlayerPosition.x + xOffset, -halfOfLimitMovement, halfOfLimitMovement);
        newPlayerPosition.x = clampedPositionX;

        transform.position = newPlayerPosition;
    }
}
