namespace SchoolTool {
    //All JSON Queries from the WebUntis API translated to C#
    public namespace WebUnitsJsonSchemes {
        #region Special Classes
        //Base-Class for all Queries
        public struct WebUntisQuery {
            public string id;
            public string method;
            public string jsonrpc = "2.0";
            //public @params @params;

            public class @params { }
        }
        //Parameter Class for JSON Query Method Parameters
        //public class @params {
        //    public string user = "ANDROID";
        //    public string password;
        //    public string client;
        //}

        //Response or Result from a Query
        public struct result {
            public string sessionId;
            public int personType;
            public int personId;
        }
        #endregion

        #region Individual Queries
        //Authenticate the given user and start a session
        public struct Authentication : WebUntisQuery {
            public string id;
            public readonly string method = "authenticate";

            public class @params {
                public string user = "ANDROID";
                public string password;
                public string client;
            }
        }

        //End the session
        public struct Logout : WebUntisQuery {
            public string id;
            public readonly string method = "logout";
        }

        //Get list of teachers
        public struct Teachers : WebUntisQuery {
            public string id;
            public readonly string method = "getTeachers";
        }

        //Get list of students
        public struct Students : WebUntisQuery {
            public string id;
            public readonly string method = "getStudents";
        }
        #endregion
    }
}
