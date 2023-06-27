namespace SalonLib;
public class ServiceLocator
{
<<<<<<< HEAD
=======
    private static IDictionary<string, Func<string>> store;

    static ServiceLocator()
    {
        store = new Dictionary<string, Func<string>>();
        store.Add("Читать стихи", () => "В читальном зале");
        store.Add("Петь романсы", () => "У рояля");
    }

    public static string GetService(string key)
    {
        return store[key].Invoke();
    }
>>>>>>> d339683 (Добавлен сервис 1)

}
