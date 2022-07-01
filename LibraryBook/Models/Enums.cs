using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.CategoriesClass
{
    public class Enums
    {
        [Flags]
        public enum BookType
        {
            ActionAndAdventure = 2,
            Classics = 4,
            Comic = 8,
            Detective = 16,
            Fantasy = 32,
            HistoricalFiction = 64,
            Horror = 128,
            LiteraryFiction = 256,
        }

        [Flags]
        public enum RecordType
        {
            HipHop = 2,
            Rock = 4,
            RhythmAndBlues = 8,
            Soul = 16,
            Reggae = 32,
            Country = 64,
            Funk = 128
        }
    }
}
