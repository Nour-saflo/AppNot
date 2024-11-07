using AppNot.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppNot.ViewModels
{
    public partial class NoteViweModel : INotifyPropertyChanged
    {  

        ////feled
        private Note _selectedNote;
        private string _notetitle;  
        private string _notedescription;
       /// get and set feldes
       public string NoteTitle
        {
            get => _notetitle; set
            {
                if (_notetitle != value)
                {
                    _notetitle = value;
                    OnPropertyChanged();

                };
            }
        }
        public string Notedescription
        {
            get => _notedescription; set
            {
                if (_notedescription != value)
                {
                    _notedescription = value;
                    OnPropertyChanged();

                };
            }
        }
        public Note SelectedNote
        {
            get => _selectedNote; set
            {
                if (_selectedNote != value)
                {
                    _selectedNote = value;
                    NoteTitle = _selectedNote.Title; Notedescription = _selectedNote.Descriotion;///set  from list to ui
                    OnPropertyChanged();

                };
            }
        }


        ///////prperty
        public ObservableCollection<Note> NoteCollection { get; set; }

        public NoteViweModel()
        {
            NoteCollection=new ObservableCollection<Note>();
            AddNoteCommand = new Command(addNot);
            RemoveNoteCommand = new Command(deletnot);
            EditNoteCommand = new Command(EDITENOT);

        }

        private void deletnot(object obj)
        {
          if(SelectedNote != null)
            {
                NoteCollection.Remove(SelectedNote);
                NoteTitle = string.Empty;
                Notedescription = string.Empty;
            }
        }
        private void EDITENOT(object obj)
        {
            if (SelectedNote != null)
            {
               foreach(Note note in NoteCollection.ToList())
                if(note==SelectedNote)
                {
                        var newnote = new Note
                        {
                            Id = note.Id,
                            Title = NoteTitle,
                            Descriotion = Notedescription


                        };
                        NoteCollection.Remove(note);
                        NoteCollection.Add(newnote);

                } 


            }
        }

        private void addNot(object obj)
        {
            int newI = NoteCollection.Count > 0 ? NoteCollection.Max(p => p.Id) + 1 : 1;
            ////set new Note
            var not = new Note
            {  Id=newI,
                Descriotion = Notedescription,
            Title=NoteTitle
            };
            NoteCollection.Add(not); ////add not
                                     //// rest values
            NoteTitle = string.Empty;
            Notedescription = string.Empty;
        }

        public ICommand AddNoteCommand { get; set; }
        public ICommand EditNoteCommand { get; set; }
        public ICommand RemoveNoteCommand { get; set; }



        /// <summary>
        /// //prpetyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
