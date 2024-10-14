using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity; // マウスの感度
    [SerializeField] private float rotationSpeed; // 回転のスピード
    [SerializeField] private Transform myTransform;
    private Quaternion initializeRotation;
    private float rotationX = 0.0f;
    private float initializeRotationX = 0.0f;
    private float initializeRotationY = 0.0f;
    private float rotationY = 0.0f;

    private const float rightVector = 0.7f;
    private const float leftVector = 0.7f;
    private const float upVector = 0.2f;
    private const float downVector = 0.2f;
    private const float rightSpeed = 0.5f;
    private const float leftSpeed = 0.08f;
    private const float upSpeed = 0.08f;
    private const float downSpeed = 0.5f;

    void Start()
    {
        // 初期の回転を取得
        Vector3 eulerAngles = myTransform.eulerAngles;
        initializeRotationX = eulerAngles.y;
        initializeRotationY = eulerAngles.x;
        rotationX = initializeRotationX;
        rotationY = initializeRotationY;

        initializeRotation = myTransform.rotation;
    }

    public void InitializeCameraAngle()
    {
        // 回転を適用
        myTransform.rotation = initializeRotation;

        rotationX = initializeRotationX;
        rotationY = initializeRotationY;
    }

    void LateUpdate()
    {
        // マウスの左ボタンが押されているかをチェック
        if (Input.GetMouseButton(0))
        {
            // マウスの入力を取得
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // 回転量を計算
            rotationX += mouseX * sensitivity;
            rotationY -= mouseY * sensitivity;

            // 回転の制限
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            // 回転を適用
            Quaternion targetRotation = Quaternion.Euler(rotationY, rotationX, 0.0f);
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void ShootReaction()
    {
        DOTween.Sequence()
        .Append(myTransform.DOBlendableRotateBy(Vector3.left * rightVector, leftSpeed))
        .Append(myTransform.DOBlendableRotateBy(Vector3.right * leftVector, rightSpeed).SetEase(Ease.Linear));

        DOTween.Sequence()
       .Append(myTransform.DOBlendableRotateBy(Vector3.up * upVector, upSpeed))
       .Append(myTransform.DOBlendableRotateBy(Vector3.down * downVector, downSpeed).SetEase(Ease.Linear));
    }
}
