namespace Task1.Features.WebRequest
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Текстовое отображение данных
    /// </summary>
    [RequireComponent(typeof(Text))]
    public sealed class RequestDataTextView : MonoBehaviour
    {
        [SerializeField]
        private WebRequestHandler webRequestHandler = default;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            webRequestHandler.onDataChangedEvent += OnDataChanged;
        }

        private void OnDestroy() => webRequestHandler.onDataChangedEvent -= OnDataChanged;

        private void OnDataChanged() => _text.text = webRequestHandler.Data;
    }
}
