using Microsoft.Win32;

class Program
{
    const string RegistryPath = @"SOFTWARE\MyAppSettings";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:\n1 - Изменить настройки\n2 - Показать текущие настройки\n0 - Выход");
      
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SaveSettings();
                    break;
                case "2":
                    LoadSettings();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }

    static void SaveSettings()
    {
        Console.Write("Введите новое значение параметра (string): ");
        string settingValue = Console.ReadLine();

        RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath);
        key.SetValue("Setting", settingValue, RegistryValueKind.String);
        key.Close();

        Console.WriteLine("Настройки сохранены\n");
    }

    static void LoadSettings()
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath);
        if (key != null)
        {
            string settingValue = key.GetValue("Setting", "не установлено").ToString();
            Console.WriteLine($"Текущее значение параметра: {settingValue}\n");
            key.Close();
        }
        else
            Console.WriteLine("Настройки отсутствуют\n");
    }
}
