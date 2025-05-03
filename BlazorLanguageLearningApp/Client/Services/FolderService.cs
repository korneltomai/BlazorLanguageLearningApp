using BlazorLanguageLearningApp.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class FolderService
    {
        private readonly NavigationManager _navigationManager;
        private List<Folder> Folders { get; set; } = new List<Folder>();
        public Folder? CurrentFolder { get; private set; }
        public List<Action> OnChange = new List<Action>();

        public FolderService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;

            List<Card> cards1 = new List<Card>
            {
                new Card(1, "Dog", "Kutya", "english", "hungarian", 100),
                new Card(2, "Capybara", "Vizidisznó", "english", "hungarian", 90),
                new Card(3, "Cat", "Macska", "english", "hungarian", 80),
                new Card(4, "Cow", "Tehén", "english", "hungarian", 70),
                new Card(5, "Bull", "Bika", "english", "hungarian", 60),
                new Card(6, "Hamster", "Hörcsög", "english", "hungarian", 50),
                new Card(7, "Mouse", "Egér", "english", "hungarian", 40),
                new Card(8, "Rat", "Patkány", "english", "hungarian", 30),
                new Card(9, "Worm", "Féreg", "english", "hungarian", 20),
                new Card(10, "Bee", "Méh", "english", "hungarian", 10),
                new Card(11, "Ant", "Hangya", "english", "hungarian", 0),
            };

            List<Card> cards2 = new List<Card>
            {
                new Card(12, "Football", "Focilabda", "english", "hungarian", 100),
                new Card(13, "Basketball", "Kosárlabda", "english", "hungarian", 90),
                new Card(14, "Boxing", "Ökölvívás", "english", "hungarian", 90)
            };

            List<Set> sets1 = new List<Set>
            {
                new Set(1, "Allatok", "Csomag az állatokhoz", cards1)
            };

            List<Set> sets2 = new List<Set>
            {
                new Set(2, "Sportok", "", cards2)
            };

            Folders.Add(new Folder(1, "Allatos mappa", "Ebben a mappában vannak az állatos csomagok", sets1));
            Folders.Add(new Folder(2, "Sulis cuccok", "Minden amit a suliban tanulunk", sets2));
        }

        public void AddFolder(Folder folder)
        {
            Folders.Add(folder);

            CurrentFolder = folder;
            _navigationManager.NavigateTo($"/sets/{folder.Id}");
        }

        public void RemoveFolder(Folder folder) 
        { 
            Folders.Remove(folder);

            CurrentFolder = null;
            _navigationManager.NavigateTo("/sets");
        }

        public void UpdateFolder(Folder folder)
        {
            Folder oldFolder = Folders.FirstOrDefault(f => f.Id == folder.Id)!;
            oldFolder = folder;
            NotifyStateChanged();
        }

        public Folder? GetFolder(int? id)
        {
            CurrentFolder = Folders.FirstOrDefault(f => f.Id == id);
            return CurrentFolder;
        }

        public List<Folder> GetAllFolders()
        {
            return Folders;
        }

        private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
    }
}
