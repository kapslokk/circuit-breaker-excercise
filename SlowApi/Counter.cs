namespace SlowApi;

public class Counter
{
    private int _counter = 0;
    private DateTime _lastRequest = new DateTime();

    public int GetCount()
    {
        if (DateTime.Now.Subtract(_lastRequest).TotalMilliseconds < 1000)
        {
            _counter++;
        }

        if (DateTime.Now.Subtract(_lastRequest).TotalMilliseconds > 5000)
        {
            _counter = 0;
        }

        _lastRequest = DateTime.Now;

        if (_counter > 5)
        {
            throw new Exception("Too many requests");
        }
        
        return _counter;
    }
}