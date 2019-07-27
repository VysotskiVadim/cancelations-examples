namespace cs {
    static class AsyncDoneWrong {

        public static void doAsyncWrong() {
            var screen = new WrongScreen();
            screen.initialize();
        }

        public static void revealWrongAsync() {
            var screen = new WrongScreen();
            screen.initialize();

            //emulate user leave the screen
            screen.destroy();
        }
    }

    class WrongScreen { 

        private ConsoleView view;

        public async void initialize() {
            view = new ConsoleView();
            view.ShowLoading();
            var data = await FakeTaskManager.fetchDataAsync();
            view.HideLoading();
            view.ShowData(data);
        }

        public void destroy() {
            //cleanup the resources
            view.Dispose();
        }
    }
}