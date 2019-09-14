using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WordListProcessor : MonoBehaviour
{
    public static WordListProcessor SharedInstance {get; private set;}

    private void Awake()
    {
        #region Singleton
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else if (SharedInstance != this)
        {
            Destroy(gameObject);
        }
        #endregion

        DontDestroyOnLoad(this);
    }

    public void LoadWordList(int id, Action<WordListModel> callback)
    {
        var url = $"sq-api.azurewebsites.net/api/WordLists/{id}";

        StartCoroutine(GetListFromAPI(url, callback));
    }

    private IEnumerator GetListFromAPI(string url, Action<WordListModel> callback)
    {
        using(var request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }

            var jsonResponse = request.downloadHandler.text;
            var wordList = JsonUtility.FromJson<WordListModel>(jsonResponse);

            callback(wordList);
        }
    }
}