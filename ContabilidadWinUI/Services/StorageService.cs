using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using ContabilidadWinUI.Services.JsonModels;
using Newtonsoft.Json;

namespace ContabilidadWinUI.Services;

internal sealed class StorageService
{
    // ReSharper disable once InconsistentNaming
    private const string API_KEY_FILE = "keys.json";

    private Windows.Storage.ApplicationDataContainer _localSettings;
    private Windows.Storage.StorageFolder _storageFolder;

    public StorageService()
    {
        _localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        _storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
    }

    public async void ReadFile(string fileName)
    {
        try
        {
            Windows.Storage.StorageFile file = await _storageFolder.GetFileAsync(fileName);
        }
        catch (Exception)
        {
            Debug.WriteLine("File was not found.");
            throw;
        }
    }

    public async Task<Api?> GetApi(string name)
    {
        try
        {
            // get the file
            Windows.Storage.StorageFile file = await _storageFolder.GetFileAsync(API_KEY_FILE);
            // read the file and store it in string 
            var jsonString = await FileIO.ReadTextAsync(file);
            // convert json string to object
            var apiHelper = JsonConvert.DeserializeObject<ApiHelper>(jsonString);
            if (apiHelper != null)
            {
                Debug.WriteLine("Found Api file.");
                var api = apiHelper.Apis.FirstOrDefault(a => a.Name == name);
                if (api != null)
                {
                    Debug.WriteLine($"Found api {name}.");
                    return apiHelper.Apis.FirstOrDefault(a => a.Name == name);
                }
            }
        }
        catch (Exception)
        {
            Debug.WriteLine("File was not found.");
        }

        return default;
    }

    public async Task AddApi(Api api)
    {
        try
        {
            // get api file
            StorageFile apiFile = await _storageFolder.GetFileAsync(API_KEY_FILE);
            Debug.WriteLine($"Api File location {apiFile.Path}");
            // read file and store in string
            string jsonString = await FileIO.ReadTextAsync(apiFile);
            // convert json to string 
            ApiHelper? apiHelper = JsonConvert.DeserializeObject<ApiHelper>(jsonString);
            if (apiHelper != null)
            {
                // add api to apis
                apiHelper.Apis.Add(api);
                // serialize ApiHelper
                jsonString = JsonConvert.SerializeObject(apiHelper);
                // create new Api file
                apiFile = await _storageFolder.CreateFileAsync(API_KEY_FILE, CreationCollisionOption.ReplaceExisting);
                // write to file
                await FileIO.WriteTextAsync(apiFile, jsonString);
            }
        }
        catch (FileNotFoundException)
        {
            Debug.WriteLine("File was not found.");
            throw;
        }
    }
}