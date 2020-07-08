using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using SearchWordBox.Models;

namespace SearchWordBox.ViewModels
{
    public class MainViewModel : ReactiveObject, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        public MainViewModel()
        {          
            SearchCommand = ReactiveCommand.Create<string,bool>(Search);
            SearchCommand.Subscribe( async f =>
            {
                if (!f)
                {
                   await  DialogUtil.ShowMessageWindowAsync("错误", "查找不到相关数据");
                }
            });
            RelativeRespondCommand = ReactiveCommand.Create<string,Unit>(RelativeRespond);
            _relativeResultsList.Connect().Bind(out _relativeSearchResults).Subscribe();
        }


        private string _searchRelationText = string.Empty;

        public string SearchRelationText
        {
            get
            {
                return _searchRelationText;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _searchRelationText, value);
            }
        }

        public ReactiveCommand<string,bool> SearchCommand { get; }

        public ReactiveCommand<string,Unit> RelativeRespondCommand { get; }

        private SourceList<string> _relativeResultsList = new SourceList<string>();

        private ReadOnlyObservableCollection<string> _relativeSearchResults;

        public ReadOnlyObservableCollection<string> RelativeSearchResults => _relativeSearchResults;

        private SearchModelManage _searchModelManage;

        private bool Search(string searchField)
        {
            return false;
        }

        private Unit RelativeRespond(string searchField)
        {
            _searchModelManage = new SearchModelManage(searchField);
            var results = _searchModelManage.GetSearchRelativeResults();
            if (_relativeResultsList.Count > 0)
                _relativeResultsList.Clear();
            if (results == null || results.Count == 0)
                return Unit.Default;
            _relativeResultsList.Edit(d =>
            {
                d.AddRange(results.Select(s => s));
            });
            return Unit.Default;
        }
    }
}
