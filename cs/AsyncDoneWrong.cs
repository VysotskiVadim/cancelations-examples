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
            var data = await FakeTaskManager.fetchDataAsync();
            view.showData(data);
        }

        public void destroy() {
            //cleanup the resources
            view.Dispose();
        }
    }
}