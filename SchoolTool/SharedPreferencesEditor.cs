using Android.Content;
using System;
using System.Collections.Generic;

namespace SchoolTool {
    public class SharedPreferencesEditor : ISharedPreferencesEditor {
        public IntPtr Handle => throw new NotImplementedException();

        public void Apply() => throw new NotImplementedException();
        public ISharedPreferencesEditor Clear() => throw new NotImplementedException();
        public bool Commit() => throw new NotImplementedException();
        public void Dispose() => throw new NotImplementedException();
        public ISharedPreferencesEditor PutBoolean(string key, bool value) => throw new NotImplementedException();
        public ISharedPreferencesEditor PutFloat(string key, float value) => throw new NotImplementedException();
        public ISharedPreferencesEditor PutInt(string key, int value) => throw new NotImplementedException();
        public ISharedPreferencesEditor PutLong(string key, long value) => throw new NotImplementedException();
        public ISharedPreferencesEditor PutString(string key, string value) => throw new NotImplementedException();
        public ISharedPreferencesEditor PutStringSet(string key, ICollection<string> values) => throw new NotImplementedException();
        public ISharedPreferencesEditor Remove(string key) => throw new NotImplementedException();
    }
}