using System;
using System.Configuration;
using System.IO;

namespace JsonConfiguration
{
    internal class PathResolver
    {
        private readonly string DefaultJsonPath = "JsonConfig";

        public string ResolvePath<T>(bool throwOnNotFound = false)
        {
            var rootPath = SafeGetDefaultPath();
            var file = Path.Combine(rootPath, string.Format("{0}.json", typeof(T).Name));

            if (throwOnNotFound && !File.Exists(file))
                throw new InvalidOperationException(string.Format("Expected a file {0}", file));

            return file;
        }

        private string RootPath 
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(),
                    ConfigurationManager.AppSettings["JsonPath"] ?? DefaultJsonPath);
            }
        }

        private string SafeGetDefaultPath()
        {
            var safeGet = RootPath;
            if (!Directory.Exists(RootPath))
                Directory.CreateDirectory(RootPath);

            return safeGet;
        }
    }
}