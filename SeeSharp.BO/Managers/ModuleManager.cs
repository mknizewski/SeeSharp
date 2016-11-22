using System;
using System.Collections.Generic;

namespace SeeSharp.BO.Managers
{
    public class ModuleManager : IDisposable
    {
        public string ModuleName { get { return _currentModuleName; } set { _currentModuleName = value; } }
        public string Tag { get { return _currentTag; } set { _currentTag = value; } }

        private static List<Module> _moduleList;
        private static List<Exam> _examList;

        private const bool IsNotExam = false;
        private const bool IsExam = true;

        private string _currentModuleName;
        private string _currentTag;
            
        private ModuleManager(string moduleName, string tag)
        {
            _currentModuleName = moduleName;
            _currentTag = tag;

            InitializeList();
        }

        public static ModuleManager GetModuleManager(string moduleName, string tag)
        {
            return new ModuleManager(moduleName, tag);
        }

        public void Dispose()
        {
            _currentModuleName = string.Empty;
            _currentTag = string.Empty;
        }

        public void LoadModule()
        {
        }

        public string GetNextModule()
        {
            return string.Empty;
        }

        public string GetPervModule()
        {
            return string.Empty;
        }

        #region List Initializer
        private void InitializeList()
        {
            // Rozdział I
            _moduleList.Add(Module.CreateModule("Czym jest .NET?", "1.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Dlaczego C#", "1.2", IsNotExam));

            // Rozdział II - sekcja I
            _moduleList.Add(Module.CreateModule("Pobranie Microsoft Visual Studio", "2.1.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Instalacja programu", "2.1.2", IsNotExam));
            _moduleList.Add(Module.CreateModule("Pierwszy program - Hello World", "2.1.3", IsExam));

            // Egzamin I
            _examList.Add(new Exam
            {
                ModuleTag = "2.1.3",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział II - sekcja II
            _moduleList.Add(Module.CreateModule("Typy zmiennych", "2.2.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Rzutowanie i konwersja", "2.2.2", IsNotExam));
            _moduleList.Add(Module.CreateModule("Stałe", "2.2.3", IsNotExam));
            _moduleList.Add(Module.CreateModule("Wyświetlenie wartości", "2.2.4", IsExam));

            // Egzamin II
            _examList.Add(new Exam
            {
                ModuleTag = "2.2.4",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział II - sekcja III
            _moduleList.Add(Module.CreateModule("Operatory arytmetyczne", "2.3.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Operatory logiczne", "2.3.2", IsNotExam));
            _moduleList.Add(Module.CreateModule("Operatory porównania i operator warunkowy", "2.3.3", IsExam));

            // Egzamin III
            _examList.Add(new Exam
            {
                ModuleTag = "2.3.3",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział II - sekcja IV
            _moduleList.Add(Module.CreateModule("Instrukcja if", "2.4.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Instrukcja switch", "2.4.2", IsExam));

            // Egzamin IV
            _examList.Add(new Exam
            {
                ModuleTag = "2.4.2",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział II - sekcja V
            _moduleList.Add(Module.CreateModule("Pętle while() i do-while()", "2.5.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Pętla for()", "2.5.2", IsNotExam));
            _moduleList.Add(Module.CreateModule("Pętla foreach()", "2.5.3", IsExam));

            // Egzamin V
            _examList.Add(new Exam
            {
                ModuleTag = "2.5.3",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział II - sekcja VI
            _moduleList.Add(Module.CreateModule("Tablice jednowymiarowe", "2.6.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Tablice wielowymiarowe", "2.6.2", IsExam));

            // Egzamin VI
            _examList.Add(new Exam
            {
                ModuleTag = "2.6.2",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział II - sekcja VII
            _moduleList.Add(Module.CreateModule("Wstęp", "2.7.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Pola i właściwości", "2.7.2", IsNotExam));
            _moduleList.Add(Module.CreateModule("Metody", "2.7.3", IsNotExam));
            _moduleList.Add(Module.CreateModule("Konstruktory", "2.7.4", IsNotExam));
            _moduleList.Add(Module.CreateModule("Dziedziczenie", "2.7.5", IsNotExam));
            _moduleList.Add(Module.CreateModule("Polimorfizm", "2.7.6", IsExam));

            // Egzamin VII
            _examList.Add(new Exam
            {
                ModuleTag = "2.7.6",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział II - sekcja VIII
            _moduleList.Add(Module.CreateModule("Interfejsy", "2.8", IsExam));

            // Egzamin VIII
            _examList.Add(new Exam
            {
                ModuleTag = "2.8",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział II - sekcja IX
            _moduleList.Add(Module.CreateModule("Klasy abstrakcyjne", "2.9", IsExam));

            // Egzamin IX
            _examList.Add(new Exam
            {
                ModuleTag = "2.9",
                Task = string.Empty,
                Code = string.Empty,
                TestInput = string.Empty,
                TestOutput = string.Empty
            });

            // Rozdział III - sekcja I
            _moduleList.Add(Module.CreateModule("Płytkie kopie", "3.1.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Głębokie kopie", "3.1.2", IsNotExam));

            // Rozdział III - sekcja II
            _moduleList.Add(Module.CreateModule("Kolekcje", "3.2.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Typy generyczne", "3.2.2", IsNotExam));

            // Rozdział III - sekcja III
            _moduleList.Add(Module.CreateModule("Budowa", "3.3.1", IsNotExam));
            _moduleList.Add(Module.CreateModule("Delegaty złożone i anonimowe", "3.3.2", IsNotExam));

            // Rozdział III - sekcja IV
            _moduleList.Add(Module.CreateModule("Wyrażenia lambda", "3.4", IsNotExam));

            // Rozdział III - sekcja V
            _moduleList.Add(Module.CreateModule("Parę słów o Garbage Collector", "3.5", IsNotExam));
        }
        #endregion
    }

    public struct Module
    {
        public string ModuleName { get; set; }
        public string ModuleTag { get; set; }
        public bool IsExamNext { get; set; }

        public Module(string moduleName, string moduleTag, bool isExamNext) : this()
        {
            this.ModuleName = moduleName;
            this.ModuleTag = moduleTag;
            this.IsExamNext = isExamNext;
        }

        public static Module CreateModule(string moduleName, string moduleTag, bool isExamNext)
        {
            return new Module(moduleName, moduleTag, isExamNext);
        }
    }

    public struct Exam
    {
        public string ModuleTag { get; set; }
        public string Task { get; set; }
        public string Code { get; set; }
        public string TestOutput { get; set; }
        public string TestInput { get; set; }
    }
}