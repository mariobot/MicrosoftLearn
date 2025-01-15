
using Orleans.Runtime;

namespace UrlShortener
{
    public class UrlShortenerGrain : Grain, IUrlShortenerGrain
    {
        private readonly IPersistentState<UrlDetails> state;

        public UrlShortenerGrain(
            [PersistentState(
            stateName: "url",
            storageName: "urls")]
            IPersistentState<UrlDetails> state)
        {
            this.state = state;
        }        

        public async Task SetUrl(string fullUrl)
        {
            state.State = new()
            {
                ShortenedRouteSegment = this.GetPrimaryKeyString(),
                FullUrl = fullUrl
            };

            await state.WriteStateAsync();
        }

        public Task<string> GetUrl() => Task.FromResult(state.State.FullUrl);
    }
}
