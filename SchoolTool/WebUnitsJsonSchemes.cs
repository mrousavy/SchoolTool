namespace SchoolTool {
    public struct WebUnitsJsonSchemes {

        public class Authentication {
            public int id;
            public string method = "authenticate";
            public @params @params;
            public string password;
            public string jsonrpc = "2.0";
        }

        public class @params {
            public string user = "ANDROID";
            public string password;
            public string client;

            public @params(string client, string password) {
                this.password = password;
                this.client = client;
            }
        }
    }
}