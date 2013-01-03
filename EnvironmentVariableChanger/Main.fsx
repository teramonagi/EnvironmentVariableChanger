open System;;
open System.Windows.Forms;;

type MainForm = class 
    inherit Form

    val box : TextBox

    new() as this =
        {
            inherit Form()
            box = new TextBox(Height=400)
        }
        then
            this.box.ScrollBars <- ScrollBars.Vertical
            this.box.Multiline <- true
            this.box.Dock <- DockStyle.Top
            let paths = Environment.GetEnvironmentVariable("PATH");
            this.box.Text <- paths.Replace(";", Environment.NewLine)
            this.Controls.Add(this.box)
end;;

[<STAThread>]
do System.Windows.Forms.Application.Run(new MainForm());;