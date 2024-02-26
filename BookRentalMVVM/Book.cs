using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalMVVM
{
    internal class Book : ObservableObject
    {
        public Book()
        {
            this.PropertyChanged += Book_PropertyChanged;
        }
        private Book(string? author, string? title, string? type, DateTime? publish)
        {
            this.title = title;
            this.type = type;
            this.publish = publish;
            this.PropertyChanged += Book_PropertyChanged;
            Author = author;
        }
        private void Book_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Title):
                case nameof(Author):
                    DisplayedName = $"{Author} - {Title}";
                    CheckValidity();
                    break;
                case nameof(Publish):
                case nameof(Type):
                    CheckValidity();
                    break;
            }
        }

        #region Fields
        private const char separator = '|';
        private string? author;
        private string? title;
        private string? type;
        private DateTime? publish;
        private string? displayedName;
        private bool isValid;
        #endregion
        #region Properties
        public string? Author
        {
            get { return author; }
            set { SetProperty(ref author, value); }
        }
        public string? Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public string? Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }
        public DateTime? Publish
        {
            get { return publish; }
            set { SetProperty(ref publish, value); }
        }
        public string? DisplayedName
        {
            get { return displayedName; }
            set { SetProperty(ref displayedName, value); }
        }
        public bool IsValid
        {
            get { return isValid; }
            set { SetProperty(ref isValid, value); }
        }
        #endregion

        private void CheckValidity()
        {
            IsValid = !string.IsNullOrWhiteSpace(author) &&
                      !string.IsNullOrWhiteSpace(type) &&
                      !string.IsNullOrWhiteSpace(title) &&
                      publish.HasValue;
        }
        public static Book FromCsv(string line)
        {
            var splits = line.Split(separator);
            return new Book(splits[0], splits[1], splits[2], DateTime.Parse(splits[3]));
        }
        public string ToCsv()
        {
            var builder = new StringBuilder();
            builder.Append(author).Append(separator).Append(title).Append(separator).Append(type).Append(separator).Append(publish!.Value);
            return builder.ToString();
        }
    }
}
