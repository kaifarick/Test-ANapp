using UnityEngine;
using UnityEngine.UI;

public abstract class BaseWindow : MonoBehaviour
{
    [SerializeField] protected Button _closeButton;

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
