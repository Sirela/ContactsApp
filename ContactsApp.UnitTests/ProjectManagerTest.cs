using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp;
using ContactsApp;
using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace ContactApp.UnitTests
{
    internal class ProjectManagerTest
    {

        Project _contactsProject;

        [SetUp]
        public void CreateContact()
        {
            List<Contact> contacts = new List<Contact>();
            _contactsProject = new Project(contacts);
            DateTime birthday_first = new DateTime(2003, 6, 23);
            DateTime birthday_second = new DateTime(2001, 8, 16);
            contacts.Add(new Contact("Мишин", "Кирилл", "e@mail.ru", "id123456", birthday_first, new PhoneNumber(78005553535)));
            contacts.Add(new Contact("Мишина", "Анастасия", "a@mail.ru", "id654321", birthday_second, new PhoneNumber(79920152390)));
            _contactsProject.Contacts = contacts;
        }
        [Test(Description = "Сохранение проекта контактов")]
        public void TestSave_CorrectString()
        {
            Assert.DoesNotThrow(
            () => {
                ProjectManager.SaveToFile(_contactsProject);
            },
            "Не должно вохникать исключения");
        }
        [Test(Description = "Загрузка проекта контактов")]
        public void TestLoad_CorrectString()
        {
            Assert.DoesNotThrow(
            () => {
                _contactsProject = ProjectManager.LoadFromFile();
            },
            "Не должно вохникать исключения");
        }
    }
}
