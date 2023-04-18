using Microsoft.Extensions.Configuration;

namespace StudyMate;
public static class UserConfig {
    public static string Read(string key) {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Join(Directory.GetCurrentDirectory(), "config_files"))
            .AddJsonFile("userconfig.json", optional: true, reloadOnChange: true)
            .Build();
        return config[key];
    }
    public static void Write(string key, string value) {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Join(Directory.GetCurrentDirectory(), "config_files"))
            .AddJsonFile("userconfig.json", optional: true, reloadOnChange: true)
            .Build();
        config[key] = value;
    }

    public static void Empty(){
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Join(Directory.GetCurrentDirectory(), "config_files"))
            .AddJsonFile("userconfig.json", optional: true, reloadOnChange: true)
            .Build();
        config["encryptedPassword"] = "";
        config["encryptedSessionKey"] = "";
        config["encryptedUsername"] = "";
    }
}