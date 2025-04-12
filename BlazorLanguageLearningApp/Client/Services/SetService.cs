using BlazorLanguageLearningApp.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class SetService
    {
        private readonly FolderService _folderService;
        private readonly NavigationManager _navigationManager;
        public Set? CurrentSet { get; private set; }
        public List<Action> OnChange = new List<Action>();
        
        public SetService(FolderService folderService, NavigationManager navigationManager)
        {
            _folderService = folderService;
            _navigationManager = navigationManager;
        }

        public void AddSet(Set set)
        {
            _folderService.CurrentFolder!.Sets.Add(set);
            NotifyStateChanged();
        }

        public void RemoveSet(Set set)
        {
            _folderService.CurrentFolder!.Sets.Remove(set);
            _navigationManager.NavigateTo($"/sets/{_folderService.CurrentFolder.Id}");
        }

        public void UpdateSet(Set set)
        {
            Set oldSet = _folderService.CurrentFolder!.Sets.FirstOrDefault(s => s.Id == set.Id)!;
            oldSet = set;
            NotifyStateChanged();
        }

        public Set? GetSet(int folderId, int setId)
        {
            CurrentSet = _folderService.GetFolder(folderId)?.Sets.FirstOrDefault(s => s.Id == setId);
            return CurrentSet;
        }

        private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
    }
}
