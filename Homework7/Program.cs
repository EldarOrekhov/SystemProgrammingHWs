using System.Text.Json;

class Program
{
    static void Main()
    {
        NoteManager noteManager = new("notes.json");

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить заметку");
            Console.WriteLine("2. Показать заметки");
            Console.WriteLine("3. Удалить заметку");
            Console.WriteLine("4. Редактировать заметку");
            Console.WriteLine("0. Выход из программы");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    noteManager.AddNote();
                    break;
                case "2":
                    noteManager.ShowNotes();
                    break;
                case "3":
                    noteManager.DeleteNote();
                    break;
                case "4":
                    noteManager.EditNote();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
            Console.WriteLine();
        }
    }
}

class Note
{
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }

    public Note(string title, string text)
    {
        Title = title;
        Text = text;
        CreatedAt = DateTime.Now;
    }
}

class NoteManager
{
    private readonly string _filePath;
    private List<Note> _notes;

    public NoteManager(string filePath)
    {
        _filePath = filePath;
        _notes = LoadNotes();
    }

    public void AddNote()
    {
        Console.Write("Введите заголовок: ");
        string title = Console.ReadLine();

        Console.Write("Введите текст заметки: ");
        string text = Console.ReadLine();

        _notes.Add(new Note(title, text));
        SaveNotes();
        Console.WriteLine("Заметка успешно добавлена.");
    }

    public void ShowNotes()
    {
        if (_notes.Count == 0)
        {
            Console.WriteLine("Заметок нет");
            return;
        }

        for (int i = 0; i < _notes.Count; i++)
        {
            Console.WriteLine($"\n#{i + 1} {_notes[i].Title} ({_notes[i].CreatedAt})");
            Console.WriteLine(_notes[i].Text);
            Console.WriteLine(new string('-', 30));
        }
    }

    public void DeleteNote()
    {
        ShowNotes();
        if (_notes.Count == 0) return;

        Console.Write("Введите номер заметки для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _notes.Count)
        {
            _notes.RemoveAt(index - 1);
            SaveNotes();
            Console.WriteLine("Заметка удалена");
        }
        else
            Console.WriteLine("Неверный номер");
    }

    public void EditNote()
    {
        ShowNotes();
        if (_notes.Count == 0) return;

        Console.Write("Введите номер заметки для редактирования: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _notes.Count)
        {
            Console.Write("Введите новый заголовок: ");
            _notes[index - 1].Title = Console.ReadLine();

            Console.Write("Введите новый текст: ");
            _notes[index - 1].Text = Console.ReadLine();

            SaveNotes();
            Console.WriteLine("Заметка обновлена");
        }
        else
            Console.WriteLine("Неверный номер");
    }

    private void SaveNotes()
    {
        string json = JsonSerializer.Serialize(_notes, new JsonSerializerOptions());
        File.WriteAllText(_filePath, json);
    }

    private List<Note> LoadNotes()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Note>>(json) ?? new List<Note>();
        }
        return new List<Note>();
    }
}
