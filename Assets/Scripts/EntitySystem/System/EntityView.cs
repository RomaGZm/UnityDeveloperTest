using UnityEngine;

public class EntityView : MonoBehaviour
{
    [SerializeField] private MeshRenderer rend;

    private MaterialPropertyBlock mpb;

    //Initialize material
    private void Awake()
    {
        mpb = new MaterialPropertyBlock();
        rend.GetPropertyBlock(mpb);
    }

    public void SetColor(Color color)
    {
        mpb.SetColor("_BaseColor", color);
        rend.SetPropertyBlock(mpb);
    }
}
