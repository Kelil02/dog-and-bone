using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject target; 

    public void Close()
    {
        if (target == null) target = transform.parent?.gameObject;
        if (target != null) target.SetActive(false);
    }
}
