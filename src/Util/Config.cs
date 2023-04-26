using Microsoft.Extensions.Configuration;

namespace StudyMate;
public class UserConfig {
    public static readonly string configPath = Path.Join(Directory.GetCurrentDirectory(), "config_files", "userconfig.json");
    public static IConfigurationRoot config = new ConfigurationBuilder() .SetBasePath(Path.Join(Directory.GetCurrentDirectory(), "config_files"))
            .AddJsonFile("userconfig.json", optional: true, reloadOnChange: true)
            .Build();
    public static void Initialize() {
        if(!File.Exists(configPath)){
            File.Create(configPath);
            Write("encryptedPassword", "");
            Write("encryptedSessionKey", "");
            Write("encryptedUsername", "");
        };
    }
    public static string Read(string key) {
        return config[key];
    }
    public static void Write(string key, string value) {
        config[key] = value;
    }

    public static void Empty(){
        config["encryptedPassword"] = "";
        config["encryptedSessionKey"] = "";
        config["encryptedUsername"] = "";
    }
}
