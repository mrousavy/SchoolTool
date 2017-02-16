namespace SchoolTool {
    //All JSON Queries from the WebUntis API translated to C#
    public struct WebUnitsJsonSchemes {
        //Authenticate the given user and start a session
        public class Authentication {
            public string id;
            public string method = "authenticate";
            public @params @params;
            public string password;
            public string jsonrpc = "2.0";
        }

        public class Logout {
            public string id;
            public string method = "logout";
            public @params @params;
            public string jsonrpc = "2.0";
        }

        //Parameter Class for JSON Query Method Parameters
        public class @params {
            public string user = "ANDROID";
            public string password;
            public string client;
        }
    }
}