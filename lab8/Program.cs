using System;
using System.Data.SQLite;
using System.IO;

class PhoneBook
{
    
    static SQLiteConnection CreateDatabase(string dbName)
    {
        SQLiteConnection connect;
        string commandTextContacts = "CREATE TABLE Contacts (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name NVARCHAR(128))";
        string commandTextPhones = "CREATE TABLE Phones (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, number NVARCHAR(20), contact_id INTEGER, FOREIGN KEY (contact_id) REFERENCES Contacts(id))";

        SQLiteConnection.CreateFile(dbName);
        connect = new SQLiteConnection("Data Source=" + dbName);
        connect.Open();

        using (SQLiteCommand command = new SQLiteCommand(connect))
        {
            command.CommandText = commandTextContacts;
            command.ExecuteNonQuery();

            command.CommandText = commandTextPhones;
            command.ExecuteNonQuery();
        }

        return connect;
    }

    static SQLiteConnection OpenDatabase(string dbName)
    {
        if (!File.Exists(dbName))
            return CreateDatabase(dbName);

        SQLiteConnection connect = new SQLiteConnection("Data Source=" + dbName);
        connect.Open();
        return connect;
    }

    static void CloseDatabase(SQLiteConnection connect)
    {
        connect.Close();
    }

    static void InsertContact(SQLiteConnection connect, string contactName)
    {
        using (SQLiteCommand command = new SQLiteCommand($"INSERT INTO Contacts (name) VALUES('{contactName}')", connect))
        {
            command.ExecuteNonQuery();
        }
    }

    static void InsertPhone(SQLiteConnection connect, string contactName, string phoneNumber)
    {
        int contactId = GetId(connect, "Contacts", contactName);
        using (SQLiteCommand command = new SQLiteCommand($"INSERT INTO Phones (number, contact_id) VALUES('{phoneNumber}', {contactId})", connect))
        {
            command.ExecuteNonQuery();
        }
    }

    static int GetId(SQLiteConnection connect, string table, string value)
    {
        using (SQLiteCommand command = new SQLiteCommand($"SELECT id FROM {table} WHERE name = '{value}'", connect))
        using (SQLiteDataReader res = command.ExecuteReader())
        {
            if (res.Read())
                return Convert.ToInt32(res[0]);
        }
        throw new Exception($"Абонента {value} не знайдено!");
    }

    static void PrintPhoneBook(SQLiteConnection connect)
    {
        string query = "SELECT Contacts.name, Phones.number FROM Contacts JOIN Phones ON Contacts.id = Phones.contact_id ORDER BY Contacts.name";
        using (SQLiteCommand command = new SQLiteCommand(query, connect))
        using (SQLiteDataReader res = command.ExecuteReader())
        {
            Console.WriteLine("{0,-20} {1,-15}", "Абонент", "Телефон");
            Console.WriteLine(new string('-', 40));
            while (res.Read())
            {
                Console.WriteLine("{0,-20} {1,-15}", res[0], res[1]);
            }
        }
    }

    static void Main()
    {
        string dbPath = "phonebook.db";
        var connect = OpenDatabase(dbPath);
        SQLiteTransaction transaction = connect.BeginTransaction();

        try
        {
            InsertContact(connect, "Іван Петренко");
            InsertContact(connect, "Марія Іваненко");

            InsertPhone(connect, "Іван Петренко", "+380671234567");
            InsertPhone(connect, "Іван Петренко", "+380991234567");
            InsertPhone(connect, "Марія Іваненко", "+380661234567");

            PrintPhoneBook(connect);
            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine("Помилка: " + e.Message);
        }

        CloseDatabase(connect);
        Console.ReadKey();
    }
}
