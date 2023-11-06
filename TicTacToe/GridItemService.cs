using TicTacToe.Data;

namespace TicTacToe
{
    public class GridItemService
    {
        private readonly Winner _winner;

        public GridItemService(Winner winner)
        {
            _winner = winner;
        }
        private string _displayString = "O";

        private string _result = "";

        private List<GridItem> _items = new List<GridItem>()
            {
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty },
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty },
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty },
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty },
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty },
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty },
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty },
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty },
                new GridItem { Content = Guid.NewGuid().ToString(),DisplayContent = string.Empty }
            };


        public event EventHandler StateChanged = null!;

        public List<GridItem> GetGridItems() { return _items; }

        public string GetResult() { return _result; }

        public void UpdateItem(GridItem item)
        {
            if (item.DisplayContent == string.Empty)
            {
                item.DisplayContent = _displayString;
                item.Content = _displayString;
                _displayString = _displayString == "O" ? "X" : "O";
                switch (_winner.Check(_items))
                {
                    case 1:
                        _result = item.Content;
                        break;
                    case -1:
                        _result = "Draw";
                        break;
                }
                this.StateHasChanged();
            }
        }

        public void Reset()
        {
            foreach (GridItem item in _items)
            {
                item.Content = Guid.NewGuid().ToString();
                item.DisplayContent = string.Empty;
            }
            _displayString = "O";
            _result = "";
            this.StateHasChanged();
        }

        public void StateHasChanged()
        {
            this.StateChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
