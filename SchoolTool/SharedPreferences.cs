using Android.Content;
using System;
using System.Collections.Generic;

namespace SchoolTool {
    public class SharedPreferences : ISharedPreferences {
        public IDictionary<string, object> All => throw new NotImplementedException();

        public IntPtr Handle => throw new NotImplementedException();

        public bool Contains(string key) => throw new NotImplementedException();
        public void Dispose() => throw new NotImplementedException();
        public ISharedPreferencesEditor Edit() => throw new NotImplementedException();
        public bool GetBoolean(string key, bool defValue) => throw new NotImplementedException();
        public float GetFloat(string key, float defValue) => throw new NotImplementedException();
        public int GetInt(string key, int defValue) => throw new NotImplementedException();
        public long GetLong(string key, long defValue) => throw new NotImplementedException();
        public string GetString(string key, string defValue) => throw new NotImplementedException();
        public ICollection<string> GetStringSet(string key, ICollection<string> defValues) => throw new NotImplementedException();
        public void RegisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener listener) => throw new NotImplementedException();
        public void UnregisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener listener) => throw new NotImplementedException();
    }
}