using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity; // マウスの感度
    [SerializeField] private float rotationSpeed; // 回転のスピード
    [SerializeField] private Transform myTransform;

    private float rotationX = 0.0f;
    private float initializeRotationX = 0.0f;
    private float initializeRotationY = 0.0f;
    private float rotationY = 0.0f;
    private Quaternion initializeRotation;

    void Start()
    {
        // 初期の回転を取得
        initializeRotationX = myTransform.eulerAngles.y;
        initializeRotationY = myTransform.eulerAngles.x;
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
        .Append(myTransform.DOBlendableRotateBy(Vector3.left * 0.7f, 0.08f))
        .Append(myTransform.DOBlendableRotateBy(Vector3.right * 0.7f, 0.5f).SetEase(Ease.Linear));

        DOTween.Sequence()
       .Append(myTransform.DOBlendableRotateBy(Vector3.up * 0.2f, 0.08f))
       .Append(myTransform.DOBlendableRotateBy(Vector3.down * 0.2f, 0.5f).SetEase(Ease.Linear));
    }
}
