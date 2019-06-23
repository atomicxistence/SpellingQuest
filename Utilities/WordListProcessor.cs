using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WordListProcessor : MonoBehaviour
{
    public void LoadWordList(int id, Action<WordListModel> callback)
    {
        var url = $"http://localhost:5000/api/WordLists/{id}";

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