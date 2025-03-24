using BlazorLanguageLearningApp.Shared;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class FolderSelectorService
    {
        public List<Folder> Folders { get; set; } = new List<Folder>();
        public Folder? CurrentFolder { get; set; }
        public List<Action> OnChange = new List<Action>();

        public FolderSelectorService()
        {
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2Folder2Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));
            Folders.Add(new Folder(1, "Folder1"));
            Folders.Add(new Folder(2, "Folder2"));
            Folders.Add(new Folder(3, "Folder3"));
            Folders.Add(new Folder(4, "Folder4"));
            Folders.Add(new Folder(5, "Folder5"));

            CurrentFolder = Folders[0];
        }

        public void OpenFolder(int id)
        {
            CurrentFolder = Folders.Where(f => f.Id == id).FirstOrDefault();
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
    }
}
