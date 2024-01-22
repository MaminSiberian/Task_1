namespace Task1.Features.WebRequest
{
    using UnityEngine;

    /// <summary>
    /// Кнопка запроса картинки с сервера
    /// </summary>
    public class PictureRequestButton : AbstractButton
    {
        [SerializeField]
        protected WebRequestHandler webRequestHandler = default;

        protected override void OnButtonClicked() => webRequestHandler.LoadPicture();
    }
}
