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
        /// Данные.
        /// </summary>
        public string Data
        {
            get => _data;
            private set
            {
                _data = value;
                onDataChangedEvent();
            }
        }
        
        /// <summary>
        /// Данные изменены.
        /// </summary>
        public event Action onDataChangedEvent = delegate { };

        [SerializeField]
        private URLData URL = default;

        private string _data = default;
        private Coroutine _loadingRoutine = default;
        private UnityWebRequest _webRequest = default;

        /// <summary>
        /// Загружает данные с сервера.
        /// </summary>
        public void LoadData() => StartCoroutine(GetDataRoutine());

        private IEnumerator GetDataRoutine()
        {
            Debug.Log("Loading...");

            using (_webRequest = UnityWebRequest.Get(URL.Url))
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
                       Data = _webRequest.downloadHandler.text;
                    }
                    Debug.Log(_webRequest.downloadHandler.text);
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
