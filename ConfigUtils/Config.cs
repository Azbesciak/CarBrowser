using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace ConfigUtils
{
    public class Config
    {
        public static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var result = appSettings[key] ?? throw new NullReferenceException($"Key {key} was not found in app.config");
            return result;
        }

        public static Assembly GetPackage(string daoDll)
        {
            if (!daoDll.Contains(":"))
            {
                var root = Directory.GetParent(@"../../../").FullName;
                daoDll = Path.Combine(root, daoDll);
            }

            try
            {
                var package = Assembly.LoadFile(daoDll);
                AppDomain.CurrentDomain.Load(package.GetName());
                return package;
            }
            catch (Exception e)
            {
                Console.WriteLine("Some dependency is not correct; check in settings: {0}", e.Message);
                throw;
            }
        }
    }
}
