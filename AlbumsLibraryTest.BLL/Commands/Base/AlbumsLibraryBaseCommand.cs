using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Commands.Base
{
    public abstract class AlbumsLibraryBaseCommand<TResponse> where TResponse : class
    {
        protected abstract TResponse OnRun(); 

        public virtual TResponse Run()
        {
            var result = OnRun();

            return result;
        }

        public virtual Task<TResponse> RunAsync()
        {
            return Task.Run(() =>
            {
                var result = OnRun();

                return result;
            });
        }
    }
}
