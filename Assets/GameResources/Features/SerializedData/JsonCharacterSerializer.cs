namespace Task1.Features.SerializedData
{
    using System.IO;
    using UnityEngine;

    /// <summary>
    /// Скрипт, сохраняющий введенные данные
    /// </summary>
    public sealed class JsonCharacterSerializer : MonoBehaviour
    {
        [SerializeField]
        private string _characterId = default;

        [SerializeField]
        private int _characterLvl = default;

        private CharacterData _data = default;

        private const string PATH = "char.json";
        private string _path = default;

        /// <summary>
        /// Сохраняет данные в файл
        /// </summary>
        public void SaveData()
        {
            _data = new CharacterData();

            if (_characterId == null)
            {
                Debug.Log("No data");
                return;
            }

            _data.Id = _characterId;
            _data.Level = _characterLvl;

            string data = JsonUtility.ToJson(_data);
            _path = Path.Combine(Application.persistentDataPath, PATH);

            File.WriteAllText(_path, data);

            Debug.Log(Path.Combine(Application.persistentDataPath, PATH));
        }

        /// <summary>
        /// Загружает данные из файла
        /// </summary>
        public void LoadData()
        {
            if (!File.Exists(Path.Combine(Application.persistentDataPath, PATH)))
            {
                Debug.Log("No file :(");
                return;
            }
            else
            {
                _path = Path.Combine(Application.persistentDataPath, PATH);
                string fileData = File.ReadAllText(_path);

                _data = JsonUtility.FromJson<CharacterData>(fileData);

                Debug.Log(_data.Id);
                Debug.Log(_data.Level);
            }
        }
    }
}
