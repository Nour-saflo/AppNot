namespace AppNot.Views;

public partial class NotViwe : ContentView
{
	public NotViwe()
	{
		InitializeComponent();
	    BindingContext= new ViewModels.NoteViweModel();	

    }
}