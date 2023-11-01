public interface IObserver
{
    public void OnNotify();
    public void OnNotify(string _string);
    public void OnNotify(int _value);
    public void OnNotify(float _value);

    public void OnNotify(ShoutWords _shoutWord);
}