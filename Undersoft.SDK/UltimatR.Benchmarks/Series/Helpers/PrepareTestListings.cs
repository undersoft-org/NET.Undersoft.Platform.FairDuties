namespace System.Series.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Uniques;

    public static class PrepareTestListings
    {
        public static IList<KeyValuePair<object, string>> prepareIdentifierKeyTestCollection()
        {
            List<KeyValuePair<object, string>> list = new List<KeyValuePair<object, string>>();
            string now = DateTime.Now.ToString() + "_prepareStringKeyTestCollection";
            ulong max = uint.MaxValue + 2000 * 1000L;
            for (ulong i = uint.MaxValue; i < max; i++)
            {
                string str = i.ToString() + "_" + now;
                list.Add(new KeyValuePair<object, string>(new Uscn(i), str));
            }
            return list;
        }

        public static IList<KeyValuePair<object, string>> prepareIntKeyTestCollection()
        {
            List<KeyValuePair<object, string>> list = new List<KeyValuePair<object, string>>();
            string now = DateTime.Now.ToString() + "_prepareStringKeyTestCollection";
            for (int i = 0; i < 2000 * 1000; i++)
            {
                string str = i.ToString() + "_" + now;
                list.Add(new KeyValuePair<object, string>(i, str));
            }
            return list;
        }

        public static IList<KeyValuePair<object, string>> prepareLongKeyTestCollection()
        {
            List<KeyValuePair<object, string>> list = new List<KeyValuePair<object, string>>();
            string now = DateTime.Now.ToString() + "_prepareStringKeyTestCollection";
            ulong max = uint.MaxValue + (2000 * 1000L);
            for (ulong i = uint.MaxValue; i < max; i++)
            {
                string str = i.ToString() + "_" + now;
                list.Add(new KeyValuePair<object, string>(i, str));
            }
            return list;
        }

        public static IList<KeyValuePair<object, string>> prepareStringKeyTestCollection()
        {
            List<KeyValuePair<object, string>> list = new List<KeyValuePair<object, string>>();
            string now = DateTime.Now.ToString() + "_prepareStringKeyTestCollection";
            for (int i = 0; i < 2000 * 1000; i++)
            {
                string str = i.ToString() + "_" + now;
                list.Add(
                    new KeyValuePair<object, string>(
                        (i + 1000).ToString() + Unique.New.ToString(),
                        str
                    )
                );
            }
            List<object> keys = new List<object>();
            for (int i = 0; i < 2000 * 1000; i++)
            {
                keys.Add(list[i].Key);
            }
            List<ulong> hashes = new List<ulong>();
            foreach (var s in keys)
            {
                hashes.Add(s.UniqueKey64());
            }
            return list;
        }
    }
}
