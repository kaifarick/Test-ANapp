using UnityEngine;
using UnityEngine.UI;

public class LevelsView : MonoBehaviour
{
    [SerializeField] private Button _homeButton;

    private void Awake()
    {
        _homeButton.onClick.AddListener((() => gameObject.SetActive(false)));
    }

    public void Initialize()
    {
        gameObject.SetActive(true);
    }
    
    
}
