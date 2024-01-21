namespace Task1.Features.WebRequest
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// ���������� ������.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        protected Button button;

        protected virtual void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClicked);
        }

        protected virtual void OnDestroy() => button.onClick.RemoveListener(OnButtonClicked);

        protected abstract void OnButtonClicked();
    }
}
