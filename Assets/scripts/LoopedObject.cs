using UnityEngine;

public class LoopedObject : MonoBehaviour
{
    private void LateUpdate()
    {
        // ループ管理システムがあれば、位置の計算をしてもらおう。
        // 通常の操作処理をUpdate()で行っているので、とりあえずLateUpdate()で処理しているよ。
        if (LoopedField.Instance != null)
        {
            transform.position = LoopedField.Instance.ComputePosition(transform.position);
        }
    }

} // class LoopedObject