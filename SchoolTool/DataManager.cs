using Android.Content;
using Android.Preferences;

namespace SchoolTool {
    internal class DataManager {
        private Context _context;

        internal string Password {
            get {
                string password = "";
                using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                    password = Cipher.Decrypt(prefs.GetString("password", null));
                }

                return password;
            }
            set {
                using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                    using (ISharedPreferencesEditor editor = prefs.Edit()) {

                        //encrypt everything - why not
                        editor.PutString("password", Cipher.Encrypt(value));

                        editor.Apply();
                    }
                }
            }
        }
        internal string Username {
            get {
                string username = "";
                using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                    username = Cipher.Decrypt(prefs.GetString("username", null));
                }

                return username;
            }
            set {
                using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                    using (ISharedPreferencesEditor editor = prefs.Edit()) {

                        //encrypt everything - why not
                        editor.PutString("username", Cipher.Encrypt(value));

                        editor.Apply();
                    }
                }
            }
        }
        internal string SchoolUrl {
            get {
                string schoolurl = "";
                using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                    schoolurl = Cipher.Decrypt(prefs.GetString("schoolurl", null));
                }

                return schoolurl;
            }
            set {
                using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                    using (ISharedPreferencesEditor editor = prefs.Edit()) {

                        //encrypt everything - why not
                        editor.PutString("schoolurl", Cipher.Encrypt(value));

                        editor.Apply();
                    }
                }
            }
        }
        internal bool NotifyChanges {
            get {
                bool value;
                using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                    value = prefs.GetBoolean("notifychanges", true);
                }

                return value;
            }
            set {
                using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                    using (ISharedPreferencesEditor editor = prefs.Edit()) {

                        editor.PutBoolean("schoolurl", value);

                        editor.Apply();
                    }
                }
            }
        }

        internal DataManager(Context context) {
            _context = context;
        }


        internal void SaveData(string username, string password, string schoolUrl) {
            using (ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context)) {
                using (ISharedPreferencesEditor editor = prefs.Edit()) {

                    //encrypt everything - why not
                    editor.PutString("username", Cipher.Encrypt(username));
                    editor.PutString("password", Cipher.Encrypt(password));
                    editor.PutString("schoolurl", Cipher.Encrypt(schoolUrl));

                    editor.Apply();
                }
            }
        }
    }
}