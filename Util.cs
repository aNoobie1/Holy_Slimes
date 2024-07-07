using UnityEngine;
using System.Reflection;
using System.Linq;

namespace HolySlimes.Utility
{
    internal static class Util
    {
        public static void Log(string msg) => SRML.Console.Console.Instance.Log(msg);

        public static void LogError(string msg) => SRML.Console.Console.Instance.LogError(msg);

        public static Texture2D LoadImage(string filename)
        {
            var a = Assembly.GetExecutingAssembly();
            var spriteData = a.GetManifestResourceStream("HolySlimes.Images." + filename);
            var rawData = new byte[spriteData.Length];
            spriteData.Read(rawData, 0, rawData.Length);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(rawData);
            tex.filterMode = FilterMode.Bilinear;
            return tex;
        }

        public static Texture2D LoadRamp(string filename)
        {
            var a = Assembly.GetExecutingAssembly();
            var spriteData = a.GetManifestResourceStream("HolySlimes.Ramps." + filename);
            var rawData = new byte[spriteData.Length];
            spriteData.Read(rawData, 0, rawData.Length);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(rawData);
            tex.filterMode = FilterMode.Bilinear;
            return tex;
        }

        public static T Get<T>(string name) where T : UnityEngine.Object
        {
            return Resources.FindObjectsOfTypeAll<T>().First((T x) => x.name == name);
        }

        public static GameObject GetObj(string name)
        {
            return Get<GameObject>(name);
        }

        public static Sprite CreateSprite(Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1);

        public static AssetBundle LoadCustomStructure(string filename) => AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("HolySlimes.AssetBundles.Structures." + filename));
        public static AssetBundle LoadCustomZone(string filename) => AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("HolySlimes.AssetBundles.Zones." + filename));
    }
}