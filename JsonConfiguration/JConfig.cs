using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace JsonConfiguration
{
    public class JConfig
    {
        private static readonly JConfig instance = new JConfig();
        
        private PathResolver _pathResolver =  new PathResolver();

        static JConfig()
        {
            
        }

        private JConfig()
        {
            
        }

        public T Load<T>()
        {
            var path = _pathResolver.ResolvePath<T>(throwOnNotFound: true);
            
            using (var fileReader = File.OpenText(path))
            {
                return JsonConvert.DeserializeObject<T>(fileReader.ReadToEnd());
            }
        }

        public void Save<T>(T obj) where T : class
        {
            if (obj == null) throw new ArgumentNullException("obj");

            var file = _pathResolver.ResolvePath<T>();

            File.WriteAllText(file,JsonConvert.SerializeObject(obj,Formatting.Indented),Encoding.Default);
        }

        public static JConfig Instance
        {
            get { return instance; }
        }
    }
}
