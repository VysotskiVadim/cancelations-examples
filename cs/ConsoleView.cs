using System;

namespace cs {
    class ConsoleView: IDisposable {

        private bool _isDisposed = false;

        public void showData(int data) {
            if (_isDisposed) {
                throw new ObjectDisposedException("Console view already disposed");
            }
            System.Console.WriteLine("data is " + data);
        }

        public void Dispose()
        {
            _isDisposed = true;
        }
    }
}