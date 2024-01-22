namespace Task1.Features.WebRequest
{
    using UnityEngine;

    /// <summary>
    /// Кнопка отправки запроса на получение текста с сервера.
    /// </summary>
    public class TextRequestButton : AbstractButton
    {
        [SerializeField]
        protected WebRequestHandler webRequestHandler = default;

        protected override void OnButtonClicked() => webRequestHandler.LoadText();
    }
}
