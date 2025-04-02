using BlazorLanguageLearningApp.Shared;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class FolderService
    {
        private List<Folder> Folders { get; set; } = new List<Folder>();
        public List<Action> OnChange = new List<Action>();

        public FolderService()
        {
            List<Set> sets1 = new List<Set>
            {
                new Set(1, "Allatok", "Csomag az allatokhoz", 78),
                new Set(2, "Allatok2", "Csomag az allatokhoz csak sokkal nagyobb", 50),
                new Set(3, "Set3", "This is set3 with an extremely long description. " +
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large." +
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large." +
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large.", 30),
                new Set(4, "Set4", "This is set4", 0),
                new Set(5, "Set5 with a long name", "Csomag az allatokhoz", 12),
                new Set(6, "Set6 with a really really long name", "Csomag az allatokhoz", 33),
                new Set(7, "Set7", "This is set7", 100),
                new Set(8, "Set8", "This is set8", 99),
                new Set(9, "Set9", "This is set9", 98),
                new Set(10, "Set10", "This is set10", 76),
                new Set(11, "Set11", "This is set11", 78),
                new Set(12, "Set12", "This is set12", 65),
                new Set(13, "Set13", "This is set13", 54),
                new Set(14, "Set14", "This is set14", 52),
                new Set(15, "Set15", "This is set15", 33),
                new Set(16, "Set16", "This is set16", 24),
                new Set(17, "Set17", "This is set17", 88),
                new Set(18, "Set18", "This is set18", 87),
                new Set(19, "Set19", "This is set19", 69),
                new Set(20, "Set20", "This is set20", 75),
                new Set(21, "Set21", "This is set21", 75),
                new Set(22, "Set22", "This is set22", 44),
                new Set(23, "Set23", "This is set23", 5)
            };

            List<Set> sets2 = new List<Set>
            {
                new Set(24, "Set24", "This is set24", 0),
                new Set(25, "Set25", "This is set25", 50),
                new Set(26, "Set26", "This is set26", 100),
            };

            Folders.Add(new Folder(1, "Folder1", "This is Folder1 and this have a medium length description about something.", sets1));
            Folders.Add(new Folder(2, "Folder2 with a long name", "This is Folder2", sets2));
            Folders.Add(new Folder(3, "Folder3 with a really really long name", "This is Folder3 and this have a long descripton to test how it would look. La-la-la la-la-la, monkeys and bananas, nuts and biscuits. I don't know what else to write here. Sue me."));
            Folders.Add(new Folder(4, "Folder4", "This is Folder4 with an around 250 character description. Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large."));
            Folders.Add(new Folder(5, "Folder5", "This is Folder5 with an around 1000 character description." +
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large." +
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large." +
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large." +
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large."));
            Folders.Add(new Folder(6, "Folder6", "This is Folder6"));
            Folders.Add(new Folder(7, "Folder7", "This is Folder7"));
            Folders.Add(new Folder(8, "Folder8", "This is Folder8"));
            Folders.Add(new Folder(9, "Folder9", "This is Folder9"));
            Folders.Add(new Folder(10, "Folder10", "This is Folder10"));
            Folders.Add(new Folder(11, "Folder11", "This is Folder11"));
            Folders.Add(new Folder(12, "Folder12", "This is Folder12"));
            Folders.Add(new Folder(13, "Folder13", "This is Folder13"));
            Folders.Add(new Folder(14, "Folder14", "This is Folder14"));
            Folders.Add(new Folder(15, "Folder15", "This is Folder15"));
            Folders.Add(new Folder(16, "Folder16", "This is Folder16"));
            Folders.Add(new Folder(17, "Folder17", "This is Folder17"));
            Folders.Add(new Folder(18, "Folder18", "This is Folder18"));
            Folders.Add(new Folder(19, "Folder19", "This is Folder19"));
            Folders.Add(new Folder(20, "Folder20", "This is Folder20"));
            Folders.Add(new Folder(21, "Folder21", "This is Folder21"));
            Folders.Add(new Folder(22, "Folder22", "This is Folder22"));
            Folders.Add(new Folder(23, "Folder23", "This is Folder23"));
            Folders.Add(new Folder(24, "Folder24", "This is Folder24"));
            Folders.Add(new Folder(25, "Folder25", "This is Folder25"));
            Folders.Add(new Folder(26, "Folder26", "This is Folder26"));
            Folders.Add(new Folder(27, "Folder27", "This is Folder27"));
            Folders.Add(new Folder(28, "Folder28", "This is Folder28"));
            Folders.Add(new Folder(29, "Folder29", "This is Folder29"));
            Folders.Add(new Folder(30, "Folder30", "This is Folder30"));
        }

        public Folder? GetFolder(int id)
        {
            return Folders.Where(f => f.Id == id).FirstOrDefault();
        }

        public List<Folder> GetAllFolders()
        {
            return Folders;
        }

        private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
    }
}
