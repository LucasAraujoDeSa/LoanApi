namespace LoansApp.Shared.Utils
{
    public class GetHttpStatusCode
    {
        private static readonly IDictionary<string, int> StatusCode = new Dictionary<string, int>(){
            {"CREATED", 201},
            {"OK", 200},
            {"OPERATIONAL_ERROR", 400},
            {"NOT_FOUND", 404},
            {"INTERNAL_ERROR", 500},
        };
        public static int Get(string status)
        {
            return StatusCode[status];
        }
    }
}