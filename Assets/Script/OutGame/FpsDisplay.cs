using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsDisplay : MonoBehaviour
{
    // 変数
    int frameCount;
    float prevTime;
    float fps;

    // 初期化処理
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }
    // 更新処理
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }

    // 表示処理
    private void OnGUI()
    {
        GUI.color = Color.black;
        GUI.skin.label.fontSize = 100;
        GUILayout.Label(fps.ToString(), GUILayout.Width(1000), GUILayout.Height(150));
    }
}
