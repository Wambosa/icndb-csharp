using System.Threading.Tasks;

namespace ChuckNorris
{
    public static class API
    {
        public static Task<Joke> Random(string[] limitTo = null, string[] exclude = null, bool isHTML = true)
        {
            string url = "http://api.icndb.com/jokes/random";

            bool toInclude = limitTo != null, toExclude = exclude != null;

            if (toExclude) url += string.Format("&exclude=[{0}]", string.Join(",", exclude));
            if (toInclude) url += string.Format("&limitTo=[{0}]", string.Join(",", limitTo));

            url                += (!isHTML ? "&escape=javascript": "");

            return WebHelper.Json<Result>(url).ContinueWith(t => t.Result.Value);
        }
    }
}
        