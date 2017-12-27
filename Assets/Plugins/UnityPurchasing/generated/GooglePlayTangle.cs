#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("ZnKVqJQvaYPOJgDSzv00f9U+K6ZDpxSIXFwbTP3XSh6TxXK6DjjYpJ2u9P+bisN8V/08DJ0XlIGAND8iow575nRqnNtI6NiSsqRCjHdxOSeFZGaWq1+5UjPF/Rm8cc0CqGJxu5Igo4CSr6SriCTqJFWvo6Ojp6KhcOQdilZJOKEf76hIPu0SlMwETgKi8ufanyjA9e4bJJmx1/rJ7BLAQghHyiNV835vnCP9gKyol1zhZXNq0Nm4ISpglNnBojI1qqpbouP2rSQ8ubtuprd2h1+IhdVeFKenDxnweLSqWqGnsczteapFVmCYu2T+Q8mpIKOtopIgo6igIKOjojdQ/KsrrPNwEN0eYONiFS/uzoic5eBLEL0IXjECznbDU1y7maCho6Kj");
        private static int[] order = new int[] { 10,6,12,4,7,10,9,12,10,13,11,11,13,13,14 };
        private static int key = 162;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
