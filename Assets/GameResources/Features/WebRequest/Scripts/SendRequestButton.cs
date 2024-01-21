namespace Task1.Features.WebRequest
{
    using UnityEngine;

    /// <summary>
    /// ������ �������� ������� �� ������.
    /// </summary>
    public class SendRequestButton : AbstractButton
    {
        [SerializeField]
        protected WebRequestHandler webRequestHandler = default;

        protected override void OnButtonClicked() => webRequestHandler.LoadData();
    }
}
