namespace Task1.Features.WebRequest
{
    using UnityEngine;

    public class PictureRequestButton : AbstractButton
    {
        [SerializeField]
        protected WebRequestHandler webRequestHandler = default;

        protected override void OnButtonClicked() => webRequestHandler.LoadPicture();
    }
}