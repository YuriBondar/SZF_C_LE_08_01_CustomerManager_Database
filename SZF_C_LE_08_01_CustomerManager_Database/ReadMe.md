C# SZF

LE 08 - Datenbanken in C#

Arbeitsauftrag LE_08

Arbeitsauftrag
Ziel des Arbeitsauftrages
Entwicklung eines Kundenverwaltungssystems mit grafischer Oberfläche (GUI) 
und einer MySQL-Datenbank zur Verwaltung von Kundendaten.

Kontext:
Die Firma GoldDigger GmbH hat Sie beauftragt, ein Kundenverwaltungssystem zu entwickeln. 
Dieses System soll es ermöglichen, Kundendaten zu speichern, anzuzeigen, zu bearbeiten und zu löschen. 
Zusätzlich sollte das System über eine Benutzeranmeldung verfügen, um den Zugang zu sichern.


Detaillierte Anforderungen

1.Projektplanung
- Erstellen Sie ein Diagramm, das den Ablauf des Programms darstellt.

2.Benutzeranmeldung
- Implementieren Sie eine Anmeldemaske, in der Benutzername und Passwort eingegeben werden müssen.
- Integrieren Sie eine Benutzerregistrierung, um neue Benutzer anzulegen.
- Implementieren Sie eine Überprüfung der Anmeldedaten gegen die in der Datenbank gespeicherten Daten.

3.Hauptfenster
- Nach erfolgreicher Anmeldung soll das Hauptfenster des Programms geöffnet werden.
- Im Hauptfenster sollen alle Kundendaten aus der MySQL-Datenbank angezeigt werden.
- Kundendaten umfassen: Vorname, Nachname, Straße, Hausnummer, PLZ, Wohnort und E-Mail-Adresse.

4. Funktionen im Hauptfenster
- Anlegen von neuen Kundendaten: Erstellen Sie ein Formular zur Eingabe neuer Kundendaten und speichern Sie diese in der Datenbank.
- Bearbeiten von Kundendaten: Ermöglichen Sie das Bearbeiten bestehender Kundendaten 
und speichern Sie die Änderungen in der Datenbank.
- Löschen von Kundendaten: Implementieren Sie die Funktion, um vollständige Datensätze eines Kunden aus der Datenbank zu löschen.
- Programm beenden: Fügen Sie eine Möglichkeit hinzu, das Programm ordnungsgemäß zu beenden.

5. Datenbankverwaltung
- Erstellen Sie eine MySQL-Datenbank mit den notwendigen Tabellen und Spalten.
- Implementieren Sie Funktionen zum Speichern, Abrufen, Bearbeiten und Löschen von Daten in der Datenbank.

Tipps:

Planen Sie das Projekt Schritt für Schritt, bevor Sie mit dem Programmieren beginnen. (UML Diagramm)

Überlegen Sie sich bei der Datenbankerstellung, welche Schlüssel und Inkremente benötigt werden 
und wie Sie die Tabellen und Spalten sinnvoll aufteilen.

Gestalten Sie die GUI strukturiert und überlegen Sie im Voraus, welche Elemente und Attribute notwendig sind.

------------------------------------------------------------------------------------------------------------------

Рабочее задание

Цель рабочего задания:
Разработка системы управления клиентами с графическим интерфейсом пользователя (GUI) 
и базой данных MySQL для управления данными о клиентах.

Контекст:
Компания GoldDigger GmbH поручила вам разработать систему управления клиентами. 
Эта система должна позволять сохранять, отображать, редактировать и удалять данные клиентов. 
Кроме того, система должна содержать функцию авторизации пользователей для обеспечения безопасности доступа.

Детализированные требования:

1. Планирование проекта
- Создайте диаграмму, которая отображает процесс работы программы.

2. Авторизация пользователей
- Реализуйте форму входа, где необходимо ввести имя пользователя и пароль.
- Интегрируйте регистрацию пользователей для добавления новых пользователей.
- Реализуйте проверку введённых данных при входе в систему на основе данных, сохранённых в базе данных.

3. Главное окно программы
- После успешного входа должно открываться главное окно программы.
- В главном окне должны отображаться все клиенты из базы данных MySQL.
- Данные клиентов включают: имя, фамилию, улицу, номер дома, почтовый индекс, место жительства и адрес электронной почты.

4.	Функции в главном окне
- Добавление нового клиента: создайте форму для ввода новых данных о клиенте и сохранения их в базу данных.
- Редактирование данных клиентов: Реализуйте возможность редактирования существующих данных клиентов и сохранения изменений в базе данных.
- Удаление клиентов: Реализуйте функцию, позволяющую полностью удалить данные клиента из базы данных.
- Завершение программы: Добавьте возможность корректного завершения работы программы.

Управление базой данных
- Создайте базу данных MySQL с необходимыми таблицами и столбцами.
-Реализуйте функции для сохранения, получения, редактирования и удаления данных в базе данных.

Советы:
•	Планируйте проект шаг за шагом перед началом программирования. (UML-диаграмма)
•	Тщательно продумайте структуру базы данных, определите ключи и автоинкременты, а также логически распределите таблицы и столбцы.
•	Проектируйте графический интерфейс пользователя (GUI) структурировано. 
Заранее продумайте, какие элементы и атрибуты будут необходимы.

CREATE DATABASE GoldDigger_CustomerManagerDB_Csharp_LO08;
USE GoldDigger_CustomerManagerDB_Csharp_LO08;

CREATE TABLE customers (
CustomerID INT AUTO_INCREMENT PRIMARY KEY, 
CustomerFirstName VARCHAR(30),
CustomerLastName VARCHAR(30),
CustomerStreet VARCHAR(30),
CustomerHausNumber VARCHAR(10),
CustomerPostIndex VARCHAR(6),
CustomerCity VARCHAR(30),
CustomerEmail VARCHAR(30)
 );
 
 CREATE TABLE authorizations (
UserLogin VARCHAR(30) PRIMARY KEY, 
UserPassword VARCHAR(30)
 );
 
 drop DATABASE GoldDigger_CustomerManagerDB_Csharp_LO08;
 SELECT * FROM authorizations;
 SELECT * FROM Customers;
 SET SQL_SAFE_UPDATES = 0;
 delete from Customers;
 
 INSERT INTO authorizations (UserLogin, UserPassword)
 VALUES('admin','admin');
 
 INSERT INTO Customers (CustomerFirstName, CustomerLastName, CustomerStreet, CustomerHausNumber, CustomerPostIndex, CustomerCity, CustomerEmail)
VALUES
('Johann', 'Schmidt', 'Kärntner Straße', '12', '1010', 'Wien', 'johann.schmidt@example.at'),
('Anna', 'Müller', 'Graben', '7A', '5020', 'Salzburg', 'anna.mueller@example.at'),
('Peter', 'Steiner', 'Mariahilfer Straße', '5', '6020', 'Innsbruck', 'peter.steiner@example.at'),
('Katrin', 'Hofmann', 'Landstraße', '3', '4020', 'Linz', 'katrin.hofmann@example.at'),
('Lukas', 'Berger', 'Rathausplatz', '10', '8010', 'Graz', 'lukas.berger@example.at');



