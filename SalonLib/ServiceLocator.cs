namespace SalonLib;
public class ServiceLocator
{
    private static IDictionary<string, Func<string>> store;

    static ServiceLocator()
    {
        store = new Dictionary<string, Func<string>>();
        store.Add("Читать стихи", () => "В читальном зале");
<<<<<<< HEAD
        store.Add("Писать статьи", () => "В кабинете");
=======
        store.Add("Петь романсы", () => "У рояля");
>>>>>>> 0d6472a (Добавлен сервис 2)
    }

    public static string GetService(string key)
    {
        return store[key].Invoke();
    }

}
