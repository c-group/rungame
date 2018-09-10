using UnityEngine;

public class LoopedField : MonoBehaviour
{
    // ループフィールドのサイズ(今回はY軸は使わないようなものだけど)。
    [SerializeField]
    private Vector3 m_fieldSize = Vector3.zero;

    // ループのフィールドの管理にはBoundsを使用する。
    // これはフィールドの中心が(0,0,0)の地点でない場合の最小位置と最大位置の計算を、Boundsクラスを使って手を抜きたいため。
    private Bounds m_bounds = new Bounds();
    public Bounds FieldBounds
    {
        get
        {
            return m_bounds;
        }
    }

    // ループする各オブジェクトがアクセスしたいので、シングルトンにしよう。
    public static LoopedField Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        OnValidate();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void OnValidate()
    {
        // エディタ上でフィールド範囲が変わってしまった際の対応。
        m_bounds = new Bounds(transform.position, m_fieldSize);
    }

    private void OnDrawGizmos()
    {
        // ビュー上でループする範囲が見えるようにしておこう。
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, m_fieldSize);
    }

    public Vector3 ComputePosition(Vector3 i_position)
    {
        Vector3 pos = i_position;

        // ループ用の位置計算処理
        // Mathf.Repeat()を使えばもうコードが綺麗になるかもしれないけど、別にいいや。

        if (i_position.x < m_bounds.min.x)
        {
            pos.x += m_bounds.size.x;
        }
        if (i_position.x > m_bounds.max.x)
        {
            pos.x -= m_bounds.size.x;
        }
        if (i_position.z < m_bounds.min.z)
        {
            pos.z += m_bounds.size.x;
        }
        if (i_position.z > m_bounds.max.z)
        {
            pos.z -= m_bounds.size.x;
        }

        return pos;
    }

} // class LoopedField