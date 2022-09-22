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

internal sealed class ApiService
{
    // ReSharper disable once InconsistentNaming
    private const string API_FILE = "keys.json";

    private Windows.Storage.ApplicationDataContainer _localSettings;
    private Windows.Storage.StorageFolder _storageFolder;

    public ApiService()
    {
        _localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        _storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
    }

    public async Task<Api?> GetApi(string name)
    {
        try
        {
            // get the file
            Windows.Storage.StorageFile file = await _storageFolder.GetFileAsync(API_FILE);
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

    /// <summary>
    /// <p>Adds an <see cref="Api"/> to the Api file.</p>
    /// </summary>
    /// <param name="api">The api to add to the file.</param>
    /// <exception cref="FileNotFoundException">When the Api file was not found</exception>
    public async void AddApi(Api api)
    {
        try
        {
            // get the file
            Windows.Storage.StorageFile apiFile = await _storageFolder.GetFileAsync(API_FILE);
            // read file and store as string
            string json = await FileIO.ReadTextAsync(apiFile);
            // convert json to object
            ApiHelper? helper = JsonConvert.DeserializeObject<ApiHelper>(json);
            if (helper != null)
            {
                // add api to apis
                helper.Apis.Add(api);
                // serialize ApiHelper
                json = JsonConvert.SerializeObject(helper);
                // overwrite api file
                apiFile = await _storageFolder.CreateFileAsync(API_FILE, CreationCollisionOption.ReplaceExisting);
                // write to file
                await FileIO.WriteTextAsync(apiFile, json);

#if DEBUG
                Debug.WriteLine($"Api file: {apiFile.Path}");
#endif
            }
        }
        catch (FileNotFoundException notFoundException)
        {
            Debug.WriteLine($"File not found. {notFoundException}");
            throw;
        }
    }

    /// <summary>
    /// <p>Adds an <see cref="Api"/> to the Api file.</p>
    /// </summary>
    /// <param name="api">The api to add to the file.</param>
    public async Task AddApiAsync(Api api)
    {
        StorageFile apiFile = default!;
        try
        {
            apiFile = await _storageFolder.GetFileAsync(API_FILE);
        }
        catch (FileNotFoundException)
        {
            Debug.Fail($"Api file was not found.");
            await CreateApiStorage();
            // get api file
            apiFile = await _storageFolder.GetFileAsync(API_FILE);
        }
        finally
        {
            // read file and store in string
            string json = await FileIO.ReadTextAsync(apiFile);
            // convert json to object
            ApiHelper? apiHelper = JsonConvert.DeserializeObject<ApiHelper>(json);
            if (apiHelper != null)
            {
                // add api to apis
                apiHelper.Apis.Add(api);
                // serialize ApiHelper
                json = JsonConvert.SerializeObject(apiHelper);
                // overwrite api file
                apiFile = await _storageFolder.CreateFileAsync(API_FILE, CreationCollisionOption.ReplaceExisting);
                // write to file
                await FileIO.WriteTextAsync(apiFile, json);

#if DEBUG
                Debug.WriteLine($"{apiFile.Path}");
#endif
            }
        }
    }


    private async Task CreateApiStorage()
    {
        Debug.WriteLine("Creating Api File.");

        // create empty object
        string jsonString = JsonConvert.SerializeObject(new ApiHelper());
        // create api storagefile
        StorageFile file = await _storageFolder.CreateFileAsync(API_FILE, CreationCollisionOption.ReplaceExisting);
        // write to File
        await FileIO.WriteTextAsync(file, jsonString);

        // Debug.WriteLine("Api file created succesfully.");

#if DEBUG
        Debug.WriteLine($"{file.Path}");
#endif
    }
}