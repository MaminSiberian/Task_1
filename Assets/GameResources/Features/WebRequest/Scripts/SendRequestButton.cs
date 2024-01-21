namespace Task1.Features.WebRequest
{
    using UnityEngine;

    /// <summary>
    /// Кнопка отправки запроса на сервер.
    /// </summary>
    public class SendRequestButton : AbstractButton
    {
        [SerializeField]
        protected WebRequestHandler webRequestHandler = default;

        protected override void OnButtonClicked() => webRequestHandler.LoadData();
    }
}
