namespace Task1.Features.SerializedData
{
    using UnityEngine;
    using Task1.Features.WebRequest;

    /// <summary>
    ///  нопка загрузки данных
    /// </summary>
    public class LoadButton : AbstractButton
    {
        [SerializeField]
        private JsonCharacterSerializer _serializer = default;

        protected override void OnButtonClicked()
        {
            if (_serializer != null)
            {
                _serializer.LoadData();
            }
        }
    }
}
