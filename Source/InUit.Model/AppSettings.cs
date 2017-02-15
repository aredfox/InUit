using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System;
using System.Reflection;

namespace InUit.Model
{
    public sealed class AppSettings
    {
        private readonly FileInfo _appSettings;

        public DirectoryInfo WorkingDirectory {
            get {
                Load();
                return _workingDirectory;
            }
            set {
                _workingDirectory = value;
                Save();
            }
        }
        private DirectoryInfo _workingDirectory;
        
        public bool HasWorkingDirectory => WorkingDirectory != null
            ? WorkingDirectory.Exists
            : false;

        public AppSettings() {
            _appSettings = new FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "AppSettings.json"));            
            Load(_appSettings);
        }

        public void Save() {
            Save(_appSettings);
        }

        public void Save(FileInfo appSettings) {
            if (appSettings == null) {
                throw new ArgumentNullException(nameof(appSettings));
            }

            var serializerSettings = new JsonSerializerSettings() {                
                Formatting = Formatting.Indented
            };

            var settings = JsonConvert.SerializeObject(
                new RawAppSettings() {
                    WorkingDirectoryString = _workingDirectory?.FullName
                },
                serializerSettings
            );

            if (!Directory.Exists(appSettings.Directory.FullName)) {
                Directory.CreateDirectory(appSettings.Directory.FullName);
            }
            File.WriteAllText(appSettings.FullName, settings);
        }

        public void Load() {
            Load(_appSettings);
        }

        public void Load(FileInfo appSettings) {            
            if(appSettings == null) {
                throw new ArgumentNullException(nameof(appSettings));
            }

            if(!appSettings.Exists) {
                Save(appSettings);
            }

            var settings = JsonConvert.DeserializeObject<RawAppSettings>(File.ReadAllText(appSettings.FullName));
            WorkingDirectory = new DirectoryInfo(settings.WorkingDirectoryString ?? @"\\null\null\null\");
        }
    }

    internal sealed class RawAppSettings
    {
        public string WorkingDirectoryString { get; set; }
    }
}
