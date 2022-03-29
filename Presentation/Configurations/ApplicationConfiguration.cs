namespace Presentation.Configurations;

internal static class ApplicationConfiguration
{
    public const string ConfigurationFilePath = @"appsettings.json";

    public static string ConnectionString
    {
        get
        {
            string defaultValue = string.Empty;

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result is not null
                ? result.ConnectionString
                : defaultValue;
        }
        set
        {
            ApplicationSettings data = new(connectionString: value);

            SerializeObject(data);
        }
    }

    private static void SerializeObject(object obj)
    {
        JsonSerializer serializer = new() { NullValueHandling = NullValueHandling.Ignore };

        serializer.Converters.Add(item: new JavaScriptDateTimeConverter());

        using var stream = new StreamWriter(path: ConfigurationFilePath);

        using var writer = new JsonTextWriter(textWriter: stream);

        serializer.Serialize(jsonWriter: writer, value: obj);
    }

    [Serializable]
    private sealed record class ApplicationSettings
    {
        public string ConnectionString { get; init; }

        public ApplicationSettings(string connectionString) =>
            ConnectionString = connectionString;
    }
}