using BlazorLanguageLearningApp.Shared;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class SetService
    {
        private readonly FolderService _folderService;
        public List<Action> OnChange = new List<Action>();
        
        public SetService(FolderService folderService)
        {
            _folderService = folderService;
        }

        public Set? GetSet(int folderId, int setId)
        {
            return _folderService.GetFolder(folderId)?.Sets.Where(s => s.Id == setId).FirstOrDefault();
        }

        private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
    }
}
