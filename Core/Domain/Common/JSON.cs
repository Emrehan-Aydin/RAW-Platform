using Newtonsoft.Json;

namespace RAWAPI.Domain.Common {
    public static class JSON{

        public static target Map<source,target>(source data) {
            return JsonConvert.DeserializeObject<target>(JsonConvert.SerializeObject(data));
        }
    }
}
