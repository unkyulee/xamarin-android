using MvvmCross.Core.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class MainViewModel: MvxViewModel
    {
        ILocalDBService _dbService;
        public MainViewModel(ILocalDBService dbService)
        {
            _dbService = dbService;
        }

        Models.TestTable TitleRow;
        public override async Task Initialize()
        {
            await base.Initialize();

            // load title from the local db
            var result = await _dbService.List<Models.TestTable>("SELECT * FROM TestTable");
            if( result != null )
            {
                TitleRow = result.FirstOrDefault();
                if(TitleRow != null )
                    Title = TitleRow.title;
            }           

        }

        private string _Title;
        public string Title {
            get { return _Title; }
            set
            {
                _Title = value;
                RaisePropertyChanged(() => Title);

                // save value to the db
                if (TitleRow == null)
                    TitleRow = new Models.TestTable();                
                TitleRow.title = value;
                _dbService.Upsert(TitleRow);
                
            }
        }
    }
}