using Newtonsoft.Json.Linq;
using RAWAPI.Domain.Dtos;

namespace RAW.Client.Helpers;

public static class HttpClientExtensions
{
    public static async Task<T?> ReadBaseContentAs<T>(this HttpResponseMessage response) where T : class
    {
        try
        {
            if (!response.IsSuccessStatusCode)
                return null;

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (dataAsString is null || string.IsNullOrEmpty(dataAsString))
                return null;

            var obj = JObject.Parse(dataAsString);

            if (obj is null)
                return null;

            var result = obj.ToObject<T>();

            return result;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static async Task<List<T>> ReadBaseStructContentAsArray<T>(this HttpResponseMessage response) where T : struct
    {
        try
        {
            if (!response.IsSuccessStatusCode)
                return null;

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (dataAsString is null || string.IsNullOrEmpty(dataAsString))
                return null;

            var obj = JArray.Parse(dataAsString);

            if (obj is null)
                return null;

            var result = obj.ToObject<T[]>();

            return result.ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static async Task<List<T>> ReadBaseContentAsArray<T>(this HttpResponseMessage response) where T : class
    {
        try
        {
            if (!response.IsSuccessStatusCode)
                return null;

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (dataAsString is null || string.IsNullOrEmpty(dataAsString))
                return null;

            var obj = JArray.Parse(dataAsString);

            if (obj is null)
                return null;

            var result = obj.ToObject<T[]>();

            return result.ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static async Task<CommandResult<T>> ReadContentAs<T>(this HttpResponseMessage response) where T : class
    {
        try
        {
            if (!response.IsSuccessStatusCode)
                return CommandResult<T>.GetFailed(response.ReasonPhrase ?? "");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (dataAsString is null || string.IsNullOrEmpty(dataAsString))
                return CommandResult<T>.GetFailed("test");

            var obj = JObject.Parse(dataAsString);

            if (obj is null)
                return CommandResult<T>.GetFailed("test2");

            // obj.ToObject<CommandResult<T>>();

            var dataobj = obj["data"] ?? obj["Data"];
            var messageobj = obj["message"] ?? obj["Message"];
            var issuceedobj = obj["isSucceed"] ?? obj["IsSucceed"];

            var issucceed = issuceedobj?.ToObject<bool>() ?? false;

            if (issucceed && dataobj is not null)
                return CommandResult<T>.GetSucceed(messageobj?.ToString() ?? string.Empty, dataobj.ToObject<T>());


            return CommandResult<T>.GetFailed(messageobj?.ToString() ?? string.Empty);
        }
        catch (Exception ex)
        {
            return CommandResult<T>.GetFailed(ex);
        }
    }
}
