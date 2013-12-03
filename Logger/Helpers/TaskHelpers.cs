using System.Threading.Tasks;

namespace Streamline.Logging.Helpers
{
    public class TaskHelpers
    {
        public static Task<T> FromResult<T>(T value)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(value);
            return tcs.Task;
        }

        public static Task Empty
        {
            get
            {
                return MakeTask<object>(null);
            }
        }

        static Task<T> MakeTask<T>(T value)
        {
            return FromResult<T>(value);
        }
    }
}
