using Microsoft.Win32;

class Program
{
    const string RegistryPath = @"SOFTWARE\MyApp";
    const string RegistryKey = "LastAccess";

    static void Main()
    {
        LoadLastAccess();
        SaveCurrentAccess();
    }

    static void SaveCurrentAccess()
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath);
        key.SetValue(RegistryKey, currentTime, RegistryValueKind.String);
        key.Close();
        Console.WriteLine("Текущее время входа сохранено: " + currentTime);
    }

    static void LoadLastAccess()
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath);
        if (key != null)
        {
            string lastAccess = key.GetValue(RegistryKey, "Нет данных").ToString();
            Console.WriteLine("Последний вход: " + lastAccess);
            key.Close();
        }
        else
            Console.WriteLine("Запись о последнем входе отсутствует");
    }
}