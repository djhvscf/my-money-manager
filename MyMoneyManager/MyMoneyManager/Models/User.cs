using MvvmHelpers;
using SQLite;
using System;

namespace MyMoneyManager.Models
{
    public class User : ObservableObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }
    }
}
