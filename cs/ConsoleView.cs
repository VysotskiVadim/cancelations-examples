using System;

namespace cs {
    class ConsoleView: IDisposable {

        private bool _isDisposed = false;

        public void ShowLoading() {
            EnsureNotDisposed();
            System.Console.WriteLine("Loading...");
        }

        public void HideLoading() {
            EnsureNotDisposed();
            System.Console.WriteLine("Loading completed");
        }

        public void ShowData(int data) {
            EnsureNotDisposed();
            System.Console.WriteLine("Data is " + data);
        }

        public void Dispose()
        {
            _isDisposed = true;
        }

        private void EnsureNotDisposed() {
            if (_isDisposed) {
                throw new ObjectDisposedException("ConsoleView");
            }
        }
    }
}