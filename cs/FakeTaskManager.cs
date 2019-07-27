using System.Threading.Tasks;

namespace cs {
    static class FakeTaskManager {
        public static async Task<int> fetchDataAsync() {
            await Task.Delay(200);
            return 5;
        }
    }
}