namespace Task1.Features.SerializedData
{
    using UnityEngine;
    using Task1.Features.WebRequest;

    /// <summary>
    /// Кнопка сохранения данных
    /// </summary>
    public sealed class SaveButton : AbstractButton
    {
        [SerializeField]
        private JsonCharacterSerializer _serializer = default;

        protected override void OnButtonClicked()
        {
            if (_serializer != null)
            {
                _serializer.SaveData();
            }
        }
    }
}
