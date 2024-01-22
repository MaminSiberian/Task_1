namespace Task1.Features.WebRequest
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Спрайтовое отображение данных
    /// </summary>
    [RequireComponent(typeof(Image))]
    public sealed class RequestDataImageView : MonoBehaviour
    {
        [SerializeField]
        private WebRequestHandler _webRequestHandler = default;

        private Image _image;
        private Sprite _sprite = default;
        private Texture2D _texture = default;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _webRequestHandler.onPictureDataGetEvent += OnPictureDataGet;
        }

        private void OnDestroy() => _webRequestHandler.onPictureDataGetEvent -= OnPictureDataGet;

        private void OnPictureDataGet()
        {
            _texture = _webRequestHandler.PictureData;
            _sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), new Vector2(0, 0));
            _image.sprite = _sprite;
        }
    }
}

