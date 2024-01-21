namespace Task1.Features.WebRequest
{
    using UnityEngine;

    /// <summary>
    /// —сылка.
    /// </summary>
    [CreateAssetMenu(menuName = "Task1/WebRequest/New URL Data", fileName = "URL Data")]
    public sealed class URLData : ScriptableObject
    {
        public string Url => _url;

        [SerializeField]
        private string _url;
    }
}
