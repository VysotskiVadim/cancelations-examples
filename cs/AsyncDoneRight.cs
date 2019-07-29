using System;
using System.Threading;

namespace cs {
    static class AsyncDoneRight {

        public static void doAsyncRight() {
            var screen = new RightScreen();
            screen.initialize();
            screen.destroy();
        }

    }

    class RightScreen { 

        private CancellationTokenSource cts;
        private ConsoleView view;

        public async void initialize() {
            try {
            view = new ConsoleView();
            view.ShowLoading();
            cts = new CancellationTokenSource();
            var data = await FakeTaskManager.fetchDataAsync(cts.Token);
            view.HideLoading();
            view.ShowData(data);
            } catch (OperationCanceledException) {
                Console.WriteLine("Operation was cancelled");
            }
        }

        public void destroy() {
            cts.Cancel();
            //cleanup the resources
            view.Dispose();
        }
    }
}