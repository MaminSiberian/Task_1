namespace Task1.Features.WebRequest
{
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Networking;

    /// <summary>
    /// Скрипт, получающий данные по ссылке.
    /// </summary>
    public sealed class WebRequestHandler : MonoBehaviour
    {
        /// <summary>
        /// Текст.
        /// </summary>
        public string TextData
        {
            get => _textData;
            private set
            {
                _textData = value;
                onTextDataGetEvent();
            }
        }

        /// <summary>
        /// Изображение.
        /// </summary>
        public Texture2D PictureData
        {
            get => _pictureData;
            private set
            {
                _pictureData = value;
                onPictureDataGetEvent();
            }
        }

        /// <summary>
        /// Текст получен.
        /// </summary>
        public event Action onTextDataGetEvent = delegate { };

        /// <summary>
        /// Изображение получено.
        /// </summary>
        public event Action onPictureDataGetEvent = delegate { };

        [SerializeField]
        private URLData _textURL = default;        
        
        [SerializeField]
        private URLData _pictureURL = default;

        private string _textData = default;
        private Texture2D _pictureData = default;
        private Coroutine _loadingRoutine = default;
        private UnityWebRequest _webRequest = default;
        private DownloadHandlerTexture _downloadHandlerTexture = default;

        /// <summary>
        /// Загружает текст с сервера.
        /// </summary>
        public void LoadText() => StartCoroutine(GetTextRoutine());

        /// <summary>
        /// Загружает изображение с сервера.
        /// </summary>
        public void LoadPicture() => StartCoroutine(GetPictureRoutine());

        private IEnumerator GetTextRoutine()
        {
            Debug.Log("Loading...");

            using (_webRequest = UnityWebRequest.Get(_textURL.Url))
            {
                _loadingRoutine = StartCoroutine(ShowProgress(_webRequest));

                yield return _webRequest.SendWebRequest();
                StopCoroutine(_loadingRoutine);

                if (_webRequest.isNetworkError || _webRequest.isHttpError)
                {
                    Debug.Log(_webRequest.error);
                }
                else
                {
                    if (_webRequest.downloadHandler.text != null)
                    {
                       TextData = _webRequest.downloadHandler.text;
                    }
                    Debug.Log(_webRequest.downloadHandler.text);
                }
            }
        }

        private IEnumerator GetPictureRoutine()
        {
            Debug.Log("Loading...");

            using (_webRequest = UnityWebRequestTexture.GetTexture(_pictureURL.Url))
            {
                _loadingRoutine = StartCoroutine(ShowProgress(_webRequest));

                yield return _webRequest.SendWebRequest();
                StopCoroutine(_loadingRoutine);

                if (_webRequest.isNetworkError || _webRequest.isHttpError)
                {
                    Debug.Log(_webRequest.error);
                }
                else
                {
                    _downloadHandlerTexture = (DownloadHandlerTexture)_webRequest.downloadHandler;
                    PictureData = _downloadHandlerTexture.texture;
                }
            }
        }

        private IEnumerator ShowProgress(UnityWebRequest request)
        {
            while (isActiveAndEnabled && request != null)
            {
                Debug.Log(Mathf.Clamp01(request.downloadProgress));
                yield return null;
            }
        }
    }
}
