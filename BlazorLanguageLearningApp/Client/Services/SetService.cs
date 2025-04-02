using BlazorLanguageLearningApp.Shared;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class SetService
    {
        private readonly FolderService _folderService;
        public Set? CurrentSet { get; private set; }
        public List<Action> OnChange = new List<Action>();
        
        public SetService(FolderService folderService)
        {
            _folderService = folderService;
        }

        public Set? GetSet(int folderId, int setId)
        {
            CurrentSet = _folderService.GetFolder(folderId)?.Sets.Where(s => s.Id == setId).FirstOrDefault();
            return CurrentSet;
        }

        private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
    }
}
