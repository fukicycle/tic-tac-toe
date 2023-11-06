using Microsoft.AspNetCore.Mvc.Formatters;
using TicTacToe.Data;

namespace TicTacToe
{
    public class Winner
    {

        public int Check(List<GridItem> originals)
        {
            #region Horizontal winner
            if (originals[0].Content == originals[1].Content && originals[1].Content == originals[2].Content)
            {
                return 1;
            }
            else if (originals[3].Content == originals[4].Content && originals[4].Content == originals[5].Content)
            {
                return 1;
            }
            else if (originals[6].Content == originals[7].Content && originals[7].Content == originals[8].Content)
            {
                return 1;
            }
            #endregion
            #region Vertical winner
            else if (originals[0].Content == originals[3].Content && originals[3].Content == originals[6].Content)
            {
                return 1;
            }
            else if (originals[1].Content == originals[4].Content && originals[4].Content == originals[7].Content)
            {
                return 1;
            }
            else if (originals[2].Content == originals[5].Content && originals[5].Content == originals[8].Content)
            {
                return 1;
            }
            #endregion
            #region Diagonal winner
            else if (originals[0].Content == originals[4].Content && originals[4].Content == originals[8].Content)
            {
                return 1;
            }
            else if (originals[2].Content == originals[4].Content && originals[4].Content == originals[6].Content)
            {
                return 1;
            }
            #endregion
            else if (originals.All(a => a.DisplayContent != string.Empty))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
