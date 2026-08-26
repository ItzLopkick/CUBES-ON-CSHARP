using System.Windows.Input;

static class InputSystem
{
    public static List<Key> keyboardbuttons = new List<Key> {};



    public static void HandlingKeysDown(object Sender,KeyEventArgs event2)
    {
        if (!keyboardbuttons.Contains(event2.Key))
        {
            keyboardbuttons.Add(event2.Key);
        }
        event2.Handled = true;
    }
    public static void HandlingKeysUp(object Sender,KeyEventArgs event2)
    {
        keyboardbuttons.Remove(event2.Key);
        event2.Handled = true;
    }
    public static void KeyLog()
    {
        foreach (Key keys in keyboardbuttons)
        {
            Console.WriteLine(keys);
        }
        Console.WriteLine("-------------------------------------------------------------------------我喜欢CSHARP");
    }
}