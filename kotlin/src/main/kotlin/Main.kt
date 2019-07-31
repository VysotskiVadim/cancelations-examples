import kotlinx.coroutines.*

fun main() {
    val screen = RightScreen()
    screen.initialize()
    screen.destroy()
    readLine()
}

class RightScreen: CoroutineScope by CoroutineScope(Dispatchers.Unconfined) {

    lateinit var view: ConsoleView

    fun initialize() {
        view = ConsoleView()
        launch {
            view.showLoading()
            val data = fetchData()
            view.hideLoading()
            view.showData(data)
        }
    }

    fun destroy() {
        cancel()
        view.dispose()
    }

}

class ConsoleView {

    private var isDisposed = false

    fun showData(data: Int) {
        ensureNotDisposed()
        println("data is $data")
    }

    fun showLoading() {
        ensureNotDisposed()
        println("loading")
    }

    fun hideLoading() {
        ensureNotDisposed()
        println("loading completed")
    }

    fun dispose() {
        isDisposed = true
    }

    private fun ensureNotDisposed() {
        if (isDisposed) throw Throwable("view was already disposed")
    }
}


suspend fun fetchData(): Int {
    delay(500)
    return 5
}