using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_target = null;  //追いかけるターゲット
    [SerializeField]
    private float m_speed = 0.0f;   //追いかけるスピード
    [SerializeField]
    private float m_waitRange = 0.0f;   //カメラの焦点位置からの距離

    public Transform Target
    {
        get { return m_target; }
    }

    private Transform m_cameraTransform = null; //カメラの位置調整用
    private Transform m_pivot = null;   //カメラとターゲットの距離調整用

    private void Awake()
    {
        Camera camera = GetComponentInChildren<Camera>();
        Debug.AssertFormat(camera != null, "カメラが見つかりません");
        if (camera == null)
        {
            return;
        }

        m_cameraTransform = camera.transform;
        m_pivot = m_cameraTransform.parent;
    }

    private void LateUpdate()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        //ターゲットが見つからなかった場合
        if (Target == null)
        {
            return;
        }

        Vector3 toTargetVec = Target.position - transform.position; //ターゲットからの距離
        float sqrLength = toTargetVec.sqrMagnitude;

        // 設定した範囲内なら更新しない。
        // magnitudeはルート計算が重いので、二乗された値を利用しよう。
        if (sqrLength <= m_waitRange * m_waitRange)
        {
            return;
        }

        //ターゲットの位置から指定範囲内ギリギリの位置を目指すようにするよ。
        Vector3 targetPos = Target.position;

        float deltaSpeed = m_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, deltaSpeed);

        Vector3 pos = m_cameraTransform.position;
        pos.y = 10.0f;
        m_cameraTransform.position = pos;
    }

}   //参考：https://www.urablog.xyz/entry/2017/10/09/093920
